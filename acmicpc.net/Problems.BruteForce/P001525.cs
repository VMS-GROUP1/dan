using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001525
    {
        private static int[] m;
        private static int ans;
        public static void Main(string[] args)
        {
            m = new int[9];
            (int, int) nine = (2, 2);
            ans = 0;
            for (int i = 0; i < 3; i++)
            {
                var d = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

                for (int j = 0; j < 3; j++)
                {
                    int value = d[j];
                    if (value == 0)
                    {
                        nine = (i, j);
                        value = 9;
                    }

                    m[i * 3 + j] = value;
                }
            }

            Bfs(nine, m);
            Console.WriteLine(ans);
        }

        private static void Bfs((int r, int c) nine, int[] m)
        {
            int[] newM = m.ToArray();
            Queue<((int r, int c) nine, int[] m, int level)> Waiting = new Queue<((int, int), int[], int)>();
            Waiting.Enqueue((nine, newM, 0));

            while (Waiting.TryDequeue(out var node))
            {
                if (node.nine.r == 2 && node.nine.c == 2 && Check(node.m))
                {
                    ans = node.level;
                    break;
                }

                nine = node.nine;
                m = node.m;
                int level = node.level + 1;

                if (nine.r - 1 >= 0)
                {
                    newM = m.ToArray();
                    Swap(newM, nine, (nine.r - 1, nine.c), Waiting, level);
                }

                if (nine.r + 1 <= 2)
                {
                    newM = m.ToArray();
                    Swap(newM, nine, (nine.r + 1, nine.c), Waiting, level);
                }

                if (nine.c - 1 >= 0)
                {
                    newM = m.ToArray();
                    Swap(newM, nine, (nine.r, nine.c - 1), Waiting, level);
                }

                if (nine.c + 1 <= 2)
                {
                    newM = m.ToArray();
                    Swap(newM, nine, (nine.r, nine.c + 1), Waiting, level);
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

        private static void Swap(int[] m, (int r, int c) x, (int r, int c) y, Queue<((int, int), int[], int)> Waiting, int level)
        {
            int from = x.r * 3 + x.c;
            int to = y.r * 3 + y.c;

            var temp = m[to];
            m[to] = 9;
            m[from] = temp;
            Waiting.Enqueue((y, m, level));
        }
    }
}