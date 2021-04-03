using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.Greedy
{
    public class P001931
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            (int start, int end)[] m = new (int start, int end)[n];

            while (n-- > 0)
            {
                int[] time = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                m[n] = (time[0], time[1]);
            }

            Array.Sort(m, new TimeComparer());
            int ans = 0;
            int last = 0;

            while (++n < m.Length)
            {
                var t = m[n];
                if (t.start < last)
                    continue;

                last = t.end;
                ans++;
            }

            Console.WriteLine(ans);
        }

        private class TimeComparer : Comparer<(int start, int end)>
        {
            public override int Compare((int start, int end) x, (int start, int end) y)
            {
                int cmp = x.end.CompareTo(y.end);
                if (cmp != 0)
                    return cmp;

                return x.start.CompareTo(y.start);
            }
        }
    }
}