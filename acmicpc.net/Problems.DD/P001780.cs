using System;
using System.IO;
using System.Text;

namespace acmicpc.net.Problems.DD
{
    public class P001780
    {
        private static int[] Count = new int[3];
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //int[][] m = new int[n][];
            int[,] m = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var k = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                for (int j = 0; j < k.Length; j++)
                {
                    m[i, j] = k[j];
                }
            }

            int r = n;
            int c = r;
            int[,] m1 = m;
            int[,] m2 = new int[r / 3, r / 3];

            while (r >= 3)
            {
                for (int i = 0; i < r; i += 3)
                {
                    for (int j = 0; j < r; j += 3)
                    {
                        m2[i / 3, j / 3] = Check(i, j, m1);
                    }
                }

                r /= 3;
                c = r;
                m1 = m2;
                m2 = new int[r / 3, r / 3];
            }

            if (m1[0, 0] < 3)
            {
                Count[m1[0, 0] + 1]++;
            }

            using (var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                sw.Write(string.Join('\n', Count));
            }
        }

        private static int Check(int r, int c, int[,] m)
        {
            int[] count = new int[3];
            int found = 3;

            for (int i = r; i < r + 3; i++)
            {
                for (int j = c; j < c + 3; j++)
                {
                    int value = m[i, j];

                    if (found == 3)
                        found = value;
                    else if (found != value)
                        found = 4;

                    if (value < 3)
                        count[m[i, j] + 1]++;
                }
            }

            if (found < 3)
            {
                return found;
            }
            else
            {
                for (int i = 0; i < count.Length; i++)
                {
                    Count[i] += count[i];
                }

                return 3;
            }
        }
    }
}