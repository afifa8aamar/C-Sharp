//sln

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
