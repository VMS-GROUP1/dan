using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.Greedy
{
    public class P001931
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            (int end, int start)[] m = new (int end, int start)[n];

            while (n-- > 0)
            {
                int[] time = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                m[n] = (time[1], time[0]);
            }

            Array.Sort(m);
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
    }
}