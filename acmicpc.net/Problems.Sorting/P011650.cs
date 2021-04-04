using System;
using System.IO;
using System.Text;

namespace acmicpc.net.Problems.Sorting
{
    public class P011650
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            (int x, int y)[] m = new (int x, int y)[n];
            for (int i = 0; i < n; i++)
            {
                var value = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                m[i] = (value[0], value[1]);
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