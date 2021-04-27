using System;

namespace acmicpc.net.Problems.IF
{
    //사분면 고르기
    public class P014681
    {
        public static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            int a = x > 0 ? 1 : 2;
            int b = y > 0 ? 0 : 4 / a - 1;

            Console.WriteLine(a + b);
        }
    }
}