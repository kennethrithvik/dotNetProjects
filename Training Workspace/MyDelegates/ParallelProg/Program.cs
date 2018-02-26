using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ParallelProg
{
    class Program
    {
        static void Main(string[] args)
        {
            //ParallelFor();
            //RegularFor();






            Console.ReadLine();
        }

        static void ParallelFor()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Action<int> myaction = new Action<int>(BigWork);
            Parallel.For(0, 5, myaction);
            sw.Stop();
            Console.WriteLine("time taken " + sw.Elapsed.Seconds);
        }
        static void BigWork(int i1)
        {
            long tot = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                tot += i;
            }
            Console.WriteLine("result= " + tot + " i:-" + i1);
        }

        //static void RegularFor()
        //{
        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        long ret = BigWork();
        //        Console.WriteLine("Value {0}, iteration {1}", ret, i);
        //    }
        //    sw.Stop();
        //    Console.WriteLine("time taken " + sw.Elapsed.Seconds);
        //}

        //static long BigWork()
        //{
        //    long tot = 0;
        //    for (int i = 0; i < 1000000000; i++)
        //    {
        //        tot += i;
        //    }
        //    return tot;
        //}
    }
}
