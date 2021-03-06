using System;

namespace acmicpc.net.Problems.Strings
{
    public class P001120
    {
        public static void Main(string[] args)
        {
            string[] str = Console.ReadLine().Split();

            int min = str[0].Length;

            for (int i = 0; i <= str[1].Length - str[0].Length; i++)
            {
                int count = 0;

                for (int j = 0; j < str[0].Length; j++)
                {
                    count += str[0][j] - str[1][j + i] == 0 ? 0 : 1;
                }

                min = Math.Min(count, min);
            }

            Console.WriteLine(min);
        }
    }
}