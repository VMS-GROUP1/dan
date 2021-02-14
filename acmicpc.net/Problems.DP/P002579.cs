using System;
using System.Linq;

namespace acmicpc.net.Problems.DP
{
    //계단 오르기
    public class P002579
    {
         private static int[] Memo;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] point = new int[n];
            for (int i = 0; i < n; i++)
                point[i] = int.Parse(Console.ReadLine());

            Solve1(n, point);
        }

        private static void Solve1(int n, int[] point)
        {
            Memo = new int[300];

            for (int i = 0; i < n; i++)
            {
                int x = (i < 3 ? 0 : Memo[i - 3]) + (i < 1 ? 0 : point[i - 1]) + point[i];
                int y = (i < 2 ? 0 : Memo[i - 2]) + point[i];
                Memo[i] = Math.Max(x, y);
            }

            Console.WriteLine(Memo[n - 1]);
        }       
    }
}