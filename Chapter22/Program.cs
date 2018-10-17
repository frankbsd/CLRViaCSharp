using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wintellect.HostSDK;

namespace Chapter22
{
    class Program
    {
        static void Main(string[] args)
        {
            //Marshalling();
            //FieldTest.FieldTestMethod();
            //SpeedTest();
            //LoadAssembly();

            //NewMethod();

            string addInDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            var addInAssemblies = Directory.EnumerateFiles(addInDir, "*.dll");

            var addInTypes = from file in addInAssemblies
                             let assembly = Assembly.Load(file)
                             from t in assembly.ExportedTypes
                             where t.IsClass && typeof(IAddIn).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo())
                             select t;

            foreach (var t in addInTypes)
            {
                IAddIn ai = (IAddIn)Activator.CreateInstance(t);
                Console.WriteLine(ai.DoSomething(5));
            }

            Console.ReadKey();
        }

        private static void NewMethod()
        {
            string path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);
            path = Path.Combine(path, @"Log.dll");

            Assembly assembly = Assembly.LoadFile(path);
            Console.WriteLine(assembly.FullName);
            LoadAssemblyAndShowPublicTypes(assembly.FullName);
        }

        public static void LoadAssembly()
        {
            string dataAssembly = "System.Data,version=4.0.0.0,culture=neutral,PublicKeyToken=b77a5c561934e089";
            LoadAssemblyAndShowPublicTypes(dataAssembly);
        }

        private static void LoadAssemblyAndShowPublicTypes(string asssmId)
        {
            Assembly a = Assembly.Load(asssmId);
            foreach (var item in a.ExportedTypes)
            {
                Console.WriteLine(item.FullName);

           

                Console.WriteLine("\t成员有:");
                var members = item.GetMembers();
                for (int i = 0; i < members.Count(); i++)
                {
                    Console.WriteLine(members[i].Name);
                    Console.WriteLine(members[i].DeclaringType);

                }
            }
        }

        private static void SpeedTest()
        {
            using (new AppDomainMonitorDelta(null))
            {
                var list = new List<object>();
                for (int i = 0; i < 1000; i++)
                {
                    list.Add(new byte[10000]);
                }
                for (int i = 0; i < 2000; i++)
                {
                    new byte[10000].GetType();
                }

                Int64 stop = Environment.TickCount + 5000;
                while (Environment.TickCount < stop) ;
            }
        }

        private static void Marshalling()
        {
            AppDomain adCallingThreadDomain = Thread.GetDomain();

            string callingDomainName = adCallingThreadDomain.FriendlyName;
            Console.WriteLine("Default AppDomain's friendly name={0}", callingDomainName);

            string exeAssembly = Assembly.GetEntryAssembly().FullName;
            Console.WriteLine("Main assembly={0}", exeAssembly);

            AppDomain ad2 = null;
            Console.WriteLine("{0}Demo #1", Environment.NewLine);

            ad2 = AppDomain.CreateDomain("AD #2", null, null);
            MarshalByRefType mbrt = null;

            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "Chapter22.MarshalByRefType");

            Console.WriteLine("Type={0}", mbrt.GetType().ToString());


            Console.WriteLine("Is proxy={0}", RemotingServices.IsTransparentProxy(mbrt));

            mbrt.SomeMethod();

            AppDomain.Unload(ad2);

            try
            {
                mbrt.SomeMethod();
                Console.WriteLine("Successful call.");
            }
            catch (AppDomainUnloadedException)
            {
                Console.WriteLine("Failed call.");
            }


            Console.WriteLine("{0}Deomo #2", Environment.NewLine);
            ad2 = AppDomain.CreateDomain("AD #2", null, null);

            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "Chapter22.MarshalByRefType");

            MarshalByValType mbvt = mbrt.MethodWithReturn();

            Console.WriteLine("Is proxy={0}", RemotingServices.IsTransparentProxy(mbvt));
            Console.WriteLine("Returned object created " + mbvt.ToString());

            AppDomain.Unload(ad2);

            try
            {
                Console.WriteLine("Returned object created " + mbvt.ToString());
            }
            catch (AppDomainUnloadedException)
            {
                Console.WriteLine("Failed call");
            }



            Console.WriteLine("{0}Demo #3", Environment.NewLine);

            ad2 = AppDomain.CreateDomain("AD #2", null, null);
            mbrt = (MarshalByRefType)ad2.CreateInstanceAndUnwrap(exeAssembly, "Chapter22.MarshalByRefType");


            NonMarshalableType nmt = mbrt.MethodArgAndReturn(callingDomainName);
            Console.WriteLine("返回不可封送对象");


        }
    }
}
