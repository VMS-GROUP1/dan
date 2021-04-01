using System;
using System.Collections.Generic;
using System.IO;

namespace acmicpc.net.Problems.DD
{
    public class P002261
    {
        private static List<(int x, int y)> m;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            m = new List<(int x, int y)>();

            for (int i = 0; i < n; i++)
            {
                int[] value = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                m.Add((value[0], value[1]));
            }

            m.Sort((x, y) => x.x.CompareTo(y.x));
            Console.WriteLine(Closest(0, m.Count - 1));
        }

        private static int Closest(int start, int end)
        {
            if (end - start == 1)
            {
                return Distance(m[start], m[end]);
            }
            else if (end - start == 2)
            {
                return Math.Min(Math.Min(Distance(m[start], m[start + 1]), Distance(m[start + 1], m[start + 2])), Distance(m[start], m[start + 2]));
            }

            int mid = (start + end) / 2;

            int left = Closest(start, mid);
            int right = Closest(mid + 1, end);
            int min = Math.Min(left, right);

            List<(int x, int y)> a = FindA(start, end, min);

            a.Sort((x, y) => x.y.CompareTo(y.y));
            min = FindB(a, min);

            return min;
        }

        private static int Distance((int x, int y) a, (int x, int y) b)
        {
            return (a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y);
        }

        private static List<(int x, int y)> FindA(int start, int end, int min)
        {
            List<(int x, int y)> a = new List<(int x, int y)>();
            int mid = (start + end) / 2;

            for (int i = start; i <= end; i++)
            {
                int d = m[mid].x - m[i].x;
                if (d * d >= min)
                    continue;

                a.Add(m[i]);
            }

            return a;
        }

        private static int FindB(List<(int x, int y)> a, int min)
        {
            int size = a.Count;

            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    int d = a[i].y - a[j].y;
                    if (d * d >= min)
                        break;

                    d = Distance(a[i], a[j]);
                    min = Math.Min(min, d);
                }
            }

            return min;
        }
    }
}