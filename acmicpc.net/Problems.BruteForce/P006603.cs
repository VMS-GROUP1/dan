using System;
using System.Text;

namespace acmicpc.net.Problems.BruteForce
{
    //로또
    public class P006603
    {
        private static int[] Check;
        private static int[] Ans = new int[6];
        private static StringBuilder stringBuilder = new StringBuilder();
        public static void Main(string[] args)
        {
            int count = 0;
            while (true)
            {
                int[] t = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                if (t[0] == 0)
                    break;

                if (count > 0)
                    stringBuilder.Append('\n');

                Check = new int[50];
                Do(t, 1, 0);
                count++;
            }

            Console.Write(stringBuilder);
        }

        private static void Do(int[] k, int i, int count)
        {
            for (int j = i; j < k.Length; j++)
            {
                if (count > 5 || k.Length - j <= 5 - count)
                    break;

                if (count < 5)
                {
                    Ans[count] = k[j];
                }
                else
                {
                    Ans[count] = k[j];
                    stringBuilder.Append(string.Join(' ', Ans));
                    stringBuilder.Append('\n');
                    continue;
                }

                int x = k[j];
                Do(k, j + 1, count + 1);
            }
        }
    }
}
