using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace acmicpc.net.Problems.Sorting
{
    public class P010989
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] col = new int[10001];

            for (int i = 0; i < n; i++)
            {
                col[(int.Parse(Console.ReadLine()))] += 1;
            }

            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < col.Length; i++)
            {
                for (int j = 0; j < col[i]; j++)
                {
                    if (sb.Length >= 20_000)
                    {
                        sw.Write(sb);
                        sb.Clear();
                    }

                    sb.Append(i);
                    sb.Append('\n');
                }

            }

            sw.Write(sb);
        }
    }
}