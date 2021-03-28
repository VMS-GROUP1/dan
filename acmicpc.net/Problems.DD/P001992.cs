using System;
using System.IO;
using System.Text;

namespace acmicpc.net.Problems.DD
{
    public class P001992
    {
        private static int[,] m;
        private static StringBuilder sb = new StringBuilder(11_000);

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            m = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var k = Console.ReadLine();
                for (int j = 0; j < k.Length; j++)
                {
                    m[i, j] = k[j] - '0';
                }
            }

            Quad(0, 0, n);
            Console.WriteLine(sb);
        }

        private static void Quad(int r, int c, int n)
        {
            if (Check(r, c, n))
            {
                sb.Append(m[r, c]);
                return;
            }

            int half = n / 2;
            sb.Append('(');
            Quad(r, c, half);
            Quad(r, c + half, half);
            Quad(r + half, c, half);
            Quad(r + half, c + half, half);
            sb.Append(')');
            return;
        }

        private static bool Check(int r, int c, int n)
        {
            if (n == 1)
            {
                return true;
            }

            for (int i = r; i < r + n; i++)
            {
                for (int j = c; j < c + n; j++)
                {
                    if (m[r, c] != m[i, j])
                        return false;
                }
            }

            return true;
        }
    }
}