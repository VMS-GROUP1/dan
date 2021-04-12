using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001697
    {
        private static int[] visited;
        private static int n;
        private static int k;
        public static void Main(string[] args)
        {
            visited = new int[100_002];
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            n = p[0];
            k = p[1];

            Console.WriteLine(Bfs());
        }

        private static int Bfs()
        {
            if (n == k)
                return 0;
            else if (n >= k)
                return n - k;

            Queue<(int value, int cost)> waiting = new Queue<(int, int)>();
            waiting.Enqueue((n, 0));

            while (waiting.TryDequeue(out var node))
            {
                int cost = node.cost + 1;

                if (Check(node.value + 1, cost, waiting))
                    break;
                if (Check(node.value - 1, cost, waiting))
                    break;
                if (Check(node.value * 2, cost, waiting))
                    break;
            }

            return visited[k];
        }

        private static bool Check(int value, int cost, Queue<(int, int)> waiting)
        {
            if (value == k)
            {
                visited[value] = cost;
                return true;
            }

            if (value < 0)
                return false;
            if (value == n)
                return false;
            if (value > k + 1)
                return false;
            if (visited[value] > 0)
                return false;

            visited[value] = cost;
            waiting.Enqueue((value, cost));
            return false;
        }
    }
}