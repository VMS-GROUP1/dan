using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    //시간초과
    public class P001987
    {
        private static char[][] Board;
        private static HashSet<char> S;
        private static int R;
        private static int C;
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            R = p[0];
            C = p[1];
            Board = new char[R][];

            for (int i = 0; i < R; i++)
            {
                Board[i] = Console.ReadLine().ToCharArray();
            }

            Console.WriteLine(Dfs());
        }

        private static int Dfs()
        {
            S = new HashSet<char>();
            Stack<((int r, int c) point, int level)> waiting = new Stack<((int r, int c), int level)>();
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            Stack<(int r, int c)> route = new Stack<(int r, int c)>();
            int ans = int.MinValue;
            //string ansRoute = null;

            waiting.Push(((0, 0), 1));

            while (waiting.TryPop(out var node))
            {
                if (visited.Add(node.point) is false)
                    continue;

                route.Push(node.point);
                S.Add(Board[node.point.r][node.point.c]);
                if (node.level > ans)
                {
                    ans = node.level;
                    //ansRoute = string.Concat(route);
                }

                if (Check(node.point, node.level + 1, visited, waiting) is false)
                {
                    if (waiting.TryPeek(out var next))
                    {
                        while (route.Count >= next.level)
                        {
                            var p = route.Pop();
                            visited.Remove(p);
                            S.Remove(Board[p.r][p.c]);
                        }
                    }
                }
            }

            //Console.WriteLine(ansRoute);
            return ans;
        }

        private static bool Check((int r, int c) node, int level, HashSet<(int, int)> visited, Stack<((int r, int c) point, int level)> waiting)
        {
            bool check = false;

            (int r, int c) newNode = (node.r + 1, node.c);
            if (newNode.r < Board.Length && visited.Contains(newNode) is false && S.Contains(Board[newNode.r][newNode.c]) is false)
            {
                waiting.Push((newNode, level));
                check = true;
            }

            newNode = (node.r - 1, node.c);
            if (newNode.r >= 0 && visited.Contains(newNode) is false && S.Contains(Board[newNode.r][newNode.c]) is false)
            {
                waiting.Push((newNode, level));
                check = true;
            }

            newNode = (node.r, node.c + 1);
            if (newNode.c < Board[0].Length && visited.Contains(newNode) is false && S.Contains(Board[newNode.r][newNode.c]) is false)
            {
                waiting.Push((newNode, level));
                check = true;
            }

            newNode = (node.r, node.c - 1);
            if (newNode.c >= 0 && visited.Contains(newNode) is false && S.Contains(Board[newNode.r][newNode.c]) is false)
            {
                waiting.Push((newNode, level));
                check = true;
            }

            return check;
        }
    }
}