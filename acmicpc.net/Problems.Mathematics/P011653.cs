using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.Mathematics
{
    public class P011653
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
                return;

            var p = new Queue<int>(FindPrime(n));
            while (true)
            {
                if (n == 1)
                    break;
                if (n % p.Peek() != 0)
                {
                    p.Dequeue();
                    continue;
                }

                Console.WriteLine(p.Peek());
                n /= p.Peek();
            }
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