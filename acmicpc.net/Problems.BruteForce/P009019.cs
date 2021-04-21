using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace acmicpc.net.Problems.BruteForce
{
    //DSLR
    public class P009019
    {
        private static int T;
        public static void Main(string[] args)
        {
            T = int.Parse(Console.ReadLine());
            //StringBuilder builder = new StringBuilder();

            while (T-- > 0)
            {
                string[] check = new string[10000];
                int[] link = new int[10000];

                var p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                int A = p[0];
                int B = p[1];

                Bfs(A, B, check, link);

                Stack<string> ans = new Stack<string>();
                int x = B;
                while (x != A)
                {
                    ans.Push(check[x]);
                    x = link[x];
                }

                Console.WriteLine(string.Concat(ans));
            }
        }

        private static void Bfs(int A, int B, string[] check, int[] link)
        {
            Queue<int> waiting = new Queue<int>();
            waiting.Enqueue(A);

            while (waiting.TryDequeue(out var x))
            {
                if (x == B)
                {
                    break;
                }

                int next = x * 2;
                next = next > 9999 ? next % 10000 : next;
                if (check[next] == null)
                {
                    link[next] = x;
                    check[next] = "D";
                    waiting.Enqueue(next);
                }

                next = x - 1;
                next = next < 0 ? 9999 : next;
                if (check[next] == null)
                {
                    link[next] = x;
                    check[next] = "S";
                    waiting.Enqueue(next);
                }

                next = (x % 1000) * 10 + x / 1000;
                if (check[next] == null)
                {
                    link[next] = x;
                    check[next] = "L";
                    waiting.Enqueue(next);
                }

                next = x / 10 + (x % 10) * 1000;
                if (check[next] == null)
                {
                    link[next] = x;
                    check[next] = "R";
                    waiting.Enqueue(next);
                }
            }
        }
    }
}