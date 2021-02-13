using System;
using System.Linq;

namespace acmicpc.net.Problems.DP
{
    //가장 긴 감소하는 부분 수열
    public class P011722
    {
        private static int[] Memo;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] item = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Solve1(n, item);
        }

        private static void Solve1(int n, int[] array)
        {
            Memo = new int[1_001];

            for (int i = 0; i < n; i++)
            {
                int item = array[i];

                if (Memo[item] == 0)
                    Memo[item] = 1;

                for (int j = item + 1; j < Memo.Length; j++)
                {
                    if (Memo[j] == 0)
                        continue;

                    Memo[item] = Math.Max(Memo[item], Memo[j] + 1);
                }
            }

            Console.WriteLine(Memo.Max());
        }
    }
}