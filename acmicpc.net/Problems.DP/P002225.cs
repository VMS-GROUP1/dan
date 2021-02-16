using System;
using System.Linq;

namespace acmicpc.net.Problems.DP
{
    /* 합분해 분류
    시간 제한	메모리 제한	제출	정답	맞은 사람	정답 비율
    2 초	128 MB	20618	8958	6445	41.992%
    문제
    0부터 N까지의 정수 K개를 더해서 그 합이 N이 되는 경우의 수를 구하는 프로그램을 작성하시오.

    덧셈의 순서가 바뀐 경우는 다른 경우로 센다(1+2와 2+1은 서로 다른 경우). 또한 한 개의 수를 여러 번 쓸 수도 있다.

    입력
    첫째 줄에 두 정수 N(1 ≤ N ≤ 200), K(1 ≤ K ≤ 200)가 주어진다.

    출력
    첫째 줄에 답을 1,000,000,000으로 나눈 나머지를 출력한다.

    예제 입력 1 
    20 2
    예제 출력 1 
    21 */
    public class P002225
    {
        private static int[][] Memo;// = new int[200][];
        private const int Quotient = 1_000_000_000;
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            Solve1(n, k);
        }

        private static void Solve1(int n, int k)
        {
            Memo = new int[k][];

            for (int i = 0; i < k; i++)
            {
                Memo[i] = new int[n + 1];

                for (int j = 0; j <= n; j++)
                {
                    if (i == 0)
                    {
                        Memo[i][j] = 1;
                        continue;
                    }

                    for (int t = 0; t <= j; t++)
                    {
                        Memo[i][j] = (Memo[i][j] + Memo[i - 1][t]) % Quotient;
                    }
                }
            }

            Console.WriteLine(Memo[k - 1][n]);
        }
    }
}