using System;

namespace acmicpc.net.Problems.IO
{
    //A×B
    public class P010998
    {
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            Console.WriteLine(p[0] * p[1]);
        }
    }
}