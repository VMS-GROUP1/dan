using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.Graph
{
    public class P002146
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var link = CreateLink(n, n);

            HashSet<int> visited = new HashSet<int>();
            Dictionary<int, int> land = new Dictionary<int, int>();

            foreach (var id in link.Keys)
            {
                if (visited.Contains(id))
                    continue;

                var group = Dfs(id, link);
                visited.UnionWith(group.Keys);
                foreach (var i in group)
                {
                    land[i.Key] = i.Value;
                }
            }

            Console.WriteLine(MinDistance(new Queue<int>(link.Keys), land, n));
        }

        private static int MinDistance(Queue<int> waiting, Dictionary<int, int> land, int width)
        {
            int distance = int.MaxValue;

            while (waiting.TryDequeue(out var node))
            {
                Queue<int> others = new Queue<int>(waiting);
                while (others.TryDequeue(out var other))
                {
                    if (land[node] == land[other])
                        continue;

                    distance = Math.Min(distance, GetDistance(node, other, width));
                }
            }

            return distance;
        }

        private static Dictionary<int, int> Dfs(int start, Dictionary<int, List<int>> link)
        {
            Dictionary<int, int> visited = new Dictionary<int, int>();
            Stack<int> waiting = new Stack<int>();
            int node = start;
            waiting.Push(node);

            while (waiting.TryPop(out node))
            {
                if (visited.TryAdd(node, start) is false)
                    continue;

                foreach (var neighbor in link[node])
                {
                    if (visited.ContainsKey(neighbor))
                        continue;

                    waiting.Push(neighbor);
                }
            }

            return visited;
        }

        private static Dictionary<int, List<int>> CreateLink(int r, int c)
        {
            int[][] m = new int[r][];
            Dictionary<int, List<int>> link = new Dictionary<int, List<int>>();

            for (int i = 0; i < r; i++)
            {
                m[i] = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            }

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (m[i][j] == 0)
                        continue;

                    int id = GetIndex(i, j, c);
                    if (link.TryGetValue(id, out List<int> neighbors) is false)
                        link.Add(id, neighbors = new List<int>());

                    //상하좌우
                    if (i - 1 >= 0 && m[i - 1][j] == 1)
                        neighbors.Add(GetIndex(i - 1, j, c));
                    if (i + 1 < r && m[i + 1][j] == 1)
                        neighbors.Add(GetIndex(i + 1, j, c));
                    if (j - 1 >= 0 && m[i][j - 1] == 1)
                        neighbors.Add(GetIndex(i, j - 1, c));
                    if (j + 1 < c && m[i][j + 1] == 1)
                        neighbors.Add(GetIndex(i, j + 1, c));
                }
            }

            return link;
        }

        private static int GetDistance(int id, int other, int width)
        {
            int distance = Math.Abs(id / width - other / width);
            distance += Math.Abs(id % width - other % width) - 1;

            return distance;
        }

        private static int GetIndex(int i, int j, int n) => i * n + j;
    }
}