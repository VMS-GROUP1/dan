using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Sorting
{
    public class P011004
    {
        public static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            List<int> collection = Console.ReadLine().Split().Select(x => int.Parse(x)).ToList();
            collection.Sort();
            Console.WriteLine(collection[n[1] - 1]);
        }
    }
}