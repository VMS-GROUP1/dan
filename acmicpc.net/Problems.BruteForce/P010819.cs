using System;
using System.Collections;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    public class P010819
    {
        private static int n;
        private static int[] a;
        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            a = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int ans = Dfs();
            Console.WriteLine(ans);
        }

        private static int Dfs()
        {
            Stack<(int level, int value)> waiting = new Stack<(int, int)>();
            int[] check = new int[n];
            int[] perm = new int[n];
            int ans = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                waiting.Push((1, i));
            }

            while (waiting.TryPop(out var node))
            {
                check[node.value] = 1;
                perm[node.level - 1] = node.value;

                if (node.level == n)
                {
                    ans = Math.Max(Calc(perm), ans);
                    if (waiting.TryPeek(out var next))
                    {
                        for (int i = next.level - 1; i < n; i++)
                        {
                            check[perm[i]] = 0;
                        }
                    }

                    continue;
                }

                for (int i = 0; i < n; i++)
                {
                    if (check[i] == 1)
                        continue;

                    waiting.Push((node.level + 1, i));
                }
            }

            return ans;
        }

        private static int Calc(int[] x)
        {
            int ans = 0;
            for (int i = 1; i < x.Length; i++)
            {
                ans += Math.Abs(a[x[i - 1]] - a[x[i]]);
            }

            return ans;
        }
    }
}