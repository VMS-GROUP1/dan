using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace acmicpc.net.Problems.DP
{
    /*
    시간 제한	메모리 제한	제출	정답	맞은 사람	정답 비율
    0.15 초 (하단 참고)	128 MB	136462	42243	26923	31.890%
    문제
    정수 X에 사용할 수 있는 연산은 다음과 같이 세 가지 이다.

    X가 3으로 나누어 떨어지면, 3으로 나눈다.
    X가 2로 나누어 떨어지면, 2로 나눈다.
    1을 뺀다.
    정수 N이 주어졌을 때, 위와 같은 연산 세 개를 적절히 사용해서 1을 만들려고 한다. 연산을 사용하는 횟수의 최솟값을 출력하시오.

    입력
    첫째 줄에 1보다 크거나 같고, 1_000_000보다 작거나 같은 정수 N이 주어진다.

    출력
    첫째 줄에 연산을 하는 횟수의 최솟값을 출력한다.

    예제 입력 1 
    2
    예제 출력 1 
    1
    예제 입력 2 
    10
    예제 출력 2 
    3
    힌트
    10의 경우에 10 -> 9 -> 3 -> 1 로 3번 만에 만들 수 있다.
    */
    public class P001463
    {
        public static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());

            Stopwatch timer = new Stopwatch();

            //시간 초과?
            timer.Start();
            Solve2(x);
            timer.Stop();
            System.Console.WriteLine(timer.Elapsed.TotalSeconds);

            timer.Restart();
            Solve1(x);
            timer.Stop();
            System.Console.WriteLine(timer.Elapsed.TotalSeconds);
        }

        private static void Solve1(int x)
        {
            int[] memo = new int[1_000_000_001];

            if (x <= 1)
            {
                Console.WriteLine(0);
                return;
            }

            memo[1] = 0;

            for (int i = 2; i <= x; i++)
            {
                memo[i] = memo[i - 1] + 1;

                if (i % 3 == 0)
                {
                    int j = i / 3;
                    //memo[i] = Math.Min(memo[i], memo[j] + 1);
                    memo[i] = memo[i] > memo[j] + 1 ? memo[j] + 1 : memo[i];
                }

                if (i % 2 == 0)
                {
                    int j = i / 2;
                    //memo[i] = Math.Min(memo[i], memo[j] + 1);
                    memo[i] = memo[i] > memo[j] + 1 ? memo[j] + 1 : memo[i];
                }
            }

            Console.WriteLine($"Solve1: {memo[x]}");
        }

        private static void Solve2(int x)
        {
            int min = 1_000_000_000;
            Calc1(x, 0, ref min);
            System.Console.WriteLine($"Solve2: {min}");
        }

        private static void Calc1(int x, int count, ref int min)
        {
            if (x % 3 == 0)
            {
                Calc2(x / 3, count + 1, ref min);
                if (count + 1 >= min)
                    return;
            }

            if (x % 2 == 0)
            {
                Calc2(x / 2, count + 1, ref min);
                if (count + 1 >= min)
                    return;
            }

            Calc2(x - 1, count + 1, ref min);
            if (count + 1 >= min)
                return;
        }

        private static void Calc2(int x, int count, ref int min)
        {
            if (x == 1)
            {
                min = Math.Min(min, count);
                return;
            }

            if (count + 1 >= min)
                return;

            Calc1(x, count, ref min);
        }
    }
}