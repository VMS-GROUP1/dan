using System;
using System.Collections.Generic;
using System.Text;

namespace acmicpc.net.Problems.Sorting
{
    public class P010989
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> collection = new List<int>();

            for (int i = 0; i < n; i++)
            {
                collection.Add(int.Parse(Console.ReadLine()));
            }

            collection.Sort();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                if (i != 0 && i % 4_000 == 0)
                {
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                }

                if (i != 0)
                    sb.AppendLine();

                sb.Append(collection[i]);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}