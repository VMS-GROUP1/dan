using System;
using System.Text;

namespace acmicpc.net.Problems.Greedy
{
    public class P002873
    {
        private static StringBuilder ans;
        private static char R = 'R';
        private static char L = 'L';
        private static char U = 'U';
        private static char D = 'D';
        private static int[,] m;
        private static int Row;
        private static int Col;
        private static string nr;
        private static string nl;
        private static string nd;
        private static string nu;

        public static void Main(string[] args)
        {
            ans = new StringBuilder(1_100_000);

            int[] n = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            Row = n[0];
            Col = n[1];
            m = new int[Row + 1, Col + 1];

            for (int i = 1; i <= Row; i++)
            {
                var value = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                int length = value.Length;
                for (int j = 0; j < length; j++)
                {
                    m[i, j + 1] = value[j];
                }
            }

            nr = new string(R, Col - 1);
            nl = new string(L, Col - 1);
            nd = new string(D, Row - 1);
            nu = new string(U, Row - 1);

            if (Row % 2 == 1)
            {
                NormalRepeat(nr, nl, Row, D);
            }
            else if (Col % 2 == 1)
            {
                NormalRepeat(nd, nu, Col, R);
            }
            else
            {
                SpecialRepeat();
            }

            Console.WriteLine(ans);
        }

        private static void NormalRepeat(string odd, string even, int count, char move)
        {
            for (int i = 1; i <= count; i++)
            {
                if (i % 2 == 1)
                    ans.Append(odd);
                else
                    ans.Append(even);

                if (i < count)
                    ans.Append(move);
            }
        }

        private static void SpecialRepeat()
        {
            var min = Min();
            string odd = nr;
            string even = nl;

            for (int i = 1; i <= Row; i++)
            {
                if (i == min.r || (i % 2 == 1 && i + 1 == min.r))
                {
                    Avoid(min, i);
                    odd = nl;
                    even = nr;
                    i++;
                    continue;
                }

                ans.Append(i % 2 == 1 ? odd : even);

                if (i < Row)
                    ans.Append(D);
            }
        }

        private static void Avoid((int r, int c) min, int r)
        {
            int odd = 1;

            for (int i = 1; i <= Col; i++)
            {
                int add = i % 2 == 1 ? odd : -odd;

                if (i == min.c && r + add == min.r)
                {
                    odd *= -1;
                }
                else
                {
                    ans.Append(add > 0 ? D : U);
                    r += add;
                }

                if (i != Col)
                    ans.Append(R);
            }

            if (r < Row)
                ans.Append(D);
        }

        private static (int r, int c) Min()
        {
            int min = int.MaxValue;
            int minR = 0;
            int minC = 0;

            for (int i = 1; i <= Row; i++)
            {
                for (int j = 1; j <= Col; j++)
                {
                    if ((i + j) % 2 == 0)
                        continue;

                    int value = m[i, j];
                    if (value < min)
                    {
                        min = value;
                        minR = i;
                        minC = j;
                    }
                }
            }

            return (minR, minC);
        }
    }
}