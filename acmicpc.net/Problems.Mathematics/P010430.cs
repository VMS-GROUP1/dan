using System;
using System.Linq;

namespace acmicpc.net.Problems.Mathematics
{
    public class P010430
    {
        public static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int a = n[0];
            int b = n[1];
            int c = n[2];

            Console.WriteLine((a + b) % c);
            Console.WriteLine(((a % c) + (b % c)) % c);
            Console.WriteLine((a * b) % c);
            Console.WriteLine(((a % c) * (b % c)) % c);
        }
    }
}