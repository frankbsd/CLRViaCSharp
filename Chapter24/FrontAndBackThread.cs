using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter24
{
    class FrontAndBackThread
    {

        public static void TestFrontAndBackThread()
        {
            Thread t = new Thread(Worker);

            t.IsBackground = true;
            t.Start();
            Console.WriteLine("Returning from Main");
        }
        private static void Worker()
        {
            Thread.Sleep(10000);
            Console.WriteLine("Running from worker");
        }
    }


}
