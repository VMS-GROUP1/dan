using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Mathematics
{
    public class P011576
    {
        public static void Main(string[] args)
        {
            int[] a = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int b = int.Parse(Console.ReadLine());
            int[] c = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            Stack<int> s = new Stack<int>(c);

            int a1 = 0;
            int t = 1;
            while (s.Count > 0)
            {
                a1 += s.Pop() * t;
                t *= a[0];
            }

            while (a1 > 0)
            {
                int remain = a1 % a[1];
                a1 /= a[1];
                s.Push(remain);
            }

            Console.WriteLine(string.Join(' ', s));
        }
    }
}