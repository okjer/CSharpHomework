using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100;
            bool[] vis = new bool[n+1];
            for (int i = 0; i < n; i++)
                vis[i] = true;
            vis[1] = false;
            int sn = (int)Math.Sqrt(n);
            for(int i = 2; i <= sn; i++)
            {
                if(vis[i] == true)
                {
                    int a = i*i;
                    while(a <= n)
                    {
                        vis[a] = false;
                        a += i;
                    }
                }
            }
            for(int i = 1; i <= n; i++)
            {
                if (vis[i])
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
