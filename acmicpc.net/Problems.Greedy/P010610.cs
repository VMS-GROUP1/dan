using System;
using System.Linq;

namespace acmicpc.net.Problems.Greedy
{
    public class P010610
    {
        private static int zero = '0';
        public static void Main(string[] args)
        {
            char[] data = Console.ReadLine().ToCharArray();
            Array.Sort(data, (x, y) => x.CompareTo(y) * -1);

            if (data[data.Length - 1] - zero > 0 || data.Sum(x => x - zero) % 3 > 0)
            {
                Console.WriteLine(-1);
                return;
            }

            Console.WriteLine(data);
        }
    }
}