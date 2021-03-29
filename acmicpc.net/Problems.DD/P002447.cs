using System;
using System.IO;
using System.Text;

namespace acmicpc.net.Problems.DD
{
    public class P002447
    {
        private static int size = 6_561;
        private static StringBuilder[] m;
        private static char asterisk = '*';
        private static char whiteSpace = ' ';
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            m = new StringBuilder[n];
            Draw(0, 0, n);
            using (var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                for (int i = 0; i < m.Length; i++)
                {
                    sw.WriteLine(m[i]);
                }
            }
        }

        private static void Draw(int r, int c, int n)
        {
            if (n == 3)
            {
                Draw1(r, c);
                return;
            }

            for (int i = r; i < r + n; i += n / 3)
            {
                for (int j = c; j < c + n; j += n / 3)
                {
                    if (i == r + n / 3 && j == c + n / 3)
                    {
                        Draw2(i, j, n / 3);
                        continue;
                    }

                    Draw(i, j, n / 3);
                }
            }
        }

        private static void Draw1(int r, int c)
        {
            for (int i = r; i < r + 3; i++)
            {
                if (m[i] == null)
                    m[i] = new StringBuilder(size);

                for (int j = c; j < c + 3; j++)
                {
                    if (i == r + 1 && j == c + 1)
                    {
                        m[i].Append(whiteSpace);
                        continue;
                    }

                    m[i].Append(asterisk);
                }
            }
        }

        private static void Draw2(int r, int c, int n)
        {
            for (int i = r; i < r + n; i++)
            {
                if (m[i] == null)
                    m[i] = new StringBuilder(size);

                for (int j = c; j < c + n; j++)
                {
                    m[i].Append(whiteSpace);
                }
            }
        }
    }
}