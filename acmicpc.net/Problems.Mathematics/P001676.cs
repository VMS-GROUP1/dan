using System;

namespace acmicpc.net.Problems.Mathematics
{
    public class P001676
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Count(n, 5));
        }

        private static long Count(int x, int p)
        {
            long count = 0;

            for (long i = p; i <= x; i *= p)
            {
                count += x / i;
            }

            return count;
        }
    }
}