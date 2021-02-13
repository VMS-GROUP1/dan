using System;
using System.Linq;

namespace acmicpc.net.Problems.DP
{
    //가장 긴 바이토닉 부분 수열
    public class P011054
    {
        private static int[] MemoA;
        private static int[] MemoD;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] item = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Solve1(n, item);
        }

        private static void Solve1(int n, int[] array)
        {
            MemoA = new int[1_001];
            MemoD = new int[1_001];

            for (int i = 0; i < n; i++)
            {
                int item = array[i];

                if (MemoA[item] == 0)
                    MemoA[item] = 1;

                if (MemoD[item] == 0)
                    MemoD[item] = 1;

                for (int j = 1; j < MemoA.Length; j++)
                {
                    if (j == item)
                        continue;

                    if (j < item)
                    {
                        MemoA[item] = Math.Max(MemoA[item], MemoA[j] + 1);
                    }
                    else
                    {
                        MemoD[item] = Math.Max(MemoD[item], MemoA[j] + 1);
                        MemoD[item] = Math.Max(MemoD[item], MemoD[j] + 1);
                    }
                }
            }

            Console.WriteLine(Math.Max(MemoA.Max(), MemoD.Max()));
        }
    }
}