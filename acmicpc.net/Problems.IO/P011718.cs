using System;
using System.Text.RegularExpressions;

namespace acmicpc.net.Problems.IO
{
    /*
    문제
    입력 받은 대로 출력하는 프로그램을 작성하시오.

    입력
    입력이 주어진다. 입력은 최대 100줄로 이루어져 있고, 알파벳 소문자, 대문자, 공백, 숫자로만 이루어져 있다. 각 줄은 100글자를 넘지 않으며, 빈 줄은 주어지지 않는다. 또, 각 줄은 공백으로 시작하지 않고, 공백으로 끝나지 않는다.

    출력
    입력받은 그대로 출력한다.
    */
    public class P011718
    {
        public static void Main(string[] args)
        {
            //:(
            //string pattern1 = @"[a-zA-Z0-9]";
            //string pattern2 = $@"(?(^{pattern1}.*{pattern1}$)({pattern1}|\s){{1,100}}$|(^$))";

            for (int i = 0; i < 100; i++)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line) || Regex.IsMatch(line, @".*") is false)
                    break;
                Console.WriteLine(line);
            }
        }
    }
}