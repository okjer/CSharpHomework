using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input numbers > 0,split with ' '");
            Console.WriteLine("Such as \"1 2 3 8 9 10\"");
            List<double> a = new List<string>(Console.ReadLine().Split()).ConvertAll(i => double.Parse(i));
            int len = a.Count();
            double maxn = a[0], mixn = a[0], sum = 0;
            for(int i = 0; i < len; i++)
            {
                maxn = Math.Max(maxn, a[i]);
                mixn = Math.Min(mixn, a[i]);
                sum += a[i];
            }
            double tmp = sum / len;
            Console.WriteLine("the max number,min number,sum number,average number is");
            Console.WriteLine(maxn + " " + mixn + " " + sum + " " + Math.Round(tmp));
        }
    }
}
