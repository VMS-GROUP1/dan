using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Sorting
{
    public class P010814
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<(int, string)> members = new List<(int, string)>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                members.Add((int.Parse(input[0]), input[1]));
            }

            var sorted = members.OrderBy(x => x.Item1);

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Item1} {item.Item2}");
            }
        }
    }
}