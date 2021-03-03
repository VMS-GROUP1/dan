using System;

namespace acmicpc.net.Problems.Strings
{
    public class P010808
    {
        public static void Main(string[] args)
        {
            int[] count = new int[26];
            int a = (int)'a';

            char[] word = Console.ReadLine().ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                count[(int)word[i] - a]++;
            }

            Console.WriteLine(string.Join(' ', count));
        }
    }
}