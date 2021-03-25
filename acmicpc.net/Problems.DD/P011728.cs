using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace acmicpc.net.Problems.DD
{
    public class P011728
    {
        public static void Main(string[] args)
        {
            int[] n = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            Queue<int> x = new Queue<int>(Console.ReadLine().Split().Select(x => int.Parse(x)));
            Queue<int> y = new Queue<int>(Console.ReadLine().Split().Select(x => int.Parse(x)));

            List<int> ans = new List<int>();
            while (x.Count + y.Count > 0)
            {
                if (x.TryPeek(out int xi) == false)
                {
                    ans.Add(y.Dequeue());
                }
                else if (y.TryPeek(out int yi) == false)
                {
                    ans.Add(x.Dequeue());
                }
                else if (xi < yi)
                {
                    ans.Add(x.Dequeue());
                }
                else
                {
                    ans.Add(y.Dequeue());
                }
            }

            StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
            sw.AutoFlush = true;
            sw.WriteLine(string.Join(' ', ans));
        }
    }
}
