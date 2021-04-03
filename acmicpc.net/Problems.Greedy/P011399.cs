using System;
using System.Linq;

namespace acmicpc.net.Problems.Greedy
{
    public class P011399
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] time = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            Array.Sort(time);

            int ans = 0;
            int wait = 0;
            int i = 0;
            while (i < n)
            {
                wait += time[i++];
                ans += wait;
            }

            Console.WriteLine(ans);
        }
    }
}