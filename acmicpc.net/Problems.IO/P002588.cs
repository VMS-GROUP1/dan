using System;

namespace acmicpc.net.Problems.IO
{
    //곱셈
    public class P002588
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            int c = a * (b % 10);
            int d = a * (b % 100 / 10);
            int e = a * (b / 100);

            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(e * 100 + d * 10 + c);
        }
    }
}