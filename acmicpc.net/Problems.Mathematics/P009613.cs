using System;
using System.Linq;
using System.Text;

namespace acmicpc.net.Problems.Mathematics
{
    public class P009613
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder builder = new StringBuilder();

            while (n-- > 0)
            {
                int[] t = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                long ans = 0;

                for (int i = 1; i < t.Length; i++)
                {
                    for (int j = i + 1; j < t.Length; j++)
                    {
                        ans += Gcd(t[i], t[j]);
                    }
                }

                builder.AppendLine(ans.ToString());
            }

            Console.WriteLine(builder.ToString());
        }

        public static int Gcd(int a, int b)
        {
            int c = a % b;
            if (c == 0)
                return b;

            return Gcd(b, c);
        }
    }
}