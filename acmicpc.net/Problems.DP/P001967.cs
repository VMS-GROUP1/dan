using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.DP
{
    public class P001967
    {
        public static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            List<(int, int)>[] link = new List<(int, int)>[v + 1];
            link[1] = new List<(int, int)>();
            link[1].Add((1, 0));

            for (int i = 0; i < v - 1; i++)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

                if (link[data[0]] is null)
                    link[data[0]] = new List<(int, int)>();

                link[data[0]].Add((data[1], data[2]));

                if (link[data[1]] is null)
                    link[data[1]] = new List<(int, int)>();

                link[data[1]].Add((data[0], data[2]));
            }

            (int, int) max = Dfs(1, link);
            max = Dfs(max.Item1, link);

            Console.WriteLine(max.Item2);

        }

        private static (int, int) Dfs(int start, List<(int, int)>[] link)
        {
            Stack<(int, int)> waiting = new Stack<(int, int)>();
            HashSet<int> visited = new HashSet<int>();
            (int, int) max = (start, 0);
            waiting.Push((start, 0));

            while (waiting.TryPop(out var node))
            {
                if (visited.Add(node.Item1) is false)
                    continue;

                max = node.Item2 > max.Item2 ? node : max;
                foreach (var neighbor in link[node.Item1])
                {
                    if (visited.Contains(neighbor.Item1))
                        continue;

                    waiting.Push((neighbor.Item1, node.Item2 + neighbor.Item2));
                }
            }

            return max;
        }
    }
}