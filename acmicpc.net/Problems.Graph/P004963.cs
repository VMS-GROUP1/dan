using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Graph
{
    public class P004963
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                if (IsTerminal(data))
                    break;

                int w = data[0];
                int h = data[1];

                var link = CreateLink(h, w);

                var visited = new HashSet<int>();
                int count = 0;

                foreach (var id in link.Keys)
                {
                    if (visited.Contains(id))
                        continue;

                    var group = Dfs(id, link);
                    visited.UnionWith(group);
                    count++;
                }

                Console.WriteLine(count);
            }
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

        private static bool IsTerminal(int[] data) => data.Length == 2 && data[0] == 0 && data[1] == 0;

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

                    //대각선
                    if (i - 1 >= 0 && j - 1 >= 0 && m[i - 1][j - 1] == 1)
                        neighbors.Add(GetIndex(i - 1, j - 1, c));
                    if (i - 1 >= 0 && j + 1 < c && m[i - 1][j + 1] == 1)
                        neighbors.Add(GetIndex(i - 1, j + 1, c));
                    if (i + 1 < r && j - 1 >= 0 && m[i + 1][j - 1] == 1)
                        neighbors.Add(GetIndex(i + 1, j - 1, c));
                    if (i + 1 < r && j + 1 < c && m[i + 1][j + 1] == 1)
                        neighbors.Add(GetIndex(i + 1, j + 1, c));
                }
            }

            return link;
        }

        private static int GetIndex(int i, int j, int c) => i * c + j;
    }
}