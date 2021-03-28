using System;

namespace acmicpc.net.Problems.DD
{
    public class P001992
    {
        private static int[,] m;
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            m = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var k = Console.ReadLine();
                for (int j = 0; j < k.Length; j++)
                {
                    m[i, j] = k[j] - '0';
                }
            }

            Console.WriteLine(Quad(0, 0, n));
        }

        private static string Quad(int r, int c, int n)
        {
            if (n == 1)
            {
                return m[r, c].ToString();
            }

            int half = n / 2;
            string a1 = Quad(r, c, half);
            string a2 = Quad(r, c + half, half);
            string a3 = Quad(r + half, c, half);
            string a4 = Quad(r + half, c + half, half);

            if (int.TryParse(a1, out int b1) && int.TryParse(a2, out int b2) && int.TryParse(a3, out int b3) && int.TryParse(a4, out int b4))
            {
                int sum = b1 + b2 + b3 + b4;
                if (sum == 0 || sum == 4)
                    return a1;
            }

            return string.Concat("(", a1, a2, a3, a4, ")");
        }
    }
}