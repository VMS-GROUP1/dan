using System;
using System.Text;

namespace acmicpc.net.Problems.IO
{
    /*
    문제
    첫째 줄에는 별 1개, 둘째 줄에는 별 3개, ..., N번째 줄에는 별 2×N-1개를 찍는 문제

    별은 가운데를 기준으로 대칭이어야 한다.

    입력
    첫째 줄에 N(1 ≤ N ≤ 100)이 주어진다.

    출력
    첫째 줄부터 N번째 줄까지 차례대로 별을 출력한다.
    */
    class P002442
    {
        public static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input; i++)
            {
                StringBuilder sb = new StringBuilder();
                AppendMore(' ', input - i, ref sb);
                AppendMore('*', i * 2 - 1, ref sb);
                Console.WriteLine(sb.ToString());
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
