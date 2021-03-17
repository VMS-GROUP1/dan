using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Graph
{
    public class P002331
    {
        public static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            Console.WriteLine(Dfs(n[0], n[1]));
        }

        private static int Dfs(int start, int p)
        {
            Stack<int> stack = new Stack<int>();
            HashSet<int> visited = new HashSet<int>();
            stack.Push(start);
            int node = start;
            int found = -1;

            while (true)
            {
                node = stack.Peek();
                if (visited.Add(node))
                {
                    node = GetNext(node, p);
                    stack.Push(node);
                    continue;
                }

                node = stack.Pop();

                if (found == node)
                {
                    break;
                }

                if (found < 0)
                {
                    found = node;
                }
            }

            return stack.Count();
        }

        private static int GetNext(int n, int p)
        {
            var digit = GetDigit(n, new List<int>());
            return digit.Sum(x => Pow(x, p, 1));
        }

        private static List<int> GetDigit(int n, List<int> ans)
        {
            if (n <= 0)
                return ans;

            ans.Add(n % 10);
            return GetDigit(n / 10, ans);
        }

        private static int Pow(int n, int p, int ans)
        {
            if (p < 1)
                return ans;

            return Pow(n, --p, ans * n);
        }
    }
}