using System;
using System.IO;
using System.Text;

namespace acmicpc.net.Problems.DD
{
    public class P011729
    {
        private static short[] m;
        public static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());
            m = new short[n + 1];

            short a = n % 2 == 0 ? 1 : -1;
            short b = (short)-a;
            int count = (int)Math.Pow(2, n) - 1;
            StringBuilder sb = new StringBuilder(count * 4);
            var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            sb.Append(count);
            sb.Append('\n');

            for (int i = 1; i <= count; i++)
            {
                int j = i;
                int k = 1;
                while (j > 1)
                {
                    if (j % 2 == 1)
                    {
                        break;
                    }

                    j /= 2;
                    k++;
                }

                if (m[k] == 0)
                    m[k] = 1;

                short p = m[k];

                if (k % 2 == 0)
                {
                    m[k] += b;
                }
                else
                {
                    m[k] += a;
                }

                if (m[k] > 3)
                {
                    m[k] = 1;
                }
                else if (m[k] < 1)
                {
                    m[k] = 3;
                }

                sb.Append(p);
                sb.Append(' ');
                sb.Append(m[k]);
                sb.Append('\n');
            }

            sw.Write(sb);
            sw.Close();
        }
    }
}