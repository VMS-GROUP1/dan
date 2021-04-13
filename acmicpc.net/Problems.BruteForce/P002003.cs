using System;

namespace acmicpc.net.Problems.BruteForce
{
    //수들의 합 2
    public class P002003
    {
        private static int[] a;
        private static int n;
        private static int m;
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            n = p[0];
            m = p[1];
            a = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

            int ans = 0;
            int i = 0;
            int j = i;
            int sum = 0;

            while (i < n)
            {
                if (j == 0)
                    sum += a[j];

                if (sum == m)
                {
                    ans++;
                }

                if (j + 1 >= n || (sum > m && i < j))
                {
                    sum -= a[i++];
                }
                else
                {
                    j++;
                    sum += a[j];
                }
            }

            Console.WriteLine(ans);
        }
    }
}