using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001525
    {
        private static int ans;
        public static void Main(string[] args)
        {
            int nine = 0;
            ans = -1;
            int n = 0;
            for (int i = 0; i < 3; i++)
            {
                var d = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

                for (int j = 0; j < 3; j++)
                {
                    int value = d[j];
                    if (value == 0)
                    {
                        nine = i * 3 + j;
                        value = 9;
                    }

                    n = n * 10 + value;
                }
            }

            Bfs(nine, n);
            Console.WriteLine(ans);
        }

        private static void Bfs(int nine, int n)
        {
            int goal = 123456789;
            HashSet<int> check = new HashSet<int>();
            Queue<(int nine, int m, int level)> Waiting = new Queue<(int nine, int m, int level)>();
            Waiting.Enqueue((nine, n, 0));

            while (Waiting.TryDequeue(out var node))
            {
                if (node.m == goal)
                {
                    ans = node.level;
                    break;
                }

                if (check.Add(node.m) is false)
                    continue;

                nine = node.nine;
                int m = node.m;
                int level = node.level + 1;

                if (nine / 3 > 0)
                {
                    Swap(m, nine, nine - 3, Waiting, level);
                }

                if (nine / 3 < 2)
                {
                    Swap(m, nine, nine + 3, Waiting, level);
                }

                if (nine % 3 > 0)
                {
                    Swap(m, nine, nine - 1, Waiting, level);
                }

                if (nine % 3 < 2)
                {
                    Swap(m, nine, nine + 1, Waiting, level);
                }
            }
        }

        private static bool Check(int[] m)
        {
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i] != i + 1)
                    return false;
            }

            return true;
        }

        private static void Swap(int m, int x, int y, Queue<(int, int, int)> Waiting, int level)
        {
            int xd = (int)Math.Pow(10, 8 - x);
            int yd = (int)Math.Pow(10, 8 - y);
            int from = m / xd % 10;
            int to = m / yd % 10;
            m -= xd * from;
            m -= yd * to;
            m += xd * to;
            m += yd * from;
            Waiting.Enqueue((y, m, level));
        }
    }
}