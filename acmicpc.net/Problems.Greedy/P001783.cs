using System;
using System.Linq;

namespace acmicpc.net.Problems.Greedy
{
    public class P001783
    {
        public static void Main(string[] args)
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int n = data[0];
            int m = data[1];
            int ans = 0;

            if (n == 0 || m == 0)
            {
                ans = 0;
            }
            else if (n == 1)
            {
                ans = 1;
            }
            else if (n == 2)
            {
                ans = Math.Min(4, Math.Max(1, (m + 1) / 2));
            }
            else if (m < 7)
            {
                ans = Math.Min(4, m);
            }
            else
            {
                ans = m - 2;
            }

            Console.WriteLine(ans);
        }
    }
}