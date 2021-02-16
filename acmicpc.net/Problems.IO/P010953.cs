using System;
using System.Linq;

namespace acmicpc.net.Problems.IO
{
    //A+B - 6
    public class P010953
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var values = Console.ReadLine().Split(',').Select(x => int.Parse(x)).ToArray();
                Console.WriteLine(values[0] + values[1]);
            }
        }
    }
}