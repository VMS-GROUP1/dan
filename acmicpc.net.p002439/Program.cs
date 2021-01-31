﻿using System;
using System.Text;

namespace acmicpc.net.p002439
{
    /*
    문제
    첫째 줄에는 별 1개, 둘째 줄에는 별 2개, N번째 줄에는 별 N개를 찍는 문제

    하지만, 오른쪽을 기준으로 정렬한 별(예제 참고)을 출력하시오.

    입력
    첫째 줄에 N(1 ≤ N ≤ 100)이 주어진다.

    출력
    첫째 줄부터 N번째 줄까지 차례대로 별을 출력한다.
    */
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                // StringBuilder sb = new StringBuilder();
                // AppendMore(' ', input - i, ref sb);
                // AppendMore('*', i, ref sb);
                // Console.WriteLine(sb.ToString());

                StringBuilder sb = new StringBuilder();
                AppendMore('*', i, ref sb);
                Console.WriteLine(sb.ToString().PadLeft(input));
            }
        }

        static void AppendMore(char c, int count, ref StringBuilder sb)
        {
            if (count-- <= 0)
                return;

            sb.Append(c);
            AppendMore(c, count, ref sb);
        }
    }
}
