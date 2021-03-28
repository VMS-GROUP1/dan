using System;

namespace acmicpc.net.Problems.Search
{
    public class P011662
    {
        private static double Tol = 1e-8;
        public static void Main(string[] args)
        {
            double[] x = Array.ConvertAll(Console.ReadLine().Split(), x => double.Parse(x));
            double ax = x[0];
            double ay = x[1];
            double bx = x[2];
            double by = x[3];
            double cx = x[4];
            double cy = x[5];
            double dx = x[6];
            double dy = x[7];

            double left = 0;
            double right = 1;

            double dx1 = bx - ax;
            double dy1 = by - ay;
            double dx2 = dx - cx;
            double dy2 = dy - cy;

            while (right - left > Tol)
            {
                double l = left + (right - left) / 3;
                double u = right - (right - left) / 3;
                double a1x = ax + dx1 * l;
                double a1y = ay + dy1 * l;
                double a2x = cx + dx2 * l;
                double a2y = cy + dy2 * l;

                double b1x = ax + dx1 * u;
                double b1y = ay + dy1 * u;
                double b2x = cx + dx2 * u;
                double b2y = cy + dy2 * u;

                double distance1 = Math.Sqrt((a1x - a2x) * (a1x - a2x) + (a1y - a2y) * (a1y - a2y));
                double distance2 = Math.Sqrt((b1x - b2x) * (b1x - b2x) + (b1y - b2y) * (b1y - b2y));
                if (distance1 < distance2)
                {
                    right = u;
                }
                else
                {
                    left = l;
                }
            }

            double found = (right + left) / 2;
            double r1x = ax + dx1 * found;
            double r1y = ay + dy1 * found;
            double r2x = cx + dx2 * found;
            double r2y = cy + dy2 * found;

            Console.WriteLine(Math.Sqrt((r1x - r2x) * (r1x - r2x) + (r1y - r2y) * (r1y - r2y)));
        }
    }
}