using System;
using System.Text;

namespace acmicpc.net.p010991
{
    /*
    문제
    예제를 보고 규칙을 유추한 뒤에 별을 찍어 보세요.

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
                StringBuilder sb = new StringBuilder();
                AppendMore(' ', input - i, ref sb);

                for (int j = 1; j <= i * 2 - 1; j++)
                {
                    sb.Append(j % 2 == 0 ? ' ' : '*');
                }

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
