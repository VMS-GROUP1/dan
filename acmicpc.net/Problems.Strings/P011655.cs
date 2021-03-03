using System;

namespace acmicpc.net.Problems.Strings
{
    public class P011655
    {
        public static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();
            string output = null;
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsLower(c))
                {
                    output += (char)(c + 13 > 'z' ? c + 13 - 'z' - 1 + 'a' : c + 13);
                }
                else if (char.IsUpper(c))
                {
                    output += (char)(c + 13 > 'Z' ? c + 13 - 'Z' - 1 + 'A' : c + 13);
                }
                else
                {
                    output += c;
                }
            }

            Console.WriteLine(output);
        }
    }
}