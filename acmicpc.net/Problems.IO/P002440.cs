using System;

namespace acmicpc.net.Problems.IO
{
    /*
    문제
    첫째 줄에는 별 N개, 둘째 줄에는 별 N-1개, ..., N번째 줄에는 별 1개를 찍는 문제

    입력
    첫째 줄에 N(1 ≤ N ≤ 100)이 주어진다.

    출력
    첫째 줄부터 N번째 줄까지 차례대로 별을 출력한다.
    */
    class P002440
    {
        public static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = input; i >= 1; i--)
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
