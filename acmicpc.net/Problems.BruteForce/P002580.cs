using System;
using System.Linq;

namespace acmicpc.net.Problems.BruteForce
{
    //스도쿠
    public class P002580
    {
        private static int[][] M;
        private static int[,] R;
        private static int[] SumR;
        private static int[,] C;
        private static int[] SumC;
        private static int[,] S;
        private static int[] SumS;
        private static int[] T;
        private static int SumT;

        public static void Main(string[] args)
        {
            M = new int[9][];
            R = new int[9, 10];
            SumR = new int[9];
            C = new int[9, 10];
            SumC = new int[9];
            S = new int[9, 10];
            SumS = new int[9];
            T = new int[10];
            SumT = 0;
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
                    SumR[i] += value;
                    C[j, value] = 1;
                    SumC[j] += value;
                    S[SmallIndex(i, j), value] = 1;
                    SumS[SmallIndex(i, j)] += value;
                    T[value] += 1;
                    SumT += value;
                }
            }

            Do(0, 0, 1);
        }

        private static void Do(int r, int c, int x)
        {
            if (SumT == 405)
                return;

            if (M[r][c] != 0)
            {
                if (r + 1 < M.Length)
                    Do(r + 1, c, x);
                if (c + 1 < M[0].Length)
                    Do(r, c + 1, x);

                return;
            }

            if (x >= 1 && x <= 9 && Check(r, c, x))
            {
                M[r][c] = x;
                R[r, x] = 1;
                C[c, x] = 1;
                S[SmallIndex(r, c), x] = 1;
                T[x] += 1;
                SumR[r] += x;
                SumC[c] += x;
                SumT += x;
                Do(r + 1, c, x);
                Do(r + 1, c + 1, x);
                R[r, x] = 0;
                C[c, x] = 0;
                S[SmallIndex(r, c), x] = 0;
                T[x] -= 1;
                SumR[r] -= x;
                SumC[c] -= x;
                SumT -= x;
                M[r][c] = 0;
            }
            else
            {
                Do(r, c, x + 1);
                Do(r, c, x - 1);
            }
        }

        // private static void Do(int r, int c, int x)
        // {
        //     if (SumT == 405)
        //         return;

        //     if (M[r][c] != 0)
        //     {
        //         if (r + 1 < M.Length)
        //             Do(r + 1, c, 0);
        //         if (c + 1 < M[0].Length)
        //             Do(r, c + 1, 0);

        //         return;
        //     }

        //     for (int i = 1; i < 9; i++)
        //     {
        //         if (Check(r, c, i))
        //         {
        //             M[r][c] = i;
        //             R[r, i] = 1;
        //             C[c, i] = 1;
        //             S[SmallIndex(r, c), i] = 1;
        //             T[i] += 1;
        //             SumR[r] += i;
        //             SumC[c] += i;
        //             SumT += i;
        //             Do(r, c, i);
        //             R[r, i] = 0;
        //             C[c, i] = 0;
        //             S[SmallIndex(r, c), i] = 0;
        //             T[i] -= 1;
        //             SumR[r] -= i;
        //             SumC[c] -= i;
        //             SumT -= i;
        //             M[r][c] = 0;
        //         }
        //         // if (R[r, i] == 0 && SumR[r] + i == 45)
        //         // {
        //         //     M[r][c] = i;
        //         //     SumR[r] += i;
        //         //     SumT += i;
        //         //     Do(r, c, i);
        //         //     SumR[r] -= i;
        //         //     M[r][c] = 0;
        //         // }

        //         // if (C[c, i] == 0 && SumC[c] + i == 45)
        //         // {
        //         //     M[r][c] = i;
        //         //     SumC[c] += i;
        //         //     Do(r, c, i);
        //         //     SumC[c] -= i;
        //         //     M[r][c] = 0;
        //         // }

        //         // int s = SmallIndex(r, c);
        //         // if (S[s, i] == 0 && SumS[s] + i == 45)
        //         // {
        //         //     M[r][c] = i;
        //         //     SumS[s] += i;
        //         //     Do(r, c, i);
        //         //     SumS[s] -= i;
        //         //     M[r][c] = 0;
        //         // }
        //     }
        // }


        private static bool Check(int r, int c, int value)
        {
            if (R[r, value] == 0 && SumR[r] + value == 45)
                return true;
            if (C[c, value] == 0 && SumC[c] + value == 45)
                return true;
            if (S[SmallIndex(r, c), value] == 0 && SumS[SmallIndex(r, c)] + value == 45)
                return true;

            return false;
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