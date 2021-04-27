using System;

namespace acmicpc.net.Problems.IF
{
    //윤년
    public class P002753
    {
        public static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            int ans = p % 4 == 0 && (p % 100 > 0 || p % 400 == 0) ? 1 : 0;
            Console.WriteLine(ans);
        }
    }
}