using System;

namespace acmicpc.net.Problems.IF
{
    //두 수 비교하기
    public class P001330
    {
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            int a = p[0];
            int b = p[1];

            if (a > b)
                Console.WriteLine(">");
            else if (a < b)
                Console.WriteLine("<");
            else
                Console.WriteLine("==");
        }
    }
}