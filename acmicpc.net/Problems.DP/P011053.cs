using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.DP
{
    //가장 긴 증가하는 부분 수열
    public class P011053
    {
        private static int[] Memo;
        //private static Dictionary<int, int> Memo = new Dictionary<int, int>();

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] item = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Solve1(n, item);
        }

        private static void Solve1(int n, int[] array)
        {
            Memo = new int[1_001];
            //Memo.Clear();

            for (int i = 0; i < n; i++)
            {
                int item = array[i];

                if (Memo[item] == 0)
                    Memo[item] = 1;

                for (int j = 1; j < Memo.Length; j++)
                {
                    if (j >= item)
                        break;

                    if (Memo[j] == 0)
                        continue;

                    Memo[item] = Math.Max(Memo[item], Memo[j] + 1);
                }
                // if (Memo.TryGetValue(item, out int old) == false)
                // {
                //     Memo[item] = 1;
                // }

                // foreach(int key in Memo.Keys)
                // {
                //     if (key >= item)
                //         continue;

                //     Memo[item] = Math.Max(Memo[item], Memo[key] + 1);
                // }
            }

            Console.WriteLine(Memo.Max());
            //Console.WriteLine(Memo.Values.Max());
        }
    }
}