using System;

namespace acmicpc.net.Problems.DP
{
    public class P002193
    {
        private const int Size = 91;
        private const int Num = 2;

        private static long[,] Memo;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Solve1(n);
        }

        private static void Solve1(int n)
        {
            Memo = new long[Size, Num];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < Num; j++)
                {
                    if (i == 1)
                    {
                        if (j != 0)
                        {
                            Memo[i, j] = 1;
                        }

                        continue;
                    }

                    Memo[i, j] = Memo[i - 1, 0];

                    if (j == 0)
                    {
                        Memo[i, j] += Memo[i - 1, 1];
                    }
                }
            }

            long x = 0;
            for (int i = 0; i < Num; i++)
            {
                x += Memo[n, i];
            }

            Console.WriteLine(x);
        }
    }
}