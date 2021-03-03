using System;

namespace acmicpc.net.Problems.Strings
{
    public class P010820
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string str = Console.ReadLine();
                if (string.IsNullOrEmpty(str))
                    break;

                char[] word = str.ToCharArray();
                int[] count = new int[4];
                for (int j = 0; j < word.Length; j++)
                {
                    count[GetIndex(word[j])]++;
                }

                Console.WriteLine(string.Join(' ', count));
            }
        }

        private static int GetIndex(char c)
        {
            if (char.IsWhiteSpace(c))
                return 3;
            if (char.IsNumber(c))
                return 2;
            if (char.IsUpper(c))
                return 1;

            return 0;
        }
    }
}