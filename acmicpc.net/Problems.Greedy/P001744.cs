using System;

namespace acmicpc.net.Problems.Greedy
{
    public class P001744
    {
        private static int[] m;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            m = new int[n];

            int countP = 0;
            int countZ = 0;
            int countN = 0;

            for (int i = 0; i < n; i++)
            {
                int value = int.Parse(Console.ReadLine());
                if (value > 0)
                    countP++;
                else if (value == 0)
                    countZ++;
                else
                    countN++;

                m[i] = value;
            }

            Array.Sort(m);
            int ans = 0;
            int needZero = countN % 2 == 1 ? 1 : 0;

            for (int i = n - 1; i >= 0; i--)
            {
                int value = m[i];

                if (countP >= 2)
                {
                    if (value > 1 && m[i - 1] > 1)
                    {
                        ans += (value * m[--i]);
                        countP -= 2;
                        continue;
                    }
                    else
                    {
                        ans += value + m[--i];
                        countP -= 2;
                        continue;
                    }
                }
                else if (countP == 1)
                {
                    ans += value;
                    countP--;
                    continue;
                }

                if (value == 0)
                {
                    if (needZero == 1 && countZ == 1)
                    {
                        ans += (value * m[--i]);
                        countZ--;
                        countN--;
                        continue;
                    }

                    countZ--;
                    continue;
                }

                if (countN % 2 == 1)
                {
                    ans += value;
                    countN--;
                    continue;
                }
                else if (countN >= 2)
                {
                    ans += (value * m[--i]);
                    countN -= 2;
                    continue;
                }
            }

            Console.WriteLine(ans);
        }
    }
}