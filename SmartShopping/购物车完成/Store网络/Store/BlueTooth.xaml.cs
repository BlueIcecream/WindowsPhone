using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Networking.Sockets;
using System.Text;
using Windows.Storage.Streams;
using System.Windows.Input;
using Windows.Networking.Proximity;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Store
{
    public partial class BlueTooth : PhoneApplicationPage
    {
        StreamSocket BTSock;//蓝牙连接Socket
        //构造函数
        public BlueTooth()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }
        //获取蓝牙设备并提示
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            PeerFinder.Start();
            PeerFinder.AlternateIdentities["Bluetooth:Paired"] = ""; // 获取所有配对蓝牙设备
            var peers = await PeerFinder.FindAllPeersAsync();             
            for (int i = 0; i < peers.Count; i++) //显示
            {
                lstBTPaired.Items.Add(peers[i].DisplayName);
            }
        }
        //发送消息函数
        public async void BT2Arduino_Send(string WhatToSend)
        {
            if (BTSock != null) // Since we have a Connection
            {
                var datab = GetBufferFromByteArray(UTF8Encoding.UTF8.GetBytes(WhatToSend)); // Create Buffer/Packet for Sending
                await BTSock.OutputStream.WriteAsync(datab); // 发送消息给连接者
                MessageBox.Show("发送消息：" + WhatToSend);
                ReceiveAcess();
            }
        }
        //接受消息
        public async void ReceiveAcess()
        {
            Byte[] b1 = new Byte[1024];
            IBuffer buffer1 = WindowsRuntimeBufferExtensions.AsBuffer(b1, 0, b1.Length);
            DataReader dr = new DataReader(BTSock.InputStream);
            await BTSock.InputStream.ReadAsync(buffer1, buffer1.Capacity, InputStreamOptions.Partial);
            byte[] bytes = WindowsRuntimeBufferExtensions.ToArray(buffer1, 0, (int)buffer1.Length);
            for (int i = 0; i < 1024; i++)
            {
                if (bytes[i] != null)
                {
                    MessageBox.Show("已收到消息" + i + ":" + bytes[i]);
                }
                else
                {
                    return;
                }
            }
        }
        //打包要发送的消息
        private IBuffer GetBufferFromByteArray(byte[] package)
        {
            using (DataWriter dw = new DataWriter())
            {
                dw.WriteBytes(package);
                return dw.DetachBuffer();
            }
        }
        //连接函数
        private async void lstBTPaired_Tap_1(object sender, GestureEventArgs e)
        {
            if (lstBTPaired.SelectedItem == null) // To prevent errors, make sure something is Selected
            {
                //btnConnectArduino.IsEnabled = false; // Make sure it's False if you want to use a Button
                 // Set UI Output
                return;
            }
            else
                if (lstBTPaired.SelectedItem != null) // 确定以选择
            {
                PeerFinder.AlternateIdentities["Bluetooth:Paired"] = ""; // Grab Paired Devices
                var PF = await PeerFinder.FindAllPeersAsync(); // Store Paired Devices
                BTSock = new StreamSocket(); // socket 连接
                await BTSock.ConnectAsync(PF[lstBTPaired.SelectedIndex].HostName, "1"); // Connect using Socket to Selected Item
                                                                                        // 发送一条消息，防止断开
                var datab = GetBufferFromByteArray(Encoding.UTF8.GetBytes("0xff")); // Create Buffer/Packet for Sending
                await BTSock.OutputStream.WriteAsync(datab); // Send Arduino Buffer/Packet Message
                MessageBox.Show("蓝牙已连接成功"); // Allow commands to be sent via Command Button (Enabled)
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            Send q1 = new Send(BTSock);
            Receive q2 = new Receive(BTSock);
        }
        private void btnSendCommand_Click(object sender, RoutedEventArgs e)
        {
            // 发送消息
            BT2Arduino_Send("1");
        }

        private void btu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}