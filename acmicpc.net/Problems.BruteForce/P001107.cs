using System;
using System.Linq;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001107
    {
        private static bool[] fail;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[] x = new int[0];
            if (m > 0)
                x = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

            fail = new bool[10];
            for (int i = 0; i < m; i++)
            {
                fail[x[i]] = true;
            }

            int ans = Math.Abs(n - 100);

            if (m < 10)
            {
                ans = Find(n, -1, -1, ans);
                ans = Find(n, n + ans, 1, ans);
            }

            Console.WriteLine(ans);
        }

        private static int Find(int x, int limit, int a, int ans)
        {
            int i = x;
            while (i != limit)
            {
                bool check = true;
                int j = i;
                int count = 0;
                while (j > 0 || i == 0)
                {
                    int d = j % 10;
                    check = !fail[d];
                    if (check is false)
                        break;

                    j /= 10;
                    count++;

                    if (i == 0)
                        break;
                }

                if (check && Math.Abs(x - i) + count < ans)
                {
                    ans = Math.Abs(x - i) + count;
                    break;
                }

                i += a;
            }

            return ans;
        }
    }
}