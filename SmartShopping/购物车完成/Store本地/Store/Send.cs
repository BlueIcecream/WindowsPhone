using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace Store
{
    
    class Send
    {
        static StreamSocket BTSock;

        public Send(StreamSocket BTSock1)
        {
            BTSock = BTSock1;
        }
        public  Send(String s)
        {
            Ss(s);
        }
        private async void Ss(String S)
        {
            if (BTSock != null) // Since we have a Connection
            {
                var datab = GetBufferFromByteArray(UTF8Encoding.UTF8.GetBytes(S)); // Create Buffer/Packet for Sending
                await BTSock.OutputStream.WriteAsync(datab); // 发送消息给连接者               
            }           
        }
        private IBuffer GetBufferFromByteArray(byte[] package)
        {
            using (DataWriter dw = new DataWriter())
            {
                dw.WriteBytes(package);
                return dw.DetachBuffer();
            }
        }
    }
    
}
