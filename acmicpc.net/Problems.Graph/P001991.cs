using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace acmicpc.net.Problems.Graph
{
    public class P001991
    {
        private static int A = 'A';
        public static void Main(string[] args)
        {
            int v = int.Parse(Console.ReadLine());
            int[][] link = new int[v + 1][];

            for (int i = 0; i <= v; i++)
                link[i] = new int[3];

            for (int i = 1; i <= v; i++)
            {
                int[] data = Console.ReadLine().Split().Select(x => x == "." ? 0 : x[0] - A + 1).ToArray();

                link[data[0]] = new int[3];
                link[data[0]][1] = data[1];
                link[data[0]][2] = data[2];
                link[data[1]][0] = data[0];
                link[data[2]][0] = data[0];
            }

            Console.WriteLine(PreOrder(1, link));
            Console.WriteLine(InOrder(1, link));
            Console.WriteLine(PostOrder(1, link));
        }

        private static string PreOrder(int start, int[][] link)
        {
            StringBuilder stringBuilder = new StringBuilder();
            Stack<int> waiting = new Stack<int>();
            waiting.Push(start);

            while (waiting.TryPop(out var node))
            {
                if (node == 0)
                    continue;

                stringBuilder.Append((char)(node + A - 1));

                waiting.Push(link[node][2]);
                waiting.Push(link[node][1]);
            }

            return stringBuilder.ToString();
        }

        private static string InOrder(int start, int[][] link)
        {
            StringBuilder stringBuilder = new StringBuilder();
            HashSet<int> visited = new HashSet<int>();
            Stack<int> waiting = new Stack<int>();
            waiting.Push(start);

            while (waiting.TryPop(out var node))
            {
                if (node == 0)
                    continue;

                if (visited.Add(node))
                {
                    waiting.Push(link[node][2]);
                    waiting.Push(node);
                    waiting.Push(link[node][1]);
                    continue;
                }

                stringBuilder.Append((char)(node + A - 1));
            }

            return stringBuilder.ToString();
        }

        private static string PostOrder(int start, int[][] link)
        {
            StringBuilder stringBuilder = new StringBuilder();
            HashSet<int> visited = new HashSet<int>();
            Stack<int> waiting = new Stack<int>();
            waiting.Push(start);

            while (waiting.TryPop(out var node))
            {
                if (node == 0)
                    continue;

                if (visited.Add(node))
                {
                    waiting.Push(node);
                    waiting.Push(link[node][2]);
                    waiting.Push(link[node][1]);
                    continue;
                }

                stringBuilder.Append((char)(node + A - 1));
            }

            return stringBuilder.ToString();
        }
    }
}