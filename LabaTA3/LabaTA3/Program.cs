using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaTA3
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tree1 = new Tree<int>();
            Tree<int> tree2 = new Tree<int>();
            Stopwatch sw = new Stopwatch();
            TimeSpan all;

            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                tree1.Insert(i);
            }
            sw.Stop();
            TimeSpan insertTime1 = sw.Elapsed;
            all = insertTime1;
            Random r = new Random();
            int[] arr = new int[1000];
            for(int i = 0; i < 1000;)
            {
                int temp = r.Next(10000);
                if(!arr.Contains(temp) && temp != 0)
                {
                    arr[i] = temp;
                    i++;
                }
            }
            sw.Start();
            for(int i = 0; i < 1000; i++)
            {
                tree2.Insert(arr[i]);
            }
            sw.Stop();
            TimeSpan insertTime2 = sw.Elapsed - all;
            all += insertTime2;
            sw.Start();
            tree1.Contains(r.Next(1000), false);
            sw.Stop();
            TimeSpan containsTime1 = sw.Elapsed - all;
            all += containsTime1;
            sw.Start();
            tree1.Balance();
            sw.Stop();
            TimeSpan balanceTime1 = sw.Elapsed - all;
            all += balanceTime1; 
            sw.Start();
            tree2.Balance();
            sw.Stop();
            TimeSpan balanceTime2 = sw.Elapsed - all;
            all += balanceTime2;
            sw.Start();
            tree1.Contains(r.Next(1000), false);
            sw.Stop();
            TimeSpan containsTime2 = sw.Elapsed - all;
            all += containsTime2;
            Console.WriteLine("insert: "+insertTime1);
            Console.WriteLine("insert random: "+insertTime2);
            Console.WriteLine("contains: "+containsTime1);
            Console.WriteLine("contains balanced: "+containsTime2);
            Console.WriteLine("balance: "+balanceTime1);
            Console.WriteLine("balance random: "+balanceTime2);

            Console.ReadLine();
        }
    }
}
