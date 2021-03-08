using System;
using System.Collections.Generic;
using System.Text;

namespace acmicpc.net.Problems.Mathematics
{
    public class P001212
    {
        public static void Main(string[] args)
        {
            string n = Console.ReadLine();
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < n.Length; i++)
            {
                var a = Convert(int.Parse(n[i].ToString()), 2);
                builder.Append(int.Parse(a).ToString(i == 0 ? null : "D3"));
            }

            Console.WriteLine(builder.ToString());
        }

        public static string Convert(int x, int y)
        {
            if (x == 0)
                return "0";

            Stack<char> s = new Stack<char>();
            int a = 'A';
            int one = '1';
            int z = x;
            while (z > 0)
            {
                int remain = z % y;
                z /= y;
                s.Push(remain < 10 ? (char)(one + remain - 1) : (char)(a + remain - 10));
            }

            return string.Concat(s);
        }
    }
}