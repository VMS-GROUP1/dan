using System;
using System.Linq;

namespace acmicpc.net.Problems.IO
{
    //A+B - 7
    public class P011021
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var values = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                Console.WriteLine($"Case #{i+1}: {values[0] + values[1]}");
            }
        }
    }
}