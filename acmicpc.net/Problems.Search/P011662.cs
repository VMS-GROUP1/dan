using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace acmicpc.net.Problems.Search
{
    public class P011662
    {
        private static double Tol = 1e-8;
        public static void Main(string[] args)
        {
            int[] x = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            Coordinate[] coord = new Coordinate[4];
            for (int i = 0; i < coord.Length; i++)
            {
                coord[i] = new Coordinate(x[i * 2], x[i * 2 + 1]);
            }

            (double min, double max) ratio = (0, 1);

            while (ratio.max - ratio.min > Tol)
            {
                double l = ratio.min + (ratio.max - ratio.min) / 3;
                double u = ratio.max - (ratio.max - ratio.min) / 3;
                var lCoord1 = coord[0].Point(coord[1], l);
                var lCoord2 = coord[2].Point(coord[3], l);
                var uCoord1 = coord[0].Point(coord[1], u);
                var uCoord2 = coord[2].Point(coord[3], u);

                if (lCoord1.Distance(lCoord2) < uCoord1.Distance(uCoord2))
                {
                    ratio = (ratio.min, u);
                }
                else
                {
                    ratio = (l, ratio.max);
                }
            }

            double found = (ratio.max + ratio.min) / 2;

            Console.WriteLine(coord[0].Point(coord[1], found).Distance(coord[2].Point(coord[3], found)));
        }

        private struct Coordinate
        {
            internal double X;
            internal double Y;

            internal Coordinate(double x, double y)
            {
                X = x;
                Y = y;
            }

            internal double Distance(Coordinate other)
            {
                return Math.Sqrt((this.X - other.X) * (this.X - other.X) + (this.Y - other.Y) * (this.Y - other.Y));
            }

            internal Coordinate Point(Coordinate other, double ratio)
            {
                return new Coordinate(this.X + (other.X - this.X) * ratio, this.Y + (other.Y - this.Y) * ratio);
            }
        }
    }
}