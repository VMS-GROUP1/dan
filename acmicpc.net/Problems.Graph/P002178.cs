using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Graph
{
    public class P002178
    {
        public static void Main(string[] args)
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

            int w = data[1];
            int h = data[0];

            var link = CreateLink(h, w);
            Console.WriteLine(Bfs(GetIndex(0, 0, w), GetIndex(h - 1, w - 1, w), link));
        }

        private static int Bfs(int start, int end, Dictionary<int, List<int>> link)
        {
            Dictionary<int, int> visited = new Dictionary<int, int>();
            Queue<(int, int)> waiting = new Queue<(int, int)>();
            waiting.Enqueue((start, 1));

            while (waiting.TryDequeue(out var node))
            {
                if (visited.TryGetValue(node.Item1, out var count) is false)
                {
                    visited[node.Item1] = node.Item2;
                }
                else if (node.Item2 >= count)
                {
                    continue;
                }

                if (end == node.Item1)
                    continue;

                int length = node.Item2 + 1;

                foreach (var neighbor in link[node.Item1])
                {
                    if (visited.TryGetValue(neighbor, out count) && length >= count)
                    {
                        continue;
                    }

                    waiting.Enqueue((neighbor, length));
                }
            }

            return visited[end];
        }

        private static Dictionary<int, List<int>> CreateLink(int r, int c)
        {
            int[][] m = new int[r][];
            Dictionary<int, List<int>> link = new Dictionary<int, List<int>>();

            for (int i = 0; i < r; i++)
            {
                m[i] = Array.ConvertAll(Console.ReadLine().ToCharArray(), x => x - '0');
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

        private static int GetIndex(int i, int j, int n) => i * n + j;
    }
}