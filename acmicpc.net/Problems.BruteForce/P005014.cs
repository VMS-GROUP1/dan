using System;
using System.Collections.Generic;

namespace acmicpc.net.Problems.BruteForce
{
    public class P005014
    {
        private static int F;
        private static int S;
        private static int G;
        private static int U;
        private static int D;
        private static Dictionary<int, int> visited;
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            F = p[0];
            S = p[1];
            G = p[2];
            U = p[3];
            D = p[4];

            Bfs();

            if (visited.TryGetValue(G, out var ans) is false)
                Console.WriteLine("use the stairs");
            else
                Console.WriteLine(ans);
        }

        private static void Bfs()
        {
            visited = new Dictionary<int, int>();
            if (S == G)
            {
                visited[G] = 0;
                return;
            }

            Queue<(int floor, int cost)> waiting = new Queue<(int, int)>();
            waiting.Enqueue((S, 0));

            while (waiting.TryDequeue(out var node))
            {
                int cost = node.cost + 1;

                if (Check(node.floor + U, cost, waiting))
                    break;
                if (Check(node.floor - D, cost, waiting))
                    break;
            }
        }

        private static bool Check(int value, int cost, Queue<(int, int)> waiting)
        {
            if (value == G)
            {
                visited[value] = cost;
                return true;
            }

            if (value <= 0)
                return false;
            if (value == S)
                return false;
            if (value > F)
                return false;
            if (visited.TryAdd(value, cost) is false)
                return false;

            waiting.Enqueue((value, cost));
            return false;
        }
    }
}