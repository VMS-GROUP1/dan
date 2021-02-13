using System;
using System.Linq;

namespace acmicpc.net.Problems.DP
{
    //가장 큰 증가 부분 수열
    public class P011055
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
                    Memo[item] = item;

                for (int j = 1; j < Memo.Length; j++)
                {
                    if (j >= item)
                        break;

                    if (Memo[j] == 0)
                        continue;

                    Memo[item] = Math.Max(Memo[item], Memo[j] + item);
                }
            }

            Console.WriteLine(Memo.Max());
        }
    }
}