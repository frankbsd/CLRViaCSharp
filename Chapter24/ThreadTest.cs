using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter24
{
    public sealed class ThreadTest
    {
        public static void TestThreadMethod()
        {
            Console.WriteLine("Main thread:starting a dedicated thread to do an asynchronous operation");
            Thread dedicatedThread = new Thread(ComputeBoundOp);
            dedicatedThread.Start(5);

            Console.WriteLine("Main Thread:Doing other work here");
            Thread.Sleep(10000);


            dedicatedThread.Join();

        }

        private static void ComputeBoundOp(object state)
        {
            Console.WriteLine("In ComputeBoundOp: state={0}", state);
            Thread.Sleep(1000);
        }
    }



}
