using System;

namespace acmicpc.net.Problems
{
    class P002438
    {
        /*
        문제
        첫째 줄에는 별 1개, 둘째 줄에는 별 2개, N번째 줄에는 별 N개를 찍는 문제

        입력
        첫째 줄에 N(1 ≤ N ≤ 100)이 주어진다.

        출력
        첫째 줄부터 N번째 줄까지 차례대로 별을 출력한다.
        */
        public static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                Write('*', i);
                Console.Write('\n');
            }
        }

        static void Write(char c, int remain)
        {
            if (remain-- <= 0)
                return;

            Console.Write(c);
            Write(c, remain);
        }
    }
}
