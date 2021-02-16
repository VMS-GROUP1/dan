using System;
using System.Collections;
using System.Collections.Generic;

namespace acmicpc.net.Problems.DP
{
    /* 암호코드 출처다국어분류
    시간 제한	메모리 제한	제출	정답	맞은 사람	정답 비율
    2 초	128 MB	31181	5386	3945	19.465%
    문제
    상근이와 선영이가 다른 사람들이 남매간의 대화를 듣는 것을 방지하기 위해서 대화를 서로 암호화 하기로 했다. 그래서 다음과 같은 대화를 했다.

    상근: 그냥 간단히 암호화 하자. A를 1이라고 하고, B는 2로, 그리고 Z는 26으로 하는거야.
    선영: 그럼 안돼. 만약, "BEAN"을 암호화하면 25114가 나오는데, 이걸 다시 글자로 바꾸는 방법은 여러 가지가 있어.
    상근: 그렇네. 25114를 다시 영어로 바꾸면, "BEAAD", "YAAD", "YAN", "YKD", "BEKD", "BEAN" 총 6가지가 나오는데, BEAN이 맞는 단어라는건 쉽게 알수 있잖아?
    선영: 예가 적절하지 않았네 ㅠㅠ 만약 내가 500자리 글자를 암호화 했다고 해봐. 그 때는 나올 수 있는 해석이 정말 많은데, 그걸 언제 다해봐?
    상근: 얼마나 많은데?
    선영: 구해보자!
    어떤 암호가 주어졌을 때, 그 암호의 해석이 몇 가지가 나올 수 있는지 구하는 프로그램을 작성하시오.

    입력
    첫째 줄에 5000자리 이하의 암호가 주어진다. 암호는 숫자로 이루어져 있다.

    출력
    나올 수 있는 해석의 가짓수를 구하시오. 정답이 매우 클 수 있으므로, 1000000으로 나눈 나머지를 출력한다.

    암호가 잘못되어 암호를 해석할 수 없는 경우에는 0을 출력한다.

    예제 입력 1 
    25114
    예제 출력 1 
    6 */
    public class P002011
    {
        private const int Quotient = 1_000_000;
        //private const int ASCII_Const = 96;
        private static int[] Memo;

        public static void Main(string[] args)
        {
            string p = Console.ReadLine();
            Solve1(p);
        }

        private static void Solve1(string p)
        {
            Memo = new int[p.Length];

            for (int i = 0; i < p.Length; i++)
            {
                int one = 0;
                int two = 0;

                if (int.TryParse(p[i].ToString(), out int x))
                {
                    if (x > 0)
                    {
                        one = i > 0 ? Memo[i - 1] : 1;
                    }

                    if (i > 0)
                    {
                        if (int.TryParse(p[i - 1].ToString(), out int y)
                            && y > 0
                            && x + y * 10 > 0
                            && x + y * 10 <= 26)
                        {
                            two = i > 1 ? Memo[i - 2] : 1;
                        }
                    }
                }

                Memo[i] = (one + two) % Quotient;
            }

            Console.WriteLine(Memo[p.Length - 1]);
        }
    }
}