using System;
using System.Linq;

namespace acmicpc.net.Problems
{
    /*
    문제
    N개의 정수가 주어진다. 이때, 최솟값과 최댓값을 구하는 프로그램을 작성하시오.

    입력
    첫째 줄에 정수의 개수 N (1 ≤ N ≤ 1,000,000)이 주어진다. 둘째 줄에는 N개의 정수를 공백으로 구분해서 주어진다. 모든 정수는 -1,000,000보다 크거나 같고, 1,000,000보다 작거나 같은 정수이다.

    출력
    첫째 줄에 주어진 정수 N개의 최솟값과 최댓값을 공백으로 구분해 출력한다.
    */
    class P010818
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int min = 1_000_000;
            int max = -1_000_000;
            for (int i = 0; i < count; i++)
            {
                min = Math.Min(input[i], min);
                max = Math.Max(input[i], max);
            }

            // min = input.Min();
            // max = input.Max();

            Console.WriteLine($"{min} {max}");
        }
    }
}
