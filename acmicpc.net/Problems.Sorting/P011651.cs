using System;
using System.IO;
using System.Text;

namespace acmicpc.net.Problems.Sorting
{
    public class P011651
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            (int y, int x)[] m = new (int y, int x)[n];
            for (int i = 0; i < n; i++)
            {
                var value = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                m[i] = (value[1], value[0]);
            }

            Array.Sort(m);
            using (var sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput())))
            {
                StringBuilder ans = new StringBuilder(1_600_000);
                for (int i = 0; i < n; i++)
                {
                    var value = m[i];
                    ans.Append(value.x);
                    ans.Append(' ');
                    ans.Append(value.y);
                    ans.Append('\n');
                }

                sw.Write(ans);
            }
        }
    }
}