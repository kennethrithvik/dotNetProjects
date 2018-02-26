using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyDelegates
{
    delegate long MathDelegate(int n1, int n2);

    delegate void MyDelegate();
    class MathClass
    {

        public long Add(int n1, int n2)
        {
            Console.WriteLine("Add:- "+System.Threading.Thread.CurrentThread.ManagedThreadId);
            return n1 + n2;
        }

        public static long Multiply(int n1, int n2)
        {
            //System.Threading.Thread.Sleep(10000);
            return n1*n2;
        }
        public  void M1()
        {
            Console.WriteLine("M1");
        }

        public static void M2()
        {
            Console.WriteLine("m2");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);

            MathClass mat=new MathClass();
            MathDelegate del1, del2;

            del2=new MathDelegate(MathClass.Multiply);
            //Invoke(del2);

            //List<string> mystrings = new List<string>();
            //mystrings.Add("monday");
            //mystrings.Add("tuesday");
            //mystrings.Add("wednesday");
            //mystrings.Add("thursday");
            //mystrings.Add("friday");

            //Action<string> myaction = new Action<string>(Print);
            //mystrings.ForEach(myaction);

            //MyDelegate multicast;
            //multicast=new MyDelegate(mat.M1);
            //multicast+=new MyDelegate(MathClass.M2);
            //multicast.Invoke();


            del1 = new MathDelegate(mat.Add);
            //Console.WriteLine(del1.Invoke(111,99));
            IAsyncResult iar = del1.BeginInvoke(11,9,new AsyncCallback(Mycallback),del1 );

            ThreadPool.QueueUserWorkItem(M1);
            ThreadPool.QueueUserWorkItem(M1);
            ThreadPool.QueueUserWorkItem(M1);
            ThreadPool.QueueUserWorkItem(M2);


            Console.WriteLine("Main End");
            Console.ReadLine();
        }
        public static void M1(object obj)
        {
            Console.WriteLine("M1:- " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            //Thread.Sleep(1000);
        }

        public static void M2(object obj)
        {
            Console.WriteLine("M2:- " + System.Threading.Thread.CurrentThread.ManagedThreadId);
        }

        static void Mycallback(IAsyncResult ir)
        {
            MathDelegate d = ir.AsyncState as MathDelegate;
            long result = d.EndInvoke(ir);
            Console.WriteLine("result=" + result);
        }
        static void Print(string s )
        {
            Console.WriteLine(s);
        }

        static void Invoke(MathDelegate del)
        {
            Console.WriteLine(del.Invoke(111, 333));
        }
        
    }
}
