using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Search
{
    public class P002110
    {
        public static void Main(string[] args)
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int n = data[0];
            int c = data[1];

            List<int> items = new List<int>();
            for (int i = 0; i < n; i++)
            {
                items.Add(int.Parse(Console.ReadLine()));
            }

            items.Sort();
            Console.WriteLine(Search(items, c));
        }

        public static int Search(List<int> items, int want)
        {
            int u = items[items.Count - 1] - items[0];
            int l = 0;
            int ans = l;

            if (Check(items, u, want))
                return u;

            while (l <= u)
            {
                int m = (l + u) / 2;

                if (Check(items, m, want))
                {
                    ans = Math.Max(ans, m);
                    l = m + 1;
                }
                else
                {
                    u = m - 1;
                }
            }

            return ans;
        }

        private static bool Check(List<int> items, int distance, int count)
        {
            Stack<int> check = new Stack<int>();

            foreach (var i in items)
            {
                if (check.Count > 0 && Math.Abs(check.Peek() - i) < distance)
                    continue;

                check.Push(i);
                count--;
            }

            return count <= 0;
        }
    }
}