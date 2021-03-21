using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.Graph
{
    public class P007576
    {
        public static void Main(string[] args)
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

            int w = data[0];
            int h = data[1];

            HashSet<int> start = new HashSet<int>();
            var link = CreateLink(h, w, start);
            Console.WriteLine(Do(link, start));
        }

        private static int Do(Dictionary<int, List<int>> link, HashSet<int> start)
        {
            HashSet<int> visited = new HashSet<int>(start);
            Queue<int> waiting = new Queue<int>(start);
            Queue<int> temp = new Queue<int>();
            int count = 0;

            while (waiting.TryDequeue(out var node))
            {
                foreach (var neighbor in link[node])
                {
                    if (visited.Add(neighbor) is false)
                        continue;

                    temp.Enqueue(neighbor);
                }

                if (waiting.Count <= 0 && temp.Count > 0)
                {
                    waiting = new Queue<int>(temp);
                    temp.Clear();
                    count++;
                }
            }

            return visited.Count == link.Count ? count : -1;
        }

        private static Dictionary<int, List<int>> CreateLink(int r, int c, HashSet<int> visited)
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
                    if (m[i][j] == -1)
                        continue;

                    int id = GetIndex(i, j, c);
                    if (link.TryGetValue(id, out List<int> neighbors) is false)
                        link.Add(id, neighbors = new List<int>());

                    //상하좌우
                    if (i - 1 >= 0 && m[i - 1][j] != -1)
                        neighbors.Add(GetIndex(i - 1, j, c));
                    if (i + 1 < r && m[i + 1][j] != -1)
                        neighbors.Add(GetIndex(i + 1, j, c));
                    if (j - 1 >= 0 && m[i][j - 1] != -1)
                        neighbors.Add(GetIndex(i, j - 1, c));
                    if (j + 1 < c && m[i][j + 1] != -1)
                        neighbors.Add(GetIndex(i, j + 1, c));

                    if (m[i][j] == 1)
                        visited.Add(GetIndex(i, j, c));
                }
            }

            return link;
        }

        private static int GetIndex(int i, int j, int n) => i * n + j;
    }
}