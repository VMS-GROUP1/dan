using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.Mathematics
{
    public class P001373
    {
        public static void Main(string[] args)
        {
            string n = Console.ReadLine();
            Console.WriteLine(MyConversion(Convert(n, 2), 8));
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

        public static int Convert(string x, int y)
        {
            int a = 'A';
            int one = '1';

            Stack<char> s = new Stack<char>(x);
            int count = 1;
            int z = 0;
            while (s.Count > 0)
            {
                var c = s.Pop();
                z += count * (c >= a ? c - a + 10 : c - one + 1);
                count *= y;
            }

            return z;
        }
    }
}