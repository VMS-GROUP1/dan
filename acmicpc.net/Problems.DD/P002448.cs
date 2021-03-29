using System;
using System.IO;
using System.Text;

namespace acmicpc.net.Problems.DD
{
    public class P002448
    {
        private static int size = 6_143;
        private static StringBuilder[] m;
        private static char whiteSpace = ' ';
        private static string[] a = { "  *  ", " * * ", "*****" };
        private static string b = "   ";
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            m = new StringBuilder[n];
            Draw(0, n);
            using (var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                for (int i = 0; i < m.Length; i++)
                {
                    sw.WriteLine(m[i]);
                }
            }
        }

        private static void Draw(int r, int n)
        {
            if (n == 3)
            {
                Draw1(r);
                return;
            }

            for (int i = r; i < r + n; i += n / 2)
            {
                if (i == r)
                {
                    Draw2(r, n / 2);
                    Draw(r, n / 2);
                    Draw2(r, n / 2);
                    continue;
                }

                Draw(i, n / 2);
                Draw3(i, n / 2);
                Draw(i, n / 2);
            }
        }

        private static void Draw1(int r)
        {
            for (int i = 0; i < 3; i++)
            {
                if (m[r + i] == null)
                    m[r + i] = new StringBuilder(size);

                m[r + i].Append(a[i]);
            }
        }

        private static void Draw2(int r, int n)
        {
            for (int i = r; i < r + n; i++)
            {
                if (m[i] == null)
                    m[i] = new StringBuilder(size);

                for (int j = 0; j < n / 3; j++)
                {
                    m[i].Append(b);
                }
            }
        }

        private static void Draw3(int r, int n)
        {
            for (int i = r; i < r + n; i++)
            {
                m[i].Append(whiteSpace);
            }
        }
    }
}