using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Graph
{
    public class P010451
    {
        public static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                int[] no = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                List<int>[] nodes = new List<int>[n + 1];
                int[] visited = new int[n + 1];

                for (int j = 1; j <= n; j++)
                {
                    nodes[j] = new List<int>();
                }

                for (int j = 1; j <= n; j++)
                {
                    nodes[j].Add(no[j - 1]);
                }

                HashSet<int> members = new HashSet<int>();

                for (int j = 1; j <= n; j++)
                {
                    if (visited[j] == 1)
                        continue;

                    IEnumerable<int> cycle = Dfs(nodes, j, visited);

                    if (cycle.Count() > 0)
                    {
                        members.Add(cycle.Min());
                    }
                }

                Console.WriteLine(members.Count);
            }
        }

        private static IEnumerable<int> Dfs(List<int>[] nodes, int start, int[] visited)
        {
            Stack<int> stack = new Stack<int>();
            LinkedList<int> link = new LinkedList<int>();
            HashSet<int> check = new HashSet<int>();
            bool find = false;

            stack.Push(start);

            while (stack.Count > 0)
            {
                int i = stack.Pop();
                check.Add(i);
                var n = link.AddLast(i);

                foreach (var j in nodes[i])
                {
                    if (visited[j] == 1)
                        continue;

                    if (check.Contains(j))
                    {
                        find = true;
                        while (link.First.Value != j)
                            link.RemoveFirst();

                        break;
                    }

                    stack.Push(j);
                }

                if (find)
                    break;
            }

            foreach (var i in check)
                visited[i] = 1;

            if (find is false)
                link.Clear();

            return link;
        }
    }
}