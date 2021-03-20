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
            Dictionary<int, (int, int)> maxMemo = new Dictionary<int, (int, int)>();

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

                max = Math.Max(max, Dfs(i, link, memo, maxMemo));
            }

            Console.WriteLine(max);
        }

        private static int Dfs(int start, List<(int, int)>[] link, Dictionary<int, int>[] memo, Dictionary<int, (int, int)> maxMemo)
        {
            Stack<(int, int)> waiting = new Stack<(int, int)>();
            Stack<(int, int)> seq = new Stack<(int, int)>();
            HashSet<int> visited = new HashSet<int>();
            Dictionary<int, HashSet<(int, int)>> neighbors = new Dictionary<int, HashSet<(int, int)>>();
            Dictionary<int, int> check = new Dictionary<int, int>();
            int max = 0;
            waiting.Push((start, 0));
            seq.Push((start, 0));

            while (waiting.TryPop(out var node))
            {
                if (visited.Add(node.Item1) is false || check.ContainsKey(node.Item1))
                    continue;

                neighbors[node.Item1] = new HashSet<(int, int)>();

                foreach (var neighbor in link[node.Item1])
                {
                    if (visited.Contains(neighbor.Item1))
                        continue;

                    if (maxMemo.TryGetValue(neighbor.Item1, out var maxValue3) && maxValue3.Item1 != node.Item1)
                    {
                        check[neighbor.Item1] = maxValue3.Item2;
                        continue;
                    }

                    waiting.Push((neighbor.Item1, neighbor.Item2));
                    neighbors[node.Item1].Add(neighbor);
                    seq.Push(neighbor);
                }
            }

            while (seq.TryPop(out var node))
            {
                if (check.TryGetValue(node.Item1, out var v))
                {
                    max += v;
                    continue;
                }
                else
                {
                    check[node.Item1] = 0;
                }

                if (neighbors.TryGetValue(node.Item1, out var l) is false)
                    continue;

                foreach (var neighbor in l)
                {
                    if (memo[node.Item1].TryGetValue(neighbor.Item1, out var value1))
                    {
                        check[node.Item1] = Math.Max(check[node.Item1], value1);
                        continue;
                    }

                    memo[node.Item1].Add(neighbor.Item1, check[neighbor.Item1] + neighbor.Item2);
                    if (memo[node.Item1].Count == link[node.Item1].Count)
                    {
                        maxMemo[node.Item1] = Max(memo[node.Item1]);
                    }

                    check[node.Item1] = Math.Max(check[node.Item1], memo[node.Item1][neighbor.Item1]);
                }
            }

            check.TryGetValue(start, out max);
            return max;
        }

        private static (int, int) Max(IEnumerable<KeyValuePair<int, int>> collection)
        {
            (int, int) found = (0, 0);

            foreach (var i in collection)
            {
                if (i.Value <= found.Item2)
                    continue;

                found = (i.Key, i.Value);
            }

            return found;
        }
    }
}