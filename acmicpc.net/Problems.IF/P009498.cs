using System;

namespace acmicpc.net.Problems.IF
{
    //시험 성적
    public class P009498
    {
        public static void Main(string[] args)
        {
            int p = int.Parse(Console.ReadLine());
            char score = 'A';

            if (p == 100)
                score = 'A';
            else if (p < 60)
                score = 'F';
            else
                score = Convert.ToChar(score + (9 - p / 10));

            // if (p >= 90 && p <= 100)
            //     score = "A";
            // else if (p >= 80 && p <= 89)
            //     score = "B";
            // else if (p >= 70 && p <= 79)
            //     score = "C";
            // else if (p >= 60 && p <= 69)
            //     score = "D";

            Console.WriteLine(score);
        }
    }
}