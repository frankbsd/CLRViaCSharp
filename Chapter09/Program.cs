using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter09
{
    class Program
    {
        static void Main(string[] args)
        {
            //String s1 = "Jeffrey";
            //String s2 = "Richter";
            //Console.WriteLine($"s1={s1},s2={s2}");
            //Swap(ref s1, ref s2);
            //Console.WriteLine($"s1={s1},s2={s2}");

            Console.WriteLine(Add(new Int32[] { 1, 2, 3, 4, 5 }));
            //Console.WriteLine(Add(1,2,3,4,5));
            DisplayTypes(new Object(), new Random(), "Jeff", 5);
            var result = String.Concat("ok", "test");
            Console.WriteLine(result);
            Console.ReadKey();


        }

       

        public static void Swap<T>(ref T a, ref T b)
        {
            T t = b;
            b = a;
            a = t;
        }

        static Int32 Add(params Int32[] values)
        {
            Int32 sum = 0;
            if (values != null)
                for (Int32 i = 0; i < values.Length; i++)
                {
                    sum += values[i];
                }

            return sum;
        }

        private static void DisplayTypes(params Object[] objects)
        {
            if (objects != null)
                foreach (var o in objects)
                {
                    Console.WriteLine(o.GetType());
                }
        }
    }
}
