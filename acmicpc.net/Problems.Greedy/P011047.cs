using System;

namespace acmicpc.net.Problems.Greedy
{
    public class P011047
    {
        public static void Main(string[] args)
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int n = data[0];
            int[] coin = new int[n];

            while (n > 0)
            {
                coin[--n] = int.Parse(Console.ReadLine());
            }

            int ans = 0;
            int k = data[1];
            n = 0;
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