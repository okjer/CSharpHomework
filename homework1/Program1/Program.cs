using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please input some numbers,end with 0");
            int[] a = new int[100];
            int x = Convert.ToInt32(Console.Read()),len = 0;
            while (x != 0)
            {
                a[len++] = x;
                x = Convert.ToInt32(Console.Read());
            }
            int maxn = a[0], mixn = a[0], sum = 0;
            for(int i = 0; i < len; i++)
            {
                sum += a[i];
                maxn = Math.Max(maxn, a[i]);
                mixn = Math.Min(mixn, a[i]);

            }
            //a = double.Parse(Console.ReadLine());
            //Console.Write("b = ");
            //b = double.Parse(Console.ReadLine());
            //c = a * b;
            //Console.WriteLine("a * b = {0}", c);
        }
    }
}
