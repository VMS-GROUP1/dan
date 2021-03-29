using System;

namespace acmicpc.net.Problems.DD
{
    public class P001517
    {
        private static int count;
        private static int[] A;
        public static void Main(string[] args)
        {
            count = 0;
            int n = int.Parse(Console.ReadLine());
            A = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            Sort(0);
            Console.WriteLine(count);
        }

        private static void Sort(int x)
        {
            while (x + 1 < A.Length && A[x] <= A[x + 1])
            {
                x++;
            }

            if (x + 1 == A.Length)
                return;

            Swap(x);
            Sort(0);
        }

        private static void Swap(int x)
        {
            int temp = A[x];
            A[x] = A[x + 1];
            A[x + 1] = temp;
            count++;

            if (x + 2 == A.Length)
                return;

            if (A[x + 1] > A[x + 2])
                Swap(x + 1);
        }
    }
}