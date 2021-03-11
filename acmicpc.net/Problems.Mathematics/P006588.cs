using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace acmicpc.net.Problems.Mathematics
{
    public class P006588
    {
        public static void Main(string[] args)
        {
            string message = "Goldbach's conjecture is wrong.";
            StringBuilder stringBuilder = new StringBuilder();
            List<int> t = new List<int>();

            while (true)
            {
                int n = int.Parse(Console.ReadLine());
                if (n == 0)
                    break;

                t.Add(n);
            }

            var p = FindPrime(t.Max());
            var p2 = p.ToList();
            p2.Sort();

            foreach (var i in t)
            {
                var sel = new List<int>();
                foreach (var j in p2)
                {
                    if (j <= 2 || p.Contains(i - j) is false)
                        continue;

                    sel.Add(j);
                    sel.Add(i - j);
                    break;
                }

                if (sel == null || sel.Count() <= 0)
                {
                    stringBuilder.AppendLine(message);
                    continue;
                }

                stringBuilder.AppendLine($"{i} = {sel.Min()} + {sel.Max()}");
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        private static HashSet<int> FindPrime(int x)
        {
            HashSet<int> p = new HashSet<int>();
            bool[] np = new bool[x + 1];

            for (long i = 2; i <= x; i++)
            {
                if (np[i])
                    continue;

                p.Add((int)i);
                for (long j = i * i; j <= x; j += i)
                {
                    np[j] = true;
                }
            }

            return p;
        }
    }
}