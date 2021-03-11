using System;

namespace acmicpc.net.Problems.Mathematics
{
    public class P010872
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Factorial(n));
        }

        private static long Factorial(int x, int y = 1)
        {
            if (x <= 1)
                return y;

            return Factorial(x - 1, x * y);
        }
    }
}