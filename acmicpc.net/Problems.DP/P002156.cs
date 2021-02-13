using System;
using System.Linq;

namespace acmicpc.net.Problems.DP
{
    //포도주 시식
    public class P002156
    {
        private static int[][] Memo;
        private const int Max = 2;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] volume = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                volume[i] = int.Parse(Console.ReadLine());
            }

            Memo = new int[n + 1][];
            Solve1(n, volume);
        }

        private static void Solve1(int n, int[] volume)
        {
            for (int i = 1; i <= n; i++)
            {
                Memo[i] = new int[Max + 1];

                if (i == 1)
                {
                    Memo[i][1] = Math.Max(Memo[i][1], volume[i]);
                    continue;
                }

                for (int j = 0; j <= Max; j++)
                {
                    if (j == 0)
                    {
                        Memo[i][j] = Memo[i - 1].Max();
                    }
                    else if (j == 1 || Memo[i - 1][j - 1] > 0)
                    {
                        Memo[i][j] = volume[i] + Memo[i - 1][j - 1];
                    }
                }
            }

            Console.WriteLine(Memo[n].Max());
        }
    }
}