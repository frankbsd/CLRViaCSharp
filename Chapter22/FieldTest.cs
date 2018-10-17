using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter22
{
    public sealed class FieldTest
    {

        public static void FieldTestMethod()
        {
            const int count = 100000000;
            NonMBRO nonMBRO = new NonMBRO();
            MBRO mBRO = new MBRO();

            Stopwatch sw = Stopwatch.StartNew();
            for (int c = 0; c < count; c++)
            {
                nonMBRO.x++;
            }
            Console.WriteLine("{0}",sw.Elapsed);


            sw = Stopwatch.StartNew();
            for (int c = 0; c < count; c++)
            {
                mBRO.x++;
            }
            Console.WriteLine("{0}", sw.Elapsed);

        }
    }

    sealed class NonMBRO : Object { public int x; }
    sealed class MBRO : MarshalByRefObject { public int x; }
}
