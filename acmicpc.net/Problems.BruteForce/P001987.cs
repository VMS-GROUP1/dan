using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001987
    {
        private static char[][] Board;
        private static HashSet<char> S;
        private static int R;
        private static int C;
        private static int ANS;
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            R = p[0];
            C = p[1];
            Board = new char[R][];

            for (int i = 0; i < R; i++)
            {
                Board[i] = Console.ReadLine().ToCharArray();
            }

            S = new HashSet<char>();
            int count = 1;
            ANS = 0;
            S.Add(Board[0][0]);
            Do(0, 0, count);
            Console.WriteLine(ANS);
        }

        private static void Do(int x, int y, int count)
        {
            ANS = Math.Max(count, ANS);

            for (int i = 0; i < 4; i++)
            {
                int xi = x;
                int yi = y;

                if (i == 0) xi++;
                if (i == 1) xi--;
                if (i == 2) yi++;
                if (i == 3) yi--;

                if (xi >= 0 && xi < Board.Length && yi >= 0 && yi < Board[0].Length)
                {
                    var c = Board[xi][yi];
                    if (S.Contains(c) is false)
                    {
                        S.Add(c);
                        Do(xi, yi, count + 1);
                        S.Remove(c);
                    }
                }
            }
        }
    }
}