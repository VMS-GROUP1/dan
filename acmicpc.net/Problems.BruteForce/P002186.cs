using System;
using System.Collections.Generic;
using System.Text;

namespace acmicpc.net.Problems.BruteForce
{
    public class P002186
    {
        private static int ans;
        private static string word;
        private static int[,,] memo;
        private static char[,] d;
        private static int n;
        private static int m;
        private static int k;
        public static void Main(string[] args)
        {
            ans = 0;
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

            n = p[0];
            m = p[1];
            k = p[2];
            d = new char[n, m];
            memo = new int[n, m, 80];

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < m; j++)
                {
                    var c = row[j];
                    d[i, j] = c;

                    for (int l = 0; l < 80; l++)
                    {
                        memo[i, j, l] = -1;
                    }
                }
            }

            word = Console.ReadLine();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (d[i, j] != word[0])
                        continue;

                    ans += Dfs(i, j, 0);
                }
            }

            Console.WriteLine(ans);
        }

        private static int Dfs(int r, int c, int index)
        {
            if (memo[r, c, index] != -1)
                return memo[r, c, index];

            if (index == word.Length - 1)
                return 1;

            memo[r, c, index] = 0;
            for (int i = 1; i <= k; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    int rd = (j % 2) * i * ((j - 1) / 2 * 2 - 1) + r;
                    int cd = ((j - 1) % 2) * i * ((j - 1) / 2 * 2 - 1) + c;

                    if (rd < 0 || cd < 0 || rd >= n || cd >= m)
                        continue;
                    if (d[rd, cd] != word[index + 1])
                        continue;

                    memo[r, c, index] += Dfs(rd, cd, index + 1);
                }
            }

            return memo[r, c, index];
        }
    }
}