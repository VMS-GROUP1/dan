using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace acmicpc.net.Problems.Search
{
    public class P010815
    {
        public static void Main(string[] args)
        {
            Console.ReadLine();
            var card = new HashSet<string>(Console.ReadLine().Split());
            Console.ReadLine();

            StringBuilder stringBuilder = new StringBuilder(600_000);
            foreach (var find in Console.ReadLine().Split())
            {
                stringBuilder.Append(card.Contains(find) ? 1 : 0);
                stringBuilder.Append(' ');
            }

            using (var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                sw.Write(stringBuilder);
            }
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