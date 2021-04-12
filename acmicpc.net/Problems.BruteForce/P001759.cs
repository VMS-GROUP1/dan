using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001759
    {
        private static HashSet<char> a = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            char[] c = Array.ConvertAll(Console.ReadLine().Split(), x => char.Parse(x));

            Array.Sort(c, (x, y) => x.CompareTo(y) * -1);
            Dfs(c, p[0]);
        }

        private static int Dfs(char[] c, int n)
        {
            Stack<(char value, int level)> waiting = new Stack<(char, int)>();
            HashSet<char> visited = new HashSet<char>();
            int[] check = new int[c.Length];
            char[] perm = new char[n];
            int ans = int.MinValue;
            int count1 = 0;
            int count2 = 0;

            for (int i = 0; i < c.Length; i++)
            {
                waiting.Push((c[i], 1));
            }

            while (waiting.TryPop(out var node))
            {
                visited.Add(node.value);
                perm[node.level - 1] = node.value;
                if (a.Contains(node.value))
                    count1++;
                else
                    count2++;

                if (node.level == n)
                {
                    if (count1 >= 1 && count2 >= 2)
                        Console.WriteLine(string.Concat(perm));

                    if (waiting.TryPeek(out var next))
                    {
                        for (int i = next.level - 1; i < n; i++)
                        {
                            if (visited.Remove(perm[i]))
                            {
                                if (a.Contains(perm[i]))
                                    count1--;
                                else
                                    count2--;
                            }
                        }
                    }

                    continue;
                }

                int count = 0;
                for (int i = 0; i < c.Length; i++)
                {
                    if (visited.Contains(c[i]) || c[i] < perm[node.level - 1])
                        continue;

                    waiting.Push((c[i], node.level + 1));
                    count++;
                }

                if (count <= 0)
                {
                    if (waiting.TryPeek(out var next))
                    {
                        for (int i = next.level - 1; i < n; i++)
                        {
                            if (visited.Remove(perm[i]))
                            {
                                if (a.Contains(perm[i]))
                                    count1--;
                                else
                                    count2--;
                            }
                        }
                    }
                }
            }

            return ans;
        }
    }
}