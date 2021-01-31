﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace acmicpc.net.p001924
{
    /*
    문제
    오늘은 2007년 1월 1일 월요일이다. 그렇다면 2007년 x월 y일은 무슨 요일일까? 이를 알아내는 프로그램을 작성하시오.

    입력
    첫째 줄에 빈 칸을 사이에 두고 x(1 ≤ x ≤ 12)와 y(1 ≤ y ≤ 31)이 주어진다. 참고로 2007년에는 1, 3, 5, 7, 8, 10, 12월은 31일까지, 4, 6, 9, 11월은 30일까지, 2월은 28일까지 있다.

    출력
    첫째 줄에 x월 y일이 무슨 요일인지에 따라 SUN, MON, TUE, WED, THU, FRI, SAT중 하나를 출력한다.
    */
    class Program
    {
        static void Main(string[] args)
        {
            // int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            // int year = 2007;
            // DateTime date = new DateTime(year, input[0], input[1]);
            // Console.WriteLine(date.DayOfWeek.ToString().Substring(0,3).ToUpper());

            int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            HashSet<int> days30 = new HashSet<int>() { 4, 6, 9, 11 };
            HashSet<int> days28 = new HashSet<int>() { 2 };

            int days = 0;
            for (int i = 1; i < input[0]; i++)
            {
                days += days28.Contains(i) ? 28 : days30.Contains(i) ? 30 : 31;
            }
            days += input[1] - 1;

            DayOfWeek week = (DayOfWeek)((days + (int)DayOfWeek.Monday) % 7);
            Console.WriteLine(week.ToString().Substring(0, 3).ToUpper());
        }
    }
}