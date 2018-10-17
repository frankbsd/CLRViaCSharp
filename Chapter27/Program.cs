using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter27
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadPoolTest.TestThreadPool();
            //ThreadPoolTest.TestExecutionContext();
            //CancellationTokenTest.Go();
            //new Task(CancellationTokenTest.TestTaskReturn).Start();
            //CancellationTokenTest.TestTaskReturn2();

            Task<int> t = Task.Run(() => CancellationTokenTest.Sum2(CancellationToken.None, 5000));

            Task cwt = t.ContinueWith(task => Console.WriteLine("The sum is " + task.Result));
            Console.ReadKey();
        }
    }
}
