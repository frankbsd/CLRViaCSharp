using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ch03_02AboutAssemblyName
{
    class Program
    {
        static void Main(string[] args)
        {
            //注意：参数一定要包含扩展名
            AssemblyName assemblyName = AssemblyName.GetAssemblyName("Ch03_02AboutAssemblyName.exe");
            Console.WriteLine("CultureInfo:{0}", assemblyName.CultureInfo);
            Console.WriteLine("CultureName:{0}", assemblyName.CultureName);
            Console.WriteLine("FullName:{0}", assemblyName.FullName);
            Console.WriteLine("KeyPair:{0}", assemblyName.KeyPair);
            Console.WriteLine("Version:{0}", assemblyName.Version);
            Console.WriteLine("GetPublicKey:{0}", assemblyName.GetPublicKey());
            Console.WriteLine("GetPublicKeyToken:{0}", assemblyName.GetPublicKeyToken());
            byte[] testKey = new byte[20];
            assemblyName.SetPublicKey(new byte[20]);
            assemblyName.SetPublicKeyToken(new byte[30]);
            Console.WriteLine("******After set******");
            Console.WriteLine("GetPublicKey:{0}", assemblyName.GetPublicKey());
            Console.WriteLine("GetPublicKeyToken:{0}", assemblyName.GetPublicKeyToken());
            Console.ReadKey();
        }
    }
}
