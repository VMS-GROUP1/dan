using System;

namespace acmicpc.net.Problems.Greedy
{
    public class P002875
    {
        public static void Main(string[] args)
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int n = data[0];
            int m = data[1];
            int k = data[2];
            int ans = 0;

            int x = n / 2;
            if (m >= x)
            {
                ans = x;
                k -= m - x;
                k -= n % 2;
                if (k > 0)
                {
                    ans -= (k / 3) + (k % 3 > 0 ? 1 : 0);
                }
            }
            else
            {
                ans = m;
                k -= n - 2 * m;
                if (k > 0)
                {
                    ans -= (k / 3) + (k % 3 > 0 ? 1 : 0);
                }
            }

            Console.WriteLine(ans);
        }
    }
}