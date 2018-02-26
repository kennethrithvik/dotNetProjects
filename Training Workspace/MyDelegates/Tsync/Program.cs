using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tsync
{
    class MyClass
    {

        private int counter;
        object obj=new object();
        AutoResetEvent arv = new AutoResetEvent(false);


        public void Increase()
        {
            Monitor.Enter(obj);
            int temp = 0;
            temp = counter;
            temp++;
            Thread.Sleep(1000);
            counter = temp;

            Console.WriteLine("the counter value {0}, thread id {1}",counter,Thread.CurrentThread.ManagedThreadId);
            Monitor.Exit(obj);

        }

        public void CountUp()
        {
            lock (obj)
            {//Monitor.Enter();

                do
                {
                    int temp = 0;
                    temp = counter;
                    temp++;
                    Thread.Sleep(100);
                    counter = temp;

                    Console.WriteLine("the counter value {0}, thread id {1}", counter, Thread.CurrentThread.ManagedThreadId);

                } while (counter <10);
                //Monitor.Pulse(obj);
                arv.Set();

            }//Monitor.Exit();
        }

        public void CountDown()
        {
            if (counter == 0)
            {
                Console.WriteLine("Counter is 0");
                //Monitor.Wait(obj);
                arv.WaitOne();
            }
            lock (obj)
            {
               
                do
                {
                    int temp = 0;
                    temp = counter;
                    temp--;
                    Thread.Sleep(100);
                    counter = temp;

                    Console.WriteLine("the counter value {0}, thread id {1}", counter, Thread.CurrentThread.ManagedThreadId);
                    
                } while (counter>0);
            }
            
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            MyClass c=new MyClass();
            Thread t1, t2;
            t1=new Thread(c.CountDown);
            t2 = new Thread(c.CountUp);
            t1.Start();t2.Start();

            Console.ReadLine();
        }
    }
}
