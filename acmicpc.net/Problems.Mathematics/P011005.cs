using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Mathematics
{
    public class P011005
    {
        public static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Console.WriteLine(MyConversion(n[0], n[1]));
        }

        public static string MyConversion(int x, int y)
        {
            Stack<char> s = new Stack<char>();
            int a = 'A';
            int one = '1';
            int z = x;
            while (z > 0)
            {
                int remain = z % y;
                z /= y;
                s.Push(remain < 10 ? (char)(one + remain - 1) : (char)(a + remain - 10));
            }

            return string.Concat(s);
        }
    }
}