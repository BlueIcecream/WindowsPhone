using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace Store
{
    class Receive
    {
        static StreamSocket BTSock;
        static int[] s1 = new int[4];        
        static int a = 0;
        public Receive(StreamSocket BTSock1)
        {
            BTSock = BTSock1;
        }
       
        public static async Task Ss()
        {
            
            Byte[] b1 = new Byte[1024];
            IBuffer buffer1 = WindowsRuntimeBufferExtensions.AsBuffer(b1, 0, b1.Length);            
            //DataReader dr = new DataReader(BTSock.InputStream);            
            await BTSock.InputStream.ReadAsync(buffer1, buffer1.Capacity, InputStreamOptions.Partial);           
            byte[] bytes = WindowsRuntimeBufferExtensions.ToArray(buffer1, 0, (int)buffer1.Length);                                 
            s1[a] = bytes[0]-48;                
            return ;         
        }       
        public static int Res()
        {            
            return s1[0] * 1000 + s1[1] * 100 + s1[2] * 10 + s1[3];
        }
       
        public async static Task Ret()
        {       
            await Ss();a++; 
            await Ss();a++;
            await Ss();a++;
            await Ss();
            a = 0;
            //MessageBox.Show(s1[0] * 1000 + s1[1] * 100 + s1[2] * 10 + s1[3]+"|"+a);
            return ;                               
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
