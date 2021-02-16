using System;
using System.Linq;

namespace acmicpc.net.Problems.DP
{
    //카드 구매하기
    public class P011052
    {
        private static int[] Memo;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] p = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Solve1(n, p);
        }

        private static void Solve1(int n, int[] p)
        {
            Memo = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    Memo[i] = Math.Max(Memo[i], Memo[i - j] + p[j - 1]);
                }

                Memo[i] = Math.Max(Memo[i], p[i - 1]);
            }

            Console.WriteLine(Memo[n]);
        }
    }
}