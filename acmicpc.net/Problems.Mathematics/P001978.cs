using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Mathematics
{
    public class P001978
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> c = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
            Console.WriteLine(c.Count(x => FindPrime(c.Max()).Contains(x)));
        }

        private static HashSet<int> FindPrime(int x)
        {
            HashSet<int> p = new HashSet<int>();
            bool[] np = new bool[x + 1];

            for (int i = 2; i <= x; i++)
            {
                if (np[i])
                    continue;

                p.Add(i);
                for (int j = i * i; j <= x; j += i)
                {
                    np[j] = true;
                }
            }

            return p;
        }
    }
}