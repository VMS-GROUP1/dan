﻿using System;
using System.Linq;

namespace acmicpc.net.p010953
{
    /*
    문제
    두 정수 A와 B를 입력받은 다음, A+B를 출력하는 프로그램을 작성하시오.

    입력
    첫째 줄에 테스트 케이스의 개수 T가 주어진다.

    각 테스트 케이스는 한 줄로 이루어져 있으며, 각 줄에 A와 B가 주어진다. A와 B는 콤마(,)로 구분되어 있다. (0 < A, B < 10)

    출력
    각 테스트 케이스마다 A+B를 출력한다.
    */
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var values = Console.ReadLine().Split(',').Select(x => int.Parse(x)).ToArray();
                Console.WriteLine(values[0] + values[1]);
            }
        }
    }
}
