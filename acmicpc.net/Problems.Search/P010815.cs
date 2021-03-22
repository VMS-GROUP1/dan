using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Search
{
    public class P010815
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> card = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
            int m = int.Parse(Console.ReadLine());
            List<int> find = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

            card.Sort();
            List<int> ans = new List<int>();
            find.ForEach(x => ans.Add(Search(card, x) ? 1 : 0));
            Console.WriteLine(string.Join(' ', ans));
        }

        public static bool Search(List<int> card, int want)
        {
            int u = card.Count - 1;
            int l = 0;
            int check = 1;

            if (card[l] == want || card[u] == want)
                return true;

            while (l <= u)
            {
                int m = (l + u) / 2;
                check = card[m].CompareTo(want);

                if (check == 0)
                    break;

                if (check < 0)
                    l = m + 1;
                else
                    u = m - 1;
            }

            return check == 0;
        }
    }
}