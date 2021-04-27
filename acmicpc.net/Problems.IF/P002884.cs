using System;

namespace acmicpc.net.Problems.IF
{
    //알람 시계
    public class P002884
    {
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int h = p[0];
            int m = p[1];

            int m1 = m + 60 - 45;
            int h1 = ((h == 0 ? 23 : h - 1) + m1 / 60) % 24;
            Console.WriteLine($"{h1} {m1 % 60}");
        }
    }
}