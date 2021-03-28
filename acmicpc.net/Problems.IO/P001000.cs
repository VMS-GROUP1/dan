using System;
using System.IO;

namespace acmicpc.net.Problems.IO
{
    class P001000
    {
        public static void Main(string[] args)
        {
            var n = Console.ReadLine();
            using (var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                sw.Write(n[0] + n[2] - 2 * '0');
            }
        }
    }
}