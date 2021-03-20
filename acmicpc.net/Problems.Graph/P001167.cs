using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Graph
{
    public class P001167
    {
        public static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            List<(int, int)>[] link = new List<(int, int)>[v + 1];
            Dictionary<int, int>[] memo = new Dictionary<int, int>[v + 1];

            for (int i = 1; i <= v; i++)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                link[i] = new List<(int, int)>();
                memo[i] = new Dictionary<int, int>();

                for (int j = 1; j < data.Length - 1; j += 2)
                {
                    link[i].Add((data[j], data[j + 1]));
                }
            }

            int max = 0;
            for (int i = 1; i <= v; i++)
            {
                if (link[i].Count > 1)
                    continue;

                max = Math.Max(max, Dfs(i, link, memo));
            }

            Console.WriteLine(max);
        }

        private static int Dfs(int start, List<(int, int)>[] link, Dictionary<int, int>[] memo)
        {
            Stack<(int, int)> waiting = new Stack<(int, int)>();
            HashSet<int> visited = new HashSet<int>();
            int[] check = new int[link.Length];
            int max = 0;
            waiting.Push((start, 0));

            while (waiting.TryPop(out var node))
            {
                if (visited.Add(node.Item1) is false)
                    continue;

                max = Math.Max(max, node.Item2);

                foreach (var neighbor in link[node.Item1])
                {
                    if (visited.Contains(neighbor.Item1))
                        continue;

                    if (memo[node.Item1].TryGetValue(neighbor.Item1, out var memoValue1))
                    {
                        visited.Add(neighbor.Item1);
                        max = Math.Max(max, node.Item2 + memoValue1);
                        continue;
                    }

                    waiting.Push((neighbor.Item1, node.Item2 + neighbor.Item2));

                    if (link[node.Item1].Count <= 2)
                    {
                        memo[neighbor.Item1].Add(node.Item1, node.Item2);
                        continue;
                    }


                    if (memo[node.Item1].Count + 1 >= link[node.Item1].Count)
                        memo[neighbor.Item1].Add(node.Item1, memo[node.Item1].Values.());
                }
            }

            return max;
        }
    }
}