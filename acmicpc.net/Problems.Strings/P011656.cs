using System;
using System.Collections.Generic;
using System.Text;

namespace acmicpc.net.Problems.Strings
{
    public class P011656
    {
        public static void Main(string[] args)
        {
            List<string> output = new List<string>();
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) is false)
            {
                output.Add(input);
                input = input.Substring(1);
            }

            output.Sort();
            Console.WriteLine(string.Join('\n', output));
        }
    }
}