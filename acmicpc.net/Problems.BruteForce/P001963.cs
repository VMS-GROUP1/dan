using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001963
    {
        private static string Impossible = "Impossible";
        private static bool[] PrimeNumber = new bool[10_000];
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SieveOfEratosthenes();

            for (int i = 0; i < n; i++)
            {
                var x = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
                int ans = Bfs(x[0], x[1]);
                Console.WriteLine(ans < 0 ? Impossible : ans);
            }
        }

        private static void SieveOfEratosthenes()
        {
            //List<int> p = new List<int>();
            bool[] np = new bool[10_000];

            for (long i = 2; i <= 9_999; i++)
            {
                if (np[i])
                    continue;

                //p.Add((int)i);
                PrimeNumber[i] = true;
                for (long j = i * i; j <= 9_999; j += i)
                {
                    np[j] = true;
                }
            }
        }

        private static int Bfs(int n, int k)
        {
            if (n == k)
                return 0;

            Queue<(int value, int cost)> waiting = new Queue<(int, int)>();
            int[] visited = new int[10_000];
            waiting.Enqueue((n, 0));
            bool found = false;

            while (waiting.TryDequeue(out var node))
            {
                int cost = node.cost + 1;

                int value = node.value;
                for (int i = 1000; i >= 1; i /= 10)
                {
                    int x = value % i;
                    int y = value / (i * 10) * (i * 10);
                    for (int j = 0; j <= 9; j++)
                    {
                        if (Check(y + j * i + x, cost, waiting, visited, n, k))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found)
                        break;
                }

                if (found)
                    break;
            }

            return visited[k] == 0 ? -1 : visited[k];
        }

        private static bool Check(int value, int cost, Queue<(int, int)> waiting, int[] visited, int n, int k)
        {
            if (value == k)
            {
                visited[value] = cost;
                return true;
            }

            if (value < 1000)
                return false;
            if (value == n)
                return false;
            if (visited[value] > 0)
                return false;
            if (PrimeNumber[value] is false)
                return false;

            visited[value] = cost;
            waiting.Enqueue((value, cost));
            return false;
        }
    }
}