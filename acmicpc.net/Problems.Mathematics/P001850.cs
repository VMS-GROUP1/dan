using System;
using System.Linq;
using System.Text;

namespace acmicpc.net.Problems.Mathematics
{
    public class P001850
    {
        public static void Main(string[] args)
        {
            long[] t = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();
            long a = t[0];
            long b = t[1];

            long g = Gcd(a, b);
            StringBuilder builder = new StringBuilder();
            while (g-- > 0)
                builder.Append(1);

            Console.WriteLine(builder.ToString());
        }

        public static long Gcd(long a, long b)
        {
            long c = a % b;
            if (c == 0)
                return b;

            return Gcd(b, c);
        }
    }
}