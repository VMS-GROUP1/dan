using System;
using System.Linq;
using System.Text;

namespace acmicpc.net.Problems.Mathematics
{
    public class P001934
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder stringBuilder = new StringBuilder();

            while (n > 0)
            {
                int[] t = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                int a = t[0];
                int b = t[1];

                stringBuilder.AppendLine(Lcm(a, b).ToString());
                n--;
            }

            Console.WriteLine(stringBuilder.ToString());
        }

        public static int Gcd(int a, int b)
        {
            int c = a % b;
            if (c == 0)
                return b;

            return Gcd(b, c);
        }

        public static int Lcm(int a, int b)
        {
            int c = Gcd(a, b);
            return c * (a / c) * (b / c);
        }
    }
}