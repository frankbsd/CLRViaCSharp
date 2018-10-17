using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Chapter21
{
    public static class HandleCollectorTest
    {
        public static void Test()
        {
            MemoryPressureDemo(0);
            MemoryPressureDemo(10 * 1024 * 1024);

            HandleCollectorDemo();

            Console.ReadKey();
        }

        public static void MemoryPressureDemo(int size)
        {
            Console.WriteLine();
            Console.WriteLine("MemoryPressureDemo, size={0}", size);
            for (int i = 0; i < 15; i++)
            {
                new BigNativeResource(size);
            }

            GC.Collect();
        }


        private static void HandleCollectorDemo()
        {
            Console.WriteLine();
            Console.WriteLine("HandleCollectorDemo");
            for (int i = 0; i < 10; i++)
            {
                new LimitedResource();
            }

            GC.Collect();
        }


        private sealed class BigNativeResource
        {
            private int m_size;

            public BigNativeResource(int size)
            {
                m_size = size;
                if (m_size > 0) GC.AddMemoryPressure(m_size);
                Console.WriteLine("BigNativeResource create.");
            }


            ~BigNativeResource()
            {
                if (m_size > 0) GC.RemoveMemoryPressure(m_size);
                Console.WriteLine("BigNativeResource Destroy.");
            }
        }

        private sealed class LimitedResource
        {
            private static readonly HandleCollector s_hc = new HandleCollector("LimitedResource", 2);

            public LimitedResource()
            {
                s_hc.Add();
                Console.WriteLine("LimitedResource create. Count={0}",s_hc.Count);
            }

            ~LimitedResource()
            {
                s_hc.Remove();
                Console.WriteLine("LimitedResource destroy. Count={0}", s_hc.Count);
            }
        }
    }


}
