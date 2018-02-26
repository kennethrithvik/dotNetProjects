using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread1
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Main Thread";
            Console.WriteLine(Thread.CurrentThread.Name+" has a thread id "+Thread.CurrentThread.ManagedThreadId);
            Thread t1, t2;
            ThreadStart ts1,ts2;
            ParameterizedThreadStart pts1;

            t1=new Thread(new ThreadStart(Task1));
            t1.Name = "Worker1";
            t1.Priority = ThreadPriority.Normal;
            t1.Start();

            t2=new Thread(Task2);
            t2.Name = "Worker2";
            t2.Priority = ThreadPriority.AboveNormal;
            t2.Start();

            t1.Join();
            t2.Join();
            Console.WriteLine("End of main");
            Console.ReadLine();
        }

        static void Task1()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " has a thread id " + Thread.CurrentThread.ManagedThreadId+" in task 1");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " i:-" + i);
            }
        }

        static void Task2()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " has a thread id " + Thread.CurrentThread.ManagedThreadId + " in task 2");
            for (int i = 100; i > 0; i--)
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId+" i:-"+i);
            }
        }
    }
}
