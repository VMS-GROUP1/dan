using System;
using System.Linq;

namespace acmicpc.net.Problems.Mathematics
{
    public class P002004
    {
        public static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            long[] count = new long[2];

            count[0] = Count(n[0], 2);
            count[0] -= Count(n[0] - n[1], 2);
            count[0] -= Count(n[1], 2);

            count[1] = Count(n[0], 5);
            count[1] -= Count(n[0] - n[1], 5);
            count[1] -= Count(n[1], 5);

            Console.WriteLine(count.Min());
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