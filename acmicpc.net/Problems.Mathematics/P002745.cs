using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.Mathematics
{
    public class P002745
    {
        public static void Main(string[] args)
        {
            string[] n = Console.ReadLine().Split();
            Console.WriteLine(Convert(n[0], int.Parse(n[1])));
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