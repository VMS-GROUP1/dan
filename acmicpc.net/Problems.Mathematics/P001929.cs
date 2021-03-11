using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Mathematics
{
    public class P001929
    {
        public static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Console.WriteLine(string.Join('\n', FindPrime(n[1]).Where(x => x >= n[0])));
        }
        private static List<int> FindPrime(int x)
        {
            List<int> p = new List<int>();
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