using System;
using System.Collections.Generic;
using System.Text;

namespace acmicpc.net.Problems.BruteForce
{
    public class P002186
    {
        private static int ans;
        private static string word;
        private static Dictionary<(char c, int number, int length), int> memo;

        private static int n;
        private static int m;
        private static int k;
        public static void Main(string[] args)
        {
            ans = 0;
            memo = new Dictionary<(char c, int number, int length), int>();
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

            n = p[0];
            m = p[1];
            k = p[2];
            (char c, int number)[,] d = new (char, int)[n, m];
            int[] count = new int[26];
            Dictionary<(char c, int number), List<(char c, int number, int distance)>> link = new Dictionary<(char, int), List<(char, int, int)>>();

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < row.Length; j++)
                {
                    var c = row[j];
                    count[c - 'A'] += 1;
                    d[i, j] = (c, count[c - 'A']);
                }
            }

            word = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    var c = d[i, j];
                    if (link.TryGetValue(c, out var next) is false)
                    {
                        next = new List<(char c, int number, int distance)>();
                        link.Add(c, next);
                    }

                    for (int l = 0; l < n; l++)
                    {
                        if (l == i)
                            continue;

                        var distance = Math.Abs(i - l);
                        if (distance > k)
                            continue;
                        next.Add((d[l, j].c, d[l, j].number, distance));
                    }

                    for (int l = 0; l < m; l++)
                    {
                        if (l == j)
                            continue;

                        var distance = Math.Abs(j - l);
                        if (distance > k)
                            continue;
                        next.Add((d[i, l].c, d[i, l].number, distance));
                    }
                }
            }

            for (int i = 1; i <= count[word[0] - 'A']; i++)
            {
                var route = new Stack<(char, int)>();
                var node = (word[0], i);
                route.Push(node);
                Dfs(link, route, node);
            }

            Console.WriteLine(ans);
        }

        private static void Dfs(Dictionary<(char c, int number), List<(char c, int number, int distance)>> link, Stack<(char c, int number)> route, (char c, int number) node)
        {
            var key = (node.c, node.number, route.Count);
            if (memo.TryGetValue(key, out var count) && count > 0)
            {
                ans += count;
                return;
            }

            if (route.Count == word.Length)
            {
                memo[key] = 1;
                ans++;
                return;
            }

            if (link.TryGetValue(node, out var next) is false)
                return;

            foreach (var i in next)
            {
                if (i.c != word[route.Count])
                    continue;

                var newNode = (i.c, i.number);
                route.Push(newNode);
                Dfs(link, route, newNode);
                route.Pop();
            }
        }
    }
}