using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    //소수의 연속합
    public class P001644
    {
        private static List<int> PrimeNumbers;
        private static int n;
        public static void Main(string[] args)
        {
            PrimeNumbers = new List<int>();
            n = int.Parse(Console.ReadLine());
            SieveOfEratosthenes();

            int ans = 0;
            int i = 0;
            int j = i;
            int sum = 0;
            int count = PrimeNumbers.Count;

            while (i < count)
            {
                sum += PrimeNumbers[j];

                if (sum > n)
                {
                    sum -= PrimeNumbers[i++];
                    sum -= PrimeNumbers[j];
                    continue;
                }

                if (sum == n)
                {
                    ans++;
                }

                if (j + 1 < count)
                {
                    j++;
                }
            }

            Console.WriteLine(ans);
        }

        private static void SieveOfEratosthenes()
        {
            bool[] np = new bool[n + 1];

            for (long i = 2; i <= n; i++)
            {
                if (np[i])
                    continue;

                PrimeNumbers.Add((int)i);
                for (long j = i * i; j <= n; j += i)
                {
                    np[j] = true;
                }
            }
        }
    }
}