using System;

namespace acmicpc.net.Problems.DP
{
    /* 타일 채우기 출처다국어분류
    시간 제한	메모리 제한	제출	정답	맞은 사람	정답 비율
    2 초	128 MB	27446	9626	7569	35.305%
    문제
    3×N 크기의 벽을 2×1, 1×2 크기의 타일로 채우는 경우의 수를 구해보자.

    입력
    첫째 줄에 N(1 ≤ N ≤ 30)이 주어진다.

    출력
    첫째 줄에 경우의 수를 출력한다.

    예제 입력 1 
    2
    예제 출력 1 
    3*/
    public class P002133
    {
        private static int[] MemoA;
        private static int[] MemoB;

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Solve1(n);
        }

        private static void Solve1(int n)
        {
            MemoA = new int[30];
            MemoB = new int[30];

            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    MemoA[i] = 0;
                    MemoB[i] = 2;
                }
                else if (i == 1)
                {
                    MemoA[i] = 3;
                    MemoB[i] = 0;
                }
                else
                {
                    MemoA[i] = MemoA[i - 2] * 3 + MemoB[i - 1];
                    MemoB[i] = (i < 3 ? 0 : MemoA[i - 3]) * 2 + MemoB[i - 2];
                }
            }

            Console.WriteLine(MemoA[n - 1]);
        }
    }
}