using System;

namespace acmicpc.net.Problems.DD
{
    public class P001517
    {
        private static long count;
        private static int[] A;
        public static void Main(string[] args)
        {
            count = 0;
            int n = int.Parse(Console.ReadLine());
            A = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            Sort(0, n);
            Console.WriteLine(count);
        }

        private static void Sort(int x, int n)
        {
            if (n == 1)
                return;

            int half = n / 2;
            Sort(x, half);
            Sort(x + half, n - half);
            Sort(x, half, x + half, n - half);
        }

        private static void Sort(int x, int nx, int y, int ny)
        {
            int mid = x + nx - 1;
            if (A[mid] <= A[y])
                return;

            if (nx == 0 || ny == 0)
                return;

            if (nx == 1 && ny == 1)
            {
                if (A[x] > A[y])
                {
                    count++;
                    int t = A[x];
                    A[x] = A[y];
                    A[y] = t;
                }
                return;
            }

            int i = x;
            int j = y;
            int k = 0;
            int end = y + ny - 1;
            int[] temp = new int[nx + ny];
            while (i <= mid || j <= end)
            {
                if (i <= mid && (j > end || A[i] <= A[j]))
                {
                    temp[k++] = A[i++];
                }
                else
                {
                    count += mid - i + 1;
                    temp[k++] = A[j++];
                }
            }

            i = 0;
            while (i < temp.Length)
            {
                A[i + x] = temp[i++];
            }
        }
    }
}