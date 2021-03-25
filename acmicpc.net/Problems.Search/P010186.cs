using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace acmicpc.net.Problems.Search
{
    public class P010816
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] count = new int[20_000_001];
            int[] card = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int m = int.Parse(Console.ReadLine());

            StringBuilder stringBuilder = new StringBuilder(600_000);
            Array.ForEach(card, x => count[x + 10_000_000]++);
            foreach (var find in Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x)))
            {
                stringBuilder.Append(count[find + 10_000_000]);
                stringBuilder.Append(' ');
            }

            using (var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                sw.Write(stringBuilder);
            }
        }
    }
}