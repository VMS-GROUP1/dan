using System;
using System.Text;

namespace acmicpc.net.Problems
{
    /*
    문제
    예제를 보고 규칙을 유추한 뒤에 별을 찍어 보세요.

    입력
    첫째 줄에 N(1 ≤ N ≤ 100)이 주어진다.

    출력
    첫째 줄부터 N번째 줄까지 차례대로 별을 출력한다.

    예제 입력 4
    4

    예제 출력 4
       *
      * *
     *   *
    *******
    */
    class P010992
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            char whiteSpace = ' ';
            char asterisk = '*';

            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i < input; i++)
            {
                int numOfSpace = Math.Abs(input - i);
                int numOfChar = i * 2 - 1;
                AppendMore(whiteSpace, numOfSpace, ref sb);

                for (int j = 1; j <= numOfChar; j++)
                {
                    sb.Append(j > 1 && j < numOfChar ? whiteSpace : asterisk);
                }

                sb.AppendLine();
            }

            AppendMore(asterisk, input * 2 - 1, ref sb);
            Console.Write(sb.ToString());
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