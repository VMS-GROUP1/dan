using System;

namespace acmicpc.net.Problems.DP
{
    /*
    1, 2, 3 더하기 출처다국어분류
    시간 제한	메모리 제한	제출	정답	맞은 사람	정답 비율
    1 초 (추가 시간 없음)	512 MB	55100	35241	23415	61.931%
    문제
    정수 4를 1, 2, 3의 합으로 나타내는 방법은 총 7가지가 있다. 합을 나타낼 때는 수를 1개 이상 사용해야 한다.

    1+1+1+1
    1+1+2
    1+2+1
    2+1+1
    2+2
    1+3
    3+1
    정수 n이 주어졌을 때, n을 1, 2, 3의 합으로 나타내는 방법의 수를 구하는 프로그램을 작성하시오.

    입력
    첫째 줄에 테스트 케이스의 개수 T가 주어진다. 각 테스트 케이스는 한 줄로 이루어져 있고, 정수 n이 주어진다. n은 양수이며 11보다 작다.

    출력
    각 테스트 케이스마다, n을 1, 2, 3의 합으로 나타내는 방법의 수를 출력한다.

    예제 입력 1 
    3
    4
    7
    10
    예제 출력 1 
    7
    44
    274
    */
    public class P009095
    {
        private static int[] Memo = new int[12];

        public static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                Solve(n);
            }
        }

        private static void Solve(int n)
        {
            Memo.Initialize();

            for (int i = 1; i <= n; i++)
            {
                int x = i < 1 ? 0 : i == 1 ? 1 : Memo[i - 1];
                int y = i < 2 ? 0 : i == 2 ? 1 : Memo[i - 2];
                int z = i < 3 ? 0 : i == 3 ? 1 : Memo[i - 3];
                Memo[i] = x + y + z;
            }

            Console.WriteLine(Memo[n]);
        }
    }
}