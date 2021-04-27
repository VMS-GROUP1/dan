using System;

namespace acmicpc.net.Problems.IO
{
    //A/B
    public class P001008
    {
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            double ans = (double)p[0] / p[1];
            Console.WriteLine(ans);
        }
    }
}