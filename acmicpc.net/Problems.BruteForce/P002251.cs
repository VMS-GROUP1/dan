using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.BruteForce
{
    public class P002251
    {
        private static int[] capa;
        //private static int[] x;
        private static HashSet<((int, int), (int, int))> visited;
        private static HashSet<(int, int, int)> visited2;
        public static void Main(string[] args)
        {
            capa = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            //x = new int[3];
            var ans = Bfs().ToList();
            ans.Sort();

            Console.WriteLine(string.Join(' ', ans));
        }

        private static IEnumerable<int> Bfs()
        {
            Queue<(int index, int[] water)> waiting = new Queue<(int index, int[] water)>();
            waiting.Enqueue((2, new int[3] { 0, 0, capa[2] }));
            //x[2] = capa[2];
            visited = new HashSet<((int, int), (int, int))>();
            visited2 = new HashSet<(int, int, int)>();

            HashSet<int> link = new HashSet<int>() { 0, 1, 2 };
            HashSet<int> ans = new HashSet<int>();
            ans.Add(capa[2]);

            while (waiting.TryDequeue(out var node))
            {
                if (node.water[node.index] == 0)
                    continue;

                foreach (var to in link)
                {
                    if (node.index == to)
                        continue;

                    if (node.water[to] == capa[to])
                        continue;

                    int c = capa[to] - node.water[to];
                    int t = Math.Min(node.water[node.index], c);
                    int other = 3 - (node.index + to);

                    int[] water = new int[3];
                    water[node.index] = node.water[node.index] - t;
                    water[to] = node.water[to] + t;
                    water[other] = node.water[other];

                    if (visited2.Add((water[0], water[1], water[2])) is false)
                        continue;

                    waiting.Enqueue((to, water));

                    if (water[node.index] > 0)
                        waiting.Enqueue((node.index, water.ToArray()));

                    if (water[other] > 0)
                        waiting.Enqueue((other, water.ToArray()));

                    if (water[0] == 0)
                        ans.Add(water[2]);
                }
            }

            return ans;
        }
    }
}