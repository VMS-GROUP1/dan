using System;
using System.IO;
using System.Text;

namespace acmicpc.net.Problems.DD
{
    public class P001992
    {
        private static int[,] m;
        private static StringBuilder sb = new StringBuilder(8_000);

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

            using (var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                Quad(0, 0, n);
                sw.Write(sb);
            }
        }

        private static void Quad(int r, int c, int n)
        {
            int sum = 0;
            for (int i = r; i < r + n; i++)
            {
                for (int j = c; j < c + n; j++)
                {
                    sum += m[i, j];
                }
            }

            if (sum == 0 || sum == n * n)
            {
                sb.Append(m[r, c]);
                return;
            }

            sb.Append('(');
            int half = n / 2;
            Quad(r, c, half);
            Quad(r, c + half, half);
            Quad(r + half, c, half);
            Quad(r + half, c + half, half);
            sb.Append(')');
        }
    }
}