using System;
using System.Linq;

namespace acmicpc.net.Problems.DP
{
    public class P009465
    {
        private static int[][] Memo;
        private const int NumOfRows = 2;
        public static void Main(string[] args)
        {
            int cases = int.Parse(Console.ReadLine());

            for (int t = 0; t < cases; t++)
            {
                int numOfColumns = int.Parse(Console.ReadLine());
                var firstRow = Console.ReadLine().Split();
                var secondRow = Console.ReadLine().Split();
                int[,] point = new int[numOfColumns + 1, NumOfRows];    
                for (int column = 1; column <= numOfColumns; column++)
                {
                    point[column, 0] = int.Parse(firstRow[column - 1]);
                    point[column, 1] = int.Parse(secondRow[column - 1]);
                }

                Solve1(numOfColumns, point);
            }
        }

        private static void Solve1(int n, int[,] point)
        {
            Memo = new int[n + 1][];

            for (int i = 1; i <= n; i++)
            {
                Memo[i] = new int[NumOfRows + 1];
                
                for (int j = 0; j <= NumOfRows; j++)
                {
                    Memo[i][j] = j > 0 ? point[i, j - 1] : 0;

                    if (i == 1)
                        continue;

                    if (j == 0)
                    {
                        Memo[i][j] += Memo[i - 1].Max();
                    }

                    if (j == 1)
                    {
                        Memo[i][j] += Math.Max(Memo[i - 1][0], Memo[i - 1][2]);
                    }

                    if (j == 2)
                    {
                        Memo[i][j] += Math.Max(Memo[i - 1][0], Memo[i - 1][1]);
                    }
                }
            }

            Console.WriteLine(Memo[n].Max());
        }
    }
}