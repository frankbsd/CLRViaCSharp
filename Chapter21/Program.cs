using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter21
{
    class Program
    {
        static void Main(string[] args)
        {
            //Timer t = new Timer(TimerCallback, null, 0, 2000);

            ////Console.ReadLine();
            //Thread.Sleep(10000);
            //t.Dispose();
            ////Console.WriteLine("GC mode:"+GCSettings.IsServerGC);
            ////Console.WriteLine("GC Concurrent: "+GCSettings.LatencyMode);
            ////LowLatencyDemo();

            //Console.WriteLine(GC.CollectionCount(2));
            //Console.WriteLine(GC.GetTotalMemory(false));
            //Console.WriteLine(GC.GetTotalMemory(true));
            //Console.WriteLine(GC.MaxGeneration);
            HandleCollectorTest.Test();
            Console.ReadKey();

        }

        public static void TimerCallback(Object o)
        {
            Console.WriteLine("In TimerCallback: "+DateTime.Now);
            GC.Collect();
        }

        public static void LowLatencyDemo()
        {
            GCLatencyMode oldMode = GCSettings.LatencyMode;

            System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                GCSettings.LatencyMode = GCLatencyMode.LowLatency;
                Console.WriteLine("In GCLatencyMode.LowLatency ……");
                Console.WriteLine(GCSettings.LatencyMode);
            }
            finally 
            {
                GCSettings.LatencyMode = oldMode;
                Console.WriteLine("out GCLatencyMode.LowLatency ……");
                Console.WriteLine(GCSettings.LatencyMode);
            }
        }
    }
}
