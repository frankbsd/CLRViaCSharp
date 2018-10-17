using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chapter27
{
    class CancellationTokenTest
    {
        public static void TestTaskReturn2()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<int> t = Task.Run(() => Sum2(cts.Token, 10000), cts.Token);
            cts.Cancel();
            try
            {
                Console.WriteLine("The sum is {0}",t.Result);
            }
            catch (AggregateException ex)
            {
                ex.Handle(e => e is OperationCanceledException);
                Console.WriteLine("Sum was canceled");
            }
        }

        public static void TestTaskReturn()
        {
            Task<int> t = new Task<int>(n => Sum((int)n), 100000);
            t.Start();
            t.Wait();
            Console.WriteLine("The sum is {0}",t.Result);
        }

        public static void Go()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 100));
            ThreadPool.QueueUserWorkItem(t => Count(cts.Token, 200));
            cts.Token.Register(Cancel);
            cts.Token.Register(Cancel2);
            Console.WriteLine("Hit any key to cancel the operation");
            Console.ReadKey();
            cts.Cancel();
        }

        private static void Count(CancellationToken token, int countTo)
        {
            for (int i = 0; i < countTo; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is cancelled");
                    break;
                }

                Console.WriteLine(i);
                Thread.Sleep(200);
            }

            Console.WriteLine("Count is done");
        }

        private static void Cancel()
        {
            Console.WriteLine(" Cancel()被调用");
            Console.WriteLine("线程ID={0}被取消了", Thread.CurrentThread.ManagedThreadId);
        }

        private static void Cancel2()
        {
            Console.WriteLine("Cancel2()被调用");
            Console.WriteLine("线程ID={0}被取消了", Thread.CurrentThread.ManagedThreadId);
        }


        public static int Sum(int n)
        {
            int sum = 0;
            for (; n > 0; n--)
                checked
                {
                    sum += n;
                }
            return sum;
        }


        public static int Sum2(CancellationToken ct,int n)
        {
            int sum = 0;
            for (; n > 0; n--)
            {
                ct.ThrowIfCancellationRequested();
                checked
                {
                    sum += n;
                }
            }

            return sum;
        }
    }


}
