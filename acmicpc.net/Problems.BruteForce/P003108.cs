using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.ProblemBruteForce
{
    public class P003108
    {
        private static int N;
        private static int[][,] M;
        public static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            M = new int[N][,];

            HashSet<(int, int)> point = new HashSet<(int, int)>();
            HashSet<Rect> pool = new HashSet<Rect>();

            for (int i = 0; i < N; i++)
            {
                int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

                Rect r = new Rect(p[0], p[1], p[2], p[3]);
                pool.Add(r);

                point.Add((p[0], p[1]));
                point.Add((p[0], p[3]));
                point.Add((p[2], p[3]));
                point.Add((p[2], p[1]));
            }

            int index = 0;
            Dictionary<int, HashSet<Rect>> check = new Dictionary<int, HashSet<Rect>>();
            Dictionary<Rect, int> keys = new Dictionary<Rect, int>();

            foreach (var r1 in pool)
            {
                if (keys.TryGetValue(r1, out var key) is false)
                {
                    key = index++;
                    keys.Add(r1, key);
                }

                if (check.TryGetValue(key, out var group) is false)
                {
                    group = new HashSet<Rect>();
                    check.Add(key, group);
                }

                group.Add(r1);

                foreach (var r2 in pool)
                {
                    if (r1.Equals(r2))
                        continue;

                    if (r1.IsOverlap(r2) is false)
                        continue;

                    if (keys.TryGetValue(r2, out var r2Key) && key != r2Key)
                    {
                        check.TryGetValue(r2Key, out var r2Group);
                        check.Remove(key);
                        key = r2Key;
                        r2Group.UnionWith(group);
                        foreach (var item in group)
                            keys[item] = key;
                        group = r2Group;
                        continue;
                    }

                    keys[r2] = key;
                    group.Add(r2);
                }
            }

            int ans = check.Keys.Count;
            ans += point.Contains((0, 0)) ? -1 : 0;
            Console.WriteLine(ans);
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