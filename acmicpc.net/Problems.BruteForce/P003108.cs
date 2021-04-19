using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.ProblemBruteForce
{
    public class P003108
    {
        private static int N;
        private static int[][,] M;
        private static HashSet<Rect> Visited;
        public static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            M = new int[N][,];
            Visited = new HashSet<Rect>();

            HashSet<Rect> pool = new HashSet<Rect>();
            pool.Add(new Rect(0, 0, 0, 0));

            for (int i = 0; i < N; i++)
            {
                int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

                Rect r = new Rect(p[0], p[1], p[2], p[3]);
                pool.Add(r);
            }

            Dictionary<int, HashSet<Rect>> check = new Dictionary<int, HashSet<Rect>>();
            Dictionary<Rect, int> keys = new Dictionary<Rect, int>();

            int ans = 0;
            foreach (var r1 in pool)
            {
                ans += Bfs(r1, pool);
            }

            Console.WriteLine(ans - 1);
        }

        private static int Bfs(Rect start, HashSet<Rect> pool)
        {
            Queue<Rect> waiting = new Queue<Rect>();
            if (Visited.Contains(start))
                return 0;

            waiting.Enqueue(start);
            Visited.Add(start);

            while (waiting.TryDequeue(out var node))
            {
                foreach (var other in pool)
                {
                    if (Visited.Contains(other))
                        continue;
                    if (node.Equals(other))
                        continue;
                    if (node.IsOverlap(other) is false)
                        continue;

                    Visited.Add(other);
                    waiting.Enqueue(other);
                }
            }

            return 1;
        }

        private struct Rect : IEquatable<Rect>
        {
            int x1;
            int y1;
            int x2;
            int y2;
            public Rect(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }

            public bool Equals(Rect other)
            {
                return this.x1 == other.x1 && this.y1 == other.y1 && this.x2 == other.x2 && this.y2 == other.y2;
            }

            public bool IsOverlap(Rect r2)
            {
                var r1 = this;
                if (r1.x1 > r2.x1 && r1.y1 > r2.y1 && r1.x2 < r2.x2 && r1.y2 < r2.y2)
                    return false;
                if (r1.x1 < r2.x1 && r1.y1 < r2.y1 && r1.x2 > r2.x2 && r1.y2 > r2.y2)
                    return false;
                if (r1.x1 > r2.x2 || r1.y1 > r2.y2 || r2.x1 > r1.x2 || r2.y1 > r1.y2)
                    return false;

                return true;
            }
        }
    }
}