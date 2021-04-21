using System;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001451
    {
        private static int N;
        private static int M;
        private static int[,] Rect;
        private static long[,] Sum;
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            N = p[0];
            M = p[1];

            Rect = new int[N, M];
            Sum = new long[N, M];

            for (int i = 0; i < N; i++)
            {
                p = Array.ConvertAll(Console.ReadLine().ToCharArray(), x => x - '0');
                for (int j = 0; j < M; j++)
                {
                    Rect[i, j] = p[j];
                }
            }

            Console.WriteLine(Do());
        }

        private static long Do()
        {
            for (int i = 0; i < N; i++)
            {
                long sum = 0;

                for (int j = 0; j < M; j++)
                {
                    sum += Rect[i, j];

                    if (i > 0)
                    {
                        Sum[i, j] += sum + Sum[i - 1, j];
                    }
                    else
                    {
                        Sum[i, j] = sum;
                    }
                }
            }

            long ans = long.MinValue;

            for (int col1 = 0; col1 < M - 2; col1++)
            {
                long a = Sum[N - 1, col1];
                for (int col2 = 1; col2 < M - 1; col2++)
                {
                    long b = Sum[N - 1, col2] - a;
                    long c = Sum[N - 1, M - 1] - b - a;
                    long temp = a * b * c;
                    ans = Math.Max(ans, temp);
                }
            }

            for (int row1 = 0; row1 < N - 2; row1++)
            {
                long a = Sum[row1, M - 1];
                for (int row2 = 1; row2 < N - 1; row2++)
                {
                    long b = Sum[row2, M - 1] - a;
                    long c = Sum[N - 1, M - 1] - b - a;
                    long temp = a * b * c;
                    ans = Math.Max(ans, temp);
                }
            }

            for (int col = 0; col < M - 1; col++)
            {
                long a = Sum[N - 1, col];
                for (int row = 0; row < N - 1; row++)
                {
                    long b = Sum[row, M - 1] - Sum[row, col];
                    long c = Sum[N - 1, M - 1] - a - b;
                    long temp = a * b * c;
                    ans = Math.Max(ans, temp);
                }
            }

            for (int col = 0; col < M - 1; col++)
            {
                for (int row = 0; row < N - 1; row++)
                {
                    long b = Sum[row, col];
                    long c = Sum[N - 1, col] - b;
                    long a = Sum[N - 1, M - 1] - b - c;
                    long temp = a * b * c;
                    ans = Math.Max(ans, temp);
                }
            }

            for (int row = 0; row < N - 1; row++)
            {
                for (int col = 0; col < M - 1; col++)
                {
                    long b = Sum[row, col];
                    long c = Sum[row, M - 1] - b;
                    long a = Sum[N - 1, M - 1] - b - c;
                    long temp = a * b * c;
                    ans = Math.Max(ans, temp);
                }
            }

            for (int row = 0; row < N - 1; row++)
            {
                long a = Sum[row, M - 1];
                for (int col = 0; col < M - 1; col++)
                {
                    long b = Sum[N - 1, col] - Sum[row, col];
                    long c = Sum[N - 1, M - 1] - a - b;
                    long temp = a * b * c;
                    ans = Math.Max(ans, temp);
                }
            }

            return ans;
        }
    }
}