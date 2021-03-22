using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace acmicpc.net.Problems.Search
{
    public class P010816
    {
        private static int Convert(int x) => x >= 0 ? x : 10_000_000 - x;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] count = new int[20_000_001];
            List<int> card = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
            int m = int.Parse(Console.ReadLine());
            List<int> find = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

            card.ForEach(x => count[Convert(x)]++);

            List<int> ans = new List<int>();
            find.ForEach(x => ans.Add(count[Convert(x)]));
            Console.WriteLine(string.Join(' ', ans));
        }

        // public static void Main(string[] args)
        // {
        //     int n = int.Parse(Console.ReadLine());
        //     List<int> card = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
        //     int m = int.Parse(Console.ReadLine());
        //     List<int> find = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

        //     card.Sort();
        //     List<int> ans = new List<int>();
        //     find.ForEach(x => ans.Add(Search(card, x)));
        //     Console.WriteLine(string.Join(' ', ans));
        // }

        // public static void Main(string[] args)
        // {
        //     int n = int.Parse(Console.ReadLine());
        //     Dictionary<int, int> count = new Dictionary<int, int>();
        //     var card = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
        //     card.ForEach(x => count[x] = count.TryAdd(x, 1) ? 1 : count[x] + 1);

        //     int m = int.Parse(Console.ReadLine());
        //     List<int> find = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();

        //     // card = count.Keys.ToList();
        //     // card.Sort();
        //     List<int> ans = new List<int>();
        //     //find.ForEach(x => ans.Add(Search(card, x) ? 1 : 0));
        //     find.ForEach(x => ans.Add(count.TryGetValue(x, out var i) ? i : 0));
        //     Console.WriteLine(string.Join(' ', ans));
        // }

        public static int Search(List<int> card, int want)
        {
            int u = card.Count - 1;
            int l = 0;
            int index = -1;

            if (card[l] == want)
                return Move(card, l + 1, want, 1, 1);
            if (card[u] == want)
                return Move(card, u - 1, want, -1, 1);

            while (l <= u)
            {
                int m = (l + u) / 2;
                var check = card[m].CompareTo(want);

                if (check == 0)
                {
                    index = m;
                    break;
                }

                if (check < 0)
                    l = m + 1;
                else
                    u = m - 1;
            }

            if (index == -1)
                return 0;

            return Move(card, index - 1, want, -1, 1) + Move(card, index + 1, want, 1, 0);
        }

        public static int Move(List<int> card, int index, int want, int variation, int ans)
        {
            if (index < 0 || index == card.Count || card[index] != want)
                return ans;

            return Move(card, index + variation, want, variation, ++ans);
        }
    }
}