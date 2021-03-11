using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.Mathematics
{
    public class P002089
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> s = new Stack<int>();
            while (n != 0)
            {
                int remain = n % -2;
                if (remain == -1)
                {
                    n = (n + remain) / -2;
                    remain = 1;
                }
                else
                {
                    n /= -2;
                }

                s.Push(remain);
            }

            if (s.Count <= 0)
                s.Push(0);

            Console.WriteLine(string.Concat(s));
        }
    }
}