using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wintellect.AddInTypes;
using Wintellect.HostSDK;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            var ttt = new AddIn_A();
            IAddIn tttt;
            //string addInDir = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            //var addInAssemblies = Directory.EnumerateFiles(addInDir, "*.dll");

            //var addInTypes = from file in addInAssemblies
            //                 let assembly = Assembly.Load(file)
            //                 from t in assembly.ExportedTypes
            //                 where t.IsClass && typeof(IAddIn).GetTypeInfo().IsAssignableFrom(t.GetTypeInfo())
            //                 select t;

            //foreach (var t in addInTypes)
            //{
            //    IAddIn ai = (IAddIn)Activator.CreateInstance(t);
            //    Console.WriteLine(ai.DoSomething(5));
            //}

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var a in assemblies)
            {
                Show(0, "Assembly: {0}", a);

                foreach (var t in a.ExportedTypes)
                {
                    Show(1, "Type: {0}", t);

                    foreach (var mi in t.GetTypeInfo().DeclaredMembers)
                    {
                        string typeName = string.Empty;
                        if (mi is Type) typeName = "(Nested) Type";
                        if (mi is FieldInfo) typeName = "FieldInfo";
                        if (mi is MethodInfo) typeName = "MethodInfo";
                        if (mi is ConstructorInfo) typeName = "ConstructorInfo";
                        if (mi is PropertyInfo) typeName = "PropertyInfo";
                        if (mi is EventInfo) typeName = "EventInfo";

                        Show(2, "{0}:{1}", typeName, mi);
                    }
                }


            }

            Console.ReadKey();
        }


        private static void Show(int indent, string format, params object[] args)
        {
            Console.WriteLine(new string(' ', 3 * indent) + format, args);
        }
    }
}
