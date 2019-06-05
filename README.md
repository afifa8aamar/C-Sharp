# C-Sharp

loadmylib

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace LoadMyLib
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm;
            asm = Assembly.LoadFile(@);
     
            object f = asm.CreateInstance("MyLib.Myfraction",false,BindingFlags.CreateInstance, null, new object[] {3,4}, null, null);
            string text = f.ToString();
            Console.WriteLine(text);
        }
    }
}


my lib 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class MyFraction
    {

    }
}



------------------------


socket client 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket cnt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            IPEndPoint ep = new IPEndPoint(new IPAddress(new byte[] { 127, 0, 0, 1 }), 5000);
            cnt.Connect(ep);
            string txt = Console.ReadLine();
            byte[] bt = Encoding.UTF8.GetBytes(txt);
            cnt.Send(bt);
            byte[] buffer = new byte[4096];
            int n = cnt.Receive(buffer);
            txt = Encoding.UTF8.GetString(buffer, 0, n);
            Console.WriteLine(txt);
            cnt.Close();
        }
    }
}






-----------------------------------------------------


socket server 


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



-----------------------------------------------------------------------


my wcf app : Service1.svc



using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MyWcfApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public long SumOfDigits(long u)
        {
            long r = 0;
            while(u>0)
            {
                r = r + u % 10;
                u = u / 10;
            }


            return r;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
