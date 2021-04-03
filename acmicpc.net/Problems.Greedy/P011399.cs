using System;
using System.Linq;

namespace acmicpc.net.Problems.Greedy
{
    public class P011399
    {
        public static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());
            short[] time = Array.ConvertAll(Console.ReadLine().Split(), x => short.Parse(x));
            Array.Sort(time);

            int ans = 0;
            int wait = 0;
            short i = 0;
            while (i < n)
            {
                wait += time[i++];
                ans += wait;
            }

            Console.WriteLine(ans);
        }
    }
}