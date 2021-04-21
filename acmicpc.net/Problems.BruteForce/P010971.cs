using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    public class P010971
    {
        private static int N;
        private static int[][] Map;
        private static HashSet<int> Visited;
        public static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            Map = new int[N][];
            Visited = new HashSet<int>();

            for (int i = 0; i < N; i++)
            {
                Map[i] = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

                for (int j = 0; j < N; j++)
                {
                    if (i == j || Map[i][j] == 0)
                        continue;
                }
            }

            int ans = int.MaxValue;
            for (int i = 0; i < N; i++)
            {
                ans = Math.Min(ans, Dfs(i, i, 0));
            }

            Console.WriteLine(ans);
        }

        private static int Dfs(int start, int x, int cost)
        {
            if (Visited.Count == N && x == start)
                return cost;

            int ans = int.MaxValue;

            for (int i = 0; i < N; i++)
            {
                if (x == i || Map[x][i] == 0)
                    continue;

                if (Visited.Count != N - 1 && i == start)
                    continue;

                if (Visited.Contains(i))
                    continue;

                Visited.Add(i);
                ans = Math.Min(ans, Dfs(start, i, cost + Map[x][i]));
                Visited.Remove(i);
            }

            return ans;
        }
    }
}