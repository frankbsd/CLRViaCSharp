using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter27
{
    class ThreadPoolTest
    {

        public static void TestExecutionContext()
        {
            CallContext.LogicalSetData("Name", "Jeffrey");
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Before SuppressFlow: Name={0}", CallContext.LogicalGetData("Name")));


            ExecutionContext.SuppressFlow();
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("SuppressFlow :Name={0}", CallContext.LogicalGetData("Name")));

            ExecutionContext.RestoreFlow();
            ThreadPool.QueueUserWorkItem(state => Console.WriteLine("RestoreFlow :Name={0}", CallContext.LogicalGetData("Name")));
        }

        public static void TestThreadPool()
        {
            Console.WriteLine("Main Thread: queuing an asyhnchronous operation");
            ThreadPool.QueueUserWorkItem(ComputeBoundOp, 5);
            Thread.Sleep(10);
            Console.WriteLine("Main thread: Doing other work here");
           
            Console.WriteLine("Hit Any Key to end this program……");

        }
        private static void ComputeBoundOp(object state)
        {
            Console.WriteLine("In computeBoundOp: state={0}", state);
            
        }
    }
}
