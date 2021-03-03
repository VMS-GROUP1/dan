using System;

namespace acmicpc.net.Problems.Strings
{
    public class P010824
    {
        public static void Main(string[] args)
        {
            string[] number = Console.ReadLine().Split();
            Console.WriteLine(long.Parse(number[0] + number[1]) + long.Parse(number[2] + number[3]));
        }
    }
}