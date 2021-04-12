using System;
using System.Linq;

namespace acmicpc.net.Problems.BruteForce
{
    //부분합
    //두 포인터
    public class P001806
    {
        public static void Main(string[] args)
        {
            int[] a = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int n = a[0];
            int s = a[1];

            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int ans = int.MaxValue;

            int total = p.Sum();
            if (p.Sum() < s)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                int count = 0;
                for (int j = i; j < n; j++)
                {
                    if (count >= ans)
                        break;

                    sum += p[j];
                    count++;

                    if (sum >= s)
                    {
                        ans = Math.Min(ans, count);
                        break;
                    }
                }
            }

            Console.WriteLine(ans == int.MaxValue ? 0 : ans);
        }
    }
}