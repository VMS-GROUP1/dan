using System;

namespace acmicpc.net.Problems.DP
{
    public class P011057
    {
        private const int Size = 1001;
        private const int Num = 10;
        private const int Const = 10_007;
        private static int[,] Memo;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Solve1(n);
        }

        private static void Solve1(int n)
        {
            Memo = new int[Size, Num];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < Num; j++)
                {
                    if (i == 1)
                    {
                        Memo[i, j] = 1;
                        continue;
                    }

                    for (int k = 0; k <= j; k++)
                    {
                        Memo[i, j] = (Memo[i, j] + Memo[i - 1, k]) % Const;
                    } 
                }
            }

            int x = 0;
            for (int i = 0; i < Num; i++)
            {
                x = (x + Memo[n, i]) % Const;
            }

            Console.WriteLine(x);
        }
    }
}