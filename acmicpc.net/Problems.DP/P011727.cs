using System;

namespace acmicpc.net.Problems.DP
{
    /*
    2×n 타일링 2 분류
    시간 제한	메모리 제한	제출	정답	맞은 사람	정답 비율
    1 초	256 MB	32005	19150	15206	59.547%
    문제
    2×n 직사각형을 1×2, 2×1과 2×2 타일로 채우는 방법의 수를 구하는 프로그램을 작성하시오.

    아래 그림은 2×17 직사각형을 채운 한가지 예이다.

    입력
    첫째 줄에 n이 주어진다. (1 ≤ n ≤ 1,000)

    출력
    첫째 줄에 2×n 크기의 직사각형을 채우는 방법의 수를 10,007로 나눈 나머지를 출력한다.

    예제 입력 1 
    2
    예제 출력 1 
    3
    예제 입력 2 
    8
    예제 출력 2 
    171
    예제 입력 3 
    12
    예제 출력 3 
    2731
    */
    public class P011727
    {
        private static int[] Memo = new int[1_001];
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            // Solve1(n);
            Solve2(n);
        }

        private static void Solve1(int n)
        {
            Memo.Initialize();
            Memo[1] = 1;
            Memo[2] = 3;

            for (int i = 3; i <= n; i++)
            {
                Memo[i] = (Memo[i - 1] + (Memo[i - 2] * 2)) % 10_007;
            }

            Console.WriteLine(Memo[n]);
        }

        private static void Solve2(int n)
        {
            Memo.Initialize();
            Memo[1] = 1;
            Memo[2] = 3;

            Console.WriteLine(Do(n));
        }

        private static int Do(int n)
        {
            if (n < 1)
                return 0;
            if (Memo[n] == 0)
                Memo[n] = (Do(n - 1) + Do(n - 2) * 2) % 10_007;

            return Memo[n];
        }
    }
}