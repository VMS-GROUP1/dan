using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.Graph
{
    public class P011724
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            int n = input[0];
            int m = input[1];
            Graph<int> graph = new Graph<int>();

            for (int i = 1; i <= n; i++)
            {
                graph.Add(i);
            }

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                graph.Link(edge[0], edge[1]);
                graph.Link(edge[1], edge[0]);
            }

            bool[] check = new bool[n + 1];
            int count = 0;
            for (int i = 1; i <= n; i++)
            {
                if (check[i])
                    continue;

                count++;
                var cc = graph.SearchBFS(i);
                foreach (var j in cc)
                    check[j] = true;
            }

            Console.WriteLine(count);
        }

        public class Graph<T>
        {
            Dictionary<T, Node> Vertexes = new Dictionary<T, Node>();

            public bool Add(T index)
            {
                if (Vertexes.ContainsKey(index) is false)
                {
                    Vertexes.Add(index, new Node(index));
                    return true;
                }

                return false;
            }

            public void Link(T x, T y)
            {
                Vertexes[x].Link(Vertexes[y]);
            }

            public void UnLink(T x, T y)
            {
                Vertexes[x].Remove(Vertexes[y]);
            }

            public IEnumerable<T> SearchDFS(T id)
            {
                Node start = Vertexes[id];
                Stack<Node> n = new Stack<Node>();
                Dictionary<Node, Queue<Node>> linked = new Dictionary<Node, Queue<Node>>();
                HashSet<Node> check = new HashSet<Node>();
                List<T> result = new List<T>();

                Node current = start;
                while (true)
                {
                    if (current == null)
                    {
                        n.Pop();
                        if (n.Count <= 0)
                            break;

                        current = n.Peek();
                    }

                    if (check.Add(current))
                    {
                        n.Push(current);
                        result.Add(current.NodeID);
                        linked[current] = new Queue<Node>(current.GetNodes());
                    }

                    if (linked[current].Count <= 0)
                    {
                        current = null;
                        continue;
                    }

                    var m = linked[current].Dequeue();
                    if (check.Contains(m) == false)
                        current = m;
                }

                return result;
            }

            public IEnumerable<T> SearchBFS(T id)
            {
                Queue<Node> n = new Queue<Node>();
                HashSet<Node> check = new HashSet<Node>();
                List<T> result = new List<T>();
                Node start = Vertexes[id];
                Node current = start;
                while (current != null)
                {
                    if (check.Add(current))
                        result.Add(current.NodeID);

                    foreach (var m in current.GetNodes())
                    {
                        if (check.Add(m))
                        {
                            n.Enqueue(m);
                            result.Add(m.NodeID);
                        }
                    }

                    current = n.Count > 0 ? n.Dequeue() : null;
                }

                return result;
            }

            private class Node
            {
                public T NodeID { get; private set; }
                private SortedList<T, Node> Linked = new SortedList<T, Node>();
                public Node(T id)
                {
                    NodeID = id;
                }

                public void Link(Node other)
                {
                    if (Linked.ContainsKey(other.NodeID))
                        return;

                    Linked.Add(other.NodeID, other);
                }

                public void Remove(Node other)
                {
                    Linked.Remove(other.NodeID);
                }

                public IEnumerable<Node> GetNodes()
                {
                    return Linked.Values;
                }
            }
        }
    }
}