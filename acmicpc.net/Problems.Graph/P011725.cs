using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.Graph
{
    public class P011725
    {
        public static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            List<int>[] link = new List<int>[v + 1];

            for (int i = 0; i < v - 1; i++)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

                if (link[data[0]] is null)
                    link[data[0]] = new List<int>();

                link[data[0]].Add(data[1]);

                if (link[data[1]] is null)
                    link[data[1]] = new List<int>();

                link[data[1]].Add(data[0]);
            }

            int[] parent = new int[v + 1];
            Dfs(1, link, parent);
            Console.WriteLine(string.Join('\n', parent[2..^0]));
        }

        private static void Dfs(int start, List<int>[] link, int[] parent)
        {
            Stack<int> waiting = new Stack<int>();
            HashSet<int> visited = new HashSet<int>();
            waiting.Push(start);

            while (waiting.TryPop(out var node))
            {
                if (visited.Add(node) is false)
                    continue;

                foreach (var neighbor in link[node])
                {
                    if (visited.Contains(neighbor))
                        continue;

                    waiting.Push(neighbor);
                    parent[neighbor] = node;
                }
            }
        }
    }
}