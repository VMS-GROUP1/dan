using System;
using System.Linq;

namespace acmicpc.net.Problems.Mathematics
{
    public class P002609
    {
        public static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int a = n[0];
            int b = n[1];

            Console.WriteLine(Gcd(a, b));
            Console.WriteLine(Lcm(a, b));
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