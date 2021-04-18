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
        private static List<(int r, int c)>[] point;
        public static void Main(string[] args)
        {
            ans = 0;
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));

            n = p[0];
            m = p[1];
            k = p[2];
            d = new char[n, m];
            point = new List<(int, int)>[26];
            memo = new int[n, m, 80];

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine().ToCharArray();
                for (int j = 0; j < row.Length; j++)
                {
                    var c = row[j];
                    d[i, j] = c;

                    if (point[c - 'A'] == null)
                        point[c - 'A'] = new List<(int, int)>();

                    point[c - 'A'].Add((i, j));

                    for (int l = 0; l < 80; l++)
                    {
                        memo[i, j, l] = -1;
                    }
                }
            }

            word = Console.ReadLine();

            foreach (var index in point[word[0] - 'A'])
            {
                ans += Dfs(index.r, index.c, 1);
            }

            Console.WriteLine(ans);
        }

        private static int Dfs(int r, int c, int length)
        {
            if (memo[r, c, length] != -1)
                return memo[r, c, length];

            if (length == word.Length)
                return 1;

            memo[r, c, length] = 0;
            for (int i = 1; i <= k; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    int rd = (j % 2) * k * ((j - 1) / 2 * 2 - 1) + r;
                    int cd = ((j - 1) % 2) * k * ((j - 1) / 2 * 2 - 1) + c;

                    if (rd < 0 || cd < 0 || rd >= n || cd >= m)
                        continue;
                    if (d[rd, cd] != word[length])
                        continue;

                    memo[r, c, length] = memo[r, c, length] + Dfs(rd, cd, length + 1);
                }
            }

            return memo[r, c, length];
        }
    }
}