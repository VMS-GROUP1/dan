using System;

namespace acmicpc.net.Problems.Greedy
{
    public class P011047
    {
        public static void Main(string[] args)
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int n = data[0];
            int k = data[1];
            int[] coin = new int[n];
            int max = 0;

            while (n > 0)
            {
                coin[--n] = int.Parse(Console.ReadLine());
                if (coin[n] <= k)
                    max = n;
            }

            int ans = 0;
            n = max;
            while (k > 0)
            {
                int count = k / coin[n];
                k -= count * coin[n++];
                ans += count;
            }

            Console.WriteLine(ans);
        }
    }
}