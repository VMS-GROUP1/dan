using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Graph
{
    public class P002667
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] m = new int[n][];
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                m[i] = Array.ConvertAll(Console.ReadLine().ToArray(), x => x - (int)'0');
                count += m[i].Sum();
            }

            Dictionary<int, List<int>> link = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (m[i][j] == 0)
                        continue;

                    int id = GetIndex(i, j, n);
                    if (link.TryGetValue(id, out List<int> neighbors) is false)
                        link.Add(id, neighbors = new List<int>());

                    if (i - 1 >= 0 && m[i - 1][j] == 1)
                        neighbors.Add(GetIndex(i - 1, j, n));
                    if (i + 1 < n && m[i + 1][j] == 1)
                        neighbors.Add(GetIndex(i + 1, j, n));
                    if (j - 1 >= 0 && m[i][j - 1] == 1)
                        neighbors.Add(GetIndex(i, j - 1, n));
                    if (j + 1 < n && m[i][j + 1] == 1)
                        neighbors.Add(GetIndex(i, j+ 1, n));
                }
            }

            HashSet<int> visited = new HashSet<int>();
            List<int> blocks = new List<int>();

            foreach (var id in link.Keys)
            {
                if (visited.Contains(id))
                    continue;

                var group = Dfs(id, link);
                visited.UnionWith(group);
                blocks.Add(group.Count());
            }

            blocks.Sort();
            Console.WriteLine($"{blocks.Count}\n{string.Join('\n', blocks)}");
        }

        private static IEnumerable<int> Dfs(int start, Dictionary<int, List<int>> link)
        {
            Stack<int> waiting = new Stack<int>();
            HashSet<int> visited = new HashSet<int>();
            int node = start;
            waiting.Push(node);

            while (waiting.TryPop(out node))
            {
                if (visited.Add(node) is false)
                    continue;

                foreach (var neighbor in link[node])
                {
                    if (visited.Contains(neighbor))
                        continue;

                    waiting.Push(neighbor);
                }
            }

            return visited;
        }

        private static int GetIndex(int i, int j, int n) => i * n + j;
    }
}