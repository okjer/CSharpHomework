using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("input numbers > 0,split with ' '");
            Console.WriteLine("Such as 1 2 3 8 9 10");
            List<int> a = new List<string>(Console.ReadLine().Split()).ConvertAll(i => int.Parse(i));
            int len = a.Count();
            for(int i = 0; i < len; i++)
            {
                int tmp = a[i];
                if (a[i] == 1) Console.WriteLine("1 = 1");
                else
                {
                    Console.Write(tmp + " = ");
                    int first = 1;
                    while (true)
                    {
                        int b = daydayup(tmp);
                        tmp /= b;
                        if (first == 1)
                        {
                            first = 0;
                            Console.Write(b );
                        }
                        else
                        {
                            Console.Write(" x " + b);
                        }
                        if (tmp == 1)
                        {
                            Console.WriteLine();
                            break;
                        }
                    }
                }
            }
        }
        static int daydayup(int a)
        {
            for (int i = 2; i <= a; i++)
            {
                if (a % i == 0) return i;
            }
            return 0;
        }
    }
}
