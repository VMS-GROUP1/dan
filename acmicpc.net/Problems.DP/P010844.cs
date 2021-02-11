using System;
using System.Linq;

namespace acmicpc.net.Problems.DP
{
    /*
    쉬운 계단 수 분류
    시간 제한	메모리 제한	제출	정답	맞은 사람	정답 비율
    1 초	256 MB	73084	22176	15922	28.426%
    문제
    45656이란 수를 보자.

    이 수는 인접한 모든 자리수의 차이가 1이 난다. 이런 수를 계단 수라고 한다.

    세준이는 수의 길이가 N인 계단 수가 몇 개 있는지 궁금해졌다.

    N이 주어질 때, 길이가 N인 계단 수가 총 몇 개 있는지 구하는 프로그램을 작성하시오. (0으로 시작하는 수는 없다.)

    입력
    첫째 줄에 N이 주어진다. N은 1보다 크거나 같고, 100보다 작거나 같은 자연수이다.

    출력
    첫째 줄에 정답을 1,000,000,000으로 나눈 나머지를 출력한다.

    예제 입력 1 
    1
    예제 출력 1 
    9
    예제 입력 2 
    2
    예제 출력 2 
    17
    */
    public class P010844
    {
        private const int Size = 101;
        private const int Num = 10;
        private const int Const = 1_000_000_000;

        private static int[,] Memo;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // Solve1(n);
            Solve2(n);
        }

        private static void Solve1(int n)
        {
            Memo = new int[Size, Num];

            for (int i = 1; i <= n; i++)
            {
                for (int j = 0; j < Num; j++)
                {
                    if (i == 1)
                    {
                        if (j != 0)
                            Memo[i, j] = 1;

                        continue;
                    }

                    if (j == 0)
                    {
                        Memo[i, j] = Memo[i - 1, j + 1] % Const;
                    }
                    else if (j == 9)
                    {
                        Memo[i, j] = Memo[i - 1, j - 1] % Const;
                    }
                    else
                    {
                        Memo[i, j] = (Memo[i - 1, j - 1] + Memo[i - 1, j + 1]) % Const;
                    }
                }
            }

            int x = 0;
            for (int i = 0; i < Num; i++)
            {
                x = (x + Memo[n, i]) % Const;
            }
            Console.WriteLine(x);
        }

        private static void Solve2(int n)
        {
            Memo = new int[Size, Num];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Num; j++)
                {
                    Memo[i,j] = -1;
                }
            }

            int x = 0;
            for (int i = 0; i < Num; i++)
            {
                x = (x + Do(n, i)) % Const;
            }

            Console.WriteLine(x);
        }

        private static int Do(int n, int m)
        {
            if (n == 1)
            {
                if (m == 0)
                    Memo[n, m] = 0;
                else
                    Memo[n, m] = 1;
            }
            else if (Memo[n, m] < 0)
            {
                if (m == 0)
                    Memo[n, m] = Do(n - 1, 1) % Const;
                else if (m == 9)
                    Memo[n, m] = Do(n - 1, 8) % Const;
                else
                    Memo[n, m] = (Do(n - 1, m - 1) + Do(n - 1, m + 1)) % Const;
            }

            return Memo[n, m];
        }
    }
}