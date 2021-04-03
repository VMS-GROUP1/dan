using System;

namespace acmicpc.net.Problems.Greedy
{
    public class P011047
    {
        private static int ans;
        private static int n;
        private static int k;
        public static void Main(string[] args)
        {
            int[] data = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            n = data[0];
            k = data[1];
            ans = 0;
            Do();
            Console.WriteLine(ans);
        }

        private static void Do()
        {
            if (n <= 0)
                return;

            int c = int.Parse(Console.ReadLine());
            n--;

            Do();

            if (c > k)
                return;
            if (k <= 0)
                return;

            int count = k / c;
            k -= count * c;
            ans += count;
            return;
        }
    }
}