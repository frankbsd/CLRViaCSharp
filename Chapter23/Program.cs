using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Chapter23
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSerializeAndDeserialize();
            Singleton[] a1 = { Singleton.GetSingleton(), Singleton.GetSingleton() };
            Console.WriteLine("Do both elements refer to the same objects?" + (a1[0] == a1[1]));
            using (var stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, a1);
                stream.Position = 0;
                Singleton[] a2 = (Singleton[])formatter.Deserialize(stream);


                Console.WriteLine("Do both elements refer to the same object?" + (a2[0] == a2[1]));
                Console.WriteLine("Do all elements refer to the same object" + (a1[0] == a2[0]));
            }


            Console.ReadKey();
        }

        private static void TestSerializeAndDeserialize()
        {
            var objectGraph = new List<string> { "Jeff", "Kristin", "Aidan", "Grant" };
            Stream stream = SerializeToMemory(objectGraph);
            Console.WriteLine(stream);
            stream.Position = 0;
            objectGraph = null;

            objectGraph = (List<string>)DeserializeFromMemory(stream);
            foreach (var s in objectGraph) Console.WriteLine(s);
        }

        private static MemoryStream SerializeToMemory(object objectGraph)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, objectGraph);

            return stream;
        }


        private static object DeserializeFromMemory(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }
    }
}
