using System;
using System.Text;

namespace acmicpc.net.p002522
{
    /*
    문제
    예제를 보고 규칙을 유추한 뒤에 별을 찍어 보세요.

    입력
    첫째 줄에 N(1 ≤ N ≤ 100)이 주어진다.

    출력
    첫째 줄부터 2×N-1번째 줄까지 차례대로 별을 출력한다.

    예제 입력 1
    3

    예제 출력 1
      *
     **
    ***
     **
      *
    */
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= input * 2 - 1; i++)
            {
                int numOfEmpty = Math.Abs(input - i);
                StringBuilder sb = new StringBuilder();
                AppendMore(' ', numOfEmpty, ref sb);
                AppendMore('*', input - numOfEmpty, ref sb);
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
