using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Strings
{
    public class P010809
    {
        public static void Main(string[] args)
        {
            int[] point = new int[26];
            int a = (int)'a';

            for (int i = 0; i < point.Length; i++)
            {
                point[i] = -1;
            }

            var word = Console.ReadLine().ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                int index = (int)word[i] - a;
                if (point[index] < 0)
                    point[index] = i;
            }

            Console.WriteLine(string.Join(' ', point));
        }
    }
}