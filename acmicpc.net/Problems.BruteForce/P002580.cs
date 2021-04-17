using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.BruteForce
{
    //스도쿠
    public class P002580
    {
        private static int[][] M;
        private static int[,] R;
        private static int[,] C;
        private static int[,] S;
        private static List<(int r, int c)> Waiting = new List<(int r, int c)>();
        private static bool Found;

        public static void Main(string[] args)
        {
            M = new int[9][];
            R = new int[9, 10];
            C = new int[9, 10];
            S = new int[9, 10];
            Waiting = new List<(int r, int c)>();
            Found = false;
            for (int i = 0; i < 9; i++)
            {
                M[i] = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    int value = M[i][j];
                    R[i, value] = 1;
                    C[j, value] = 1;
                    S[SmallIndex(i, j), value] = 1;

                    if (value == 0)
                        Waiting.Add((i, j));
                }
            }

            Do(0);

            for (int i = 0; i < M.Length; i++)
            {
                Console.WriteLine(string.Join(' ', M[i]));
            }
        }

        private static void Do(int level)
        {
            var cell = Waiting[level];
            int r = cell.r;
            int c = cell.c;

            for (int i = 1; i <= 9; i++)
            {
                if (Check(r, c, i))
                {
                    M[r][c] = i;
                    R[r, i] = 1;
                    C[c, i] = 1;
                    S[SmallIndex(r, c), i] = 1;

                    if (level == Waiting.Count - 1)
                    {
                        Found = true;
                        break;
                    }

                    Do(level + 1);
                    if (Found)
                        break;

                    M[r][c] = 0;
                    R[r, i] = 0;
                    C[c, i] = 0;
                    S[SmallIndex(r, c), i] = 0;
                }
            }
        }

        private static bool Check(int r, int c, int value)
        {
            if (R[r, value] == 1)
                return false;
            if (C[c, value] == 1)
                return false;

            int sIndex = SmallIndex(r, c);
            if (S[sIndex, value] == 1)
                return false;

            return true;
        }

        private static int SmallIndex(int r, int c)
        {
            int smallBoxR = (r / 3 * 3);
            int smallBoxC = (c / 3 * 3);
            int s = smallBoxR / 3 * 3 + smallBoxC / 3;
            return s;
        }
    }
}