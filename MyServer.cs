using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace MyServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket srv;
            srv = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPEndPoint ep = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 5000);
            srv.Bind(ep);
            srv.Listen(10);
            Socket cnt = srv.Accept();
            byte[] buffer = new byte[4096];
            int n = cnt.Receive(buffer);
            string txt = Encoding.UTF8.GetString(buffer, 0, n);
            StringBuilder sb = new StringBuilder(txt);
            sb.Replace('a', '@');
            sb.Replace('o', '0');
            txt = sb.ToString();
            byte[] bt = Encoding.UTF8.GetBytes(txt);
            cnt.Send(bt);
            cnt.Close();
            srv.Close();
        }
    }
}
