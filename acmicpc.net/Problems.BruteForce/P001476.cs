using System;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001476
    {
        private static int E = 15;
        private static int S = 28;
        private static int M = 19;

        public static void Main(string[] args)
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int e = data[0];
            int s = data[1];
            int m = data[2];

            int ans = 1;
            while (true)
            {
                if ((ans - e) % E == 0 && (ans - s) % S == 0 && (ans - m) % M == 0)
                    break;

                ans++;
            }

            Console.WriteLine(ans);
        }
    }
}