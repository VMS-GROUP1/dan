using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.ProblemBruteForce
{
    public class P003108
    {
        private static int N;
        private static int[][,] M;
        //private static List<(int, int)>[] Link = new List<(int, int)>();
        private static HashSet<(int, int)> Visited;
        private static Dictionary<(int, int), HashSet<(int, int)>> Link;
        private static List<(int x1, int y1, int x2, int y2)> Segment;
        private static List<List<(int, int)>> my = new List<List<(int, int)>>();
        public static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            M = new int[N][,];
            Link = new Dictionary<(int, int), HashSet<(int, int)>>();
            Segment = new List<(int x1, int y1, int x2, int y2)>();
            Visited = new HashSet<(int, int)>();

            for (int i = 0; i < N; i++)
            {
                int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

                Add((p[0], p[1]), (p[0], p[3]));
                Add((p[0], p[3]), (p[2], p[3]));
                Add((p[2], p[3]), (p[2], p[1]));
                Add((p[2], p[1]), (p[0], p[1]));

                Segment.Add((p[0], p[1], p[0], p[3]));
                Segment.Add((p[0], p[3], p[2], p[3]));
                Segment.Add((p[2], p[3], p[2], p[1]));
                Segment.Add((p[2], p[1], p[0], p[1]));
            }
            Link.TryAdd((0, 0), new HashSet<(int, int)>());
            Find();
            int ans = 0;
            my = new List<List<(int, int)>>();
            HashSet<(int, int)> check = new HashSet<(int, int)>();
            foreach (var node in Link.Keys)
            {
                if (Visited.Contains(node))
                    continue;

                if (Dfs(node))
                {
                    foreach (var i in my.Last())
                    {
                        if (check.Add(i) is false)
                        {
                            string aa = "";
                        }
                    }

                    check.UnionWith(my.Last());
                    ans++;
                }
            }

            Console.WriteLine(ans - 1);
        }

        private static void Add((int x, int y) from, (int x, int y) to)
        {
            if (from == to)
                return;

            if (Link.TryGetValue(from, out var next) is false)
            {
                next = new HashSet<(int, int)>();
                Link.Add(from, next);
            }

            next.Add(to);

            if (Link.TryGetValue(to, out next) is false)
            {
                next = new HashSet<(int, int)>();
                Link.Add(to, next);
            }

            next.Add(from);
        }

        private static void Find()
        {
            int count = Segment.Count;
            for (int i = 0; i < count; i++)
            {
                var s = Segment[i];
                for (int j = 0; j < count; j++)
                {
                    var other = Segment[j];
                    if (IsIntersect(s.x1, s.y1, s.x2, s.y2, other.x1, other.y1, other.x2, other.y2, out var point) is false)
                        continue;

                    Add((s.x1, s.y1), point);
                    Add((s.x2, s.y2), point);
                    Add((other.x1, other.y1), point);
                    Add((other.x2, other.y2), point);
                }
            }
        }

        private static bool IsIntersect(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4, out (int x, int y) point)
        {
            point = (0, 0);
            int b = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            if (b == 0)
                return false;

            point = GetIntersection(x1, y1, x2, y2, x3, y3, x4, y4);
            if (point.x < Math.Min(x1, x2) || point.x > Math.Max(x1, x2))
                return false;

            if (point.y < Math.Min(y1, y2) || point.y > Math.Max(y1, y2))
                return false;

            if (point.x < Math.Min(x3, x4) || point.x > Math.Max(x3, x4))
                return false;

            if (point.y < Math.Min(y3, y4) || point.y > Math.Max(y3, y4))
                return false;

            return true;
        }

        private static (int x, int y) GetIntersection(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            int b = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
            int a1 = x1 * y2 - y1 * x2;
            int a2 = x3 * y4 - y3 * x4;
            int x = (a1 * (x3 - x4) - (x1 - x2) * a2) / b;
            int y = (a1 * (y3 - y4) - (y1 - y2) * a2) / b;
            return (x, y);
        }

        private static bool Dfs((int x, int y) start)
        {
            if (Visited.Contains(start))
                return false;

            List<(int, int)> newMy = new List<(int, int)>();
            my.Add(newMy);

            Stack<(int x, int y)> waiting = new Stack<(int x, int y)>();
            waiting.Push(start);

            while (waiting.TryPop(out var node))
            {
                if (Visited.Add(node) is false)
                    continue;

                newMy.Add(node);

                if (Link.TryGetValue(node, out var neighbors) is false)
                    continue;

                foreach (var next in neighbors)
                {
                    if (Visited.Contains(next))
                        continue;

                    waiting.Push(next);
                }
            }

            newMy.Sort();

            return true;
        }
    }
}