using System;
using System.Collections.Generic;
using System.Diagnostics;
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

                graph.ResetMove(i, Graph<int>.GraphSearch.BFS);
                while (graph.MoveNext())
                {
                    check[graph.Value] = true;
                }
            }

            Console.WriteLine(count);
        }

        public class Graph<T> where T : IComparable
        {
            private Node Start;
            private GraphSearch Search;
            private Node Current;
            private Dictionary<T, Node> Vertexes = new Dictionary<T, Node>();
            private HashSet<Node> Visited = new HashSet<Node>();
            private iWaiting<Node> WaitingNodes;
            private Func<T, T, int> Comparison;

            public T Value => Current == null ? default(T) : Current.NodeID;

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

            public bool MoveNext()
            {
                if (Start != null)
                {
                    Current = Start;
                    Visited.Add(Current);
                    Start = null;
                    return true;
                }

                var neighbors = Current.GetNeighbors().Where(x => Visited.Contains(x) is false).ToList();
                if (Comparison != null)
                    neighbors.Sort((x, y) => Comparison(x.NodeID, y.NodeID) * (int)Search);

                neighbors.ForEach(x => WaitingNodes.Push(x));
                WaitingNodes.TryPop(out Current);

                return Current != null && Visited.Add(Current);
            }


            public void UnLink(T x, T y)
            {
                Vertexes[x].Remove(Vertexes[y]);
            }

            public IEnumerable<T> GetLinks(T id)
            {
                return Vertexes[id].GetNeighbors().Select(x => x.NodeID);
            }

            public void ResetMove(T id, GraphSearch search, Func<T, T, int> comparison = null)
            {
                Start = Vertexes[id];
                Current = null;
                Search = search;
                Visited.Clear();
                Comparison = comparison ?? new Func<T, T, int>((x, y) => x.CompareTo(y));

                switch(search)
                {
                    case GraphSearch.BFS:
                        WaitingNodes = new WaitingQueue<Node>();
                        break;
                    case GraphSearch.DFS:
                        WaitingNodes = new WaitingStack<Node>();
                        break;
                    default:
                        break;
                }
            }

            [DebuggerDisplay("NodeID = {NodeID}")]
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

                public IEnumerable<Node> GetNeighbors()
                {
                    return Linked.Values;
                }
            }

            private class WaitingQueue<TNode> : Queue<TNode>, iWaiting<TNode>
            {
                HashSet<TNode> Items = new HashSet<TNode>();
                public void Push(TNode x)
                {
                    if (Items.Add(x))
                        base.Enqueue(x);
                }
                public TNode Pop() => base.Dequeue();
                public bool TryPop(out TNode value) => base.TryDequeue(out value);
            }

            private class WaitingStack<TNode> : Stack<TNode>, iWaiting<TNode>
            {
                HashSet<TNode> Items = new HashSet<TNode>();
                public new void Push(TNode x)
                {
                    if (Items.Add(x))
                        base.Push(x);
                }
            }

            private interface iWaiting<TNode>
            {
                void Push(TNode x);
                TNode Pop();
                TNode Peek();
                bool TryPop(out TNode value);
                bool TryPeek(out TNode value);
            }

            public enum GraphSearch
            {
                BFS = 1,
                DFS = -1
            }
        }
    }
}