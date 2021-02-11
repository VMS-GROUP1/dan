using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace acmicpc.net.Problems.DP
{
    /*
    시간 제한	메모리 제한	제출	정답	맞은 사람	정답 비율
    0.15 초 (하단 참고)	128 MB	136462	42243	26923	31.890%
    문제
    정수 X에 사용할 수 있는 연산은 다음과 같이 세 가지 이다.

    X가 3으로 나누어 떨어지면, 3으로 나눈다.
    X가 2로 나누어 떨어지면, 2로 나눈다.
    1을 뺀다.
    정수 N이 주어졌을 때, 위와 같은 연산 세 개를 적절히 사용해서 1을 만들려고 한다. 연산을 사용하는 횟수의 최솟값을 출력하시오.

    입력
    첫째 줄에 1보다 크거나 같고, 1_000_000보다 작거나 같은 정수 N이 주어진다.

    출력
    첫째 줄에 연산을 하는 횟수의 최솟값을 출력한다.

    예제 입력 1 
    2
    예제 출력 1 
    1
    예제 입력 2 
    10
    예제 출력 2 
    3
    힌트
    10의 경우에 10 -> 9 -> 3 -> 1 로 3번 만에 만들 수 있다.
    */
    public class P001463
    {
        public static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());

            //Solve1(x);
            Solve2(x);
        }

        private static void Solve1(int x)
        {
            int[] memo = new int[1_000_000_001];

            if (x <= 1)
            {
                Console.WriteLine(0);
                return;
            }

            memo[1] = 0;

            for (int i = 2; i <= x; i++)
            {
                memo[i] = memo[i - 1] + 1;

                if (i % 3 == 0)
                {
                    int j = i / 3;
                    memo[i] = Math.Min(memo[i], memo[j] + 1);
                }

                if (i % 2 == 0)
                {
                    int j = i / 2;
                    memo[i] = Math.Min(memo[i], memo[j] + 1);
                }
            }

            Console.WriteLine(memo[x]);
        }

        private static void Solve2(int x)
        {
            int[] memo = new int[1_000_001];
            for (int i = 1; i <= Math.Ceiling((double)x / 1_000); i++)
            {
                Do(Math.Min(x, i * 1000), memo);
            }
            System.Console.WriteLine(memo[x]);
        }

        private static void Do(int x, int[] memo)
        {
            if (x <= 1)
                return;

            if (memo[x] > 0)
                return;

            Do(x - 1, memo);
            memo[x] = memo[x - 1] + 1;

            if (x % 3 == 0)
            {
                int y = x / 3;
                Do(y, memo);
                memo[x] = Math.Min(memo[x], memo[y] + 1);
            }

            if (x % 2 == 0)
            {
                int y = x / 2;
                Do(y, memo);
                memo[x] = Math.Min(memo[x], memo[y] + 1);
            }
        }
    }
}