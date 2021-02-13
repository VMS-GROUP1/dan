using System;
using System.Linq;

namespace acmicpc.net.Problems.DP
{
    //연속합
    public class P001912
    {
        private static int[] Memo;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] sequence = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            Solve1(n, sequence);
        }

        private static void Solve1(int n, int[] sequence)
        {
            Memo = new int[n];

            for (int i = 0; i < n; i++)
            {
                Memo[i] = Math.Max(sequence[i], (i == 0 ? 0 : Memo[i - 1]) + sequence[i]);
            }

            Console.WriteLine(Memo.Max());
        }
    }
}