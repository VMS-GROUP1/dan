using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace acmicpc.net.Problems.Graph
{
    public class P009466
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
                        members.UnionWith(cycle);
                }

                Console.WriteLine(n - members.Count);
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

        //     public class Graph<T> where T : IComparable
        //     {
        //         private Node Start;
        //         private GraphSearch Search;
        //         private Node Current;
        //         private Dictionary<T, Node> Vertexes = new Dictionary<T, Node>();
        //         private HashSet<Node> Visited = new HashSet<Node>();
        //         private iWaiting<Node> WaitingNodes;
        //         private Func<T, T, int> Comparison;
        //         private HashSet<(T, T)> Edges = new HashSet<(T, T)>();

        //         public T Value => Current == null ? default(T) : Current.NodeID;

        //         public bool Add(T index)
        //         {
        //             if (Vertexes.ContainsKey(index) is false)
        //             {
        //                 Vertexes.Add(index, new Node(index));
        //                 return true;
        //             }

        //             return false;
        //         }

        //         public void Link(T x, T y)
        //         {
        //             Vertexes[x].Link(Vertexes[y]);
        //             Edges.Add((x, y));
        //         }

        //         public bool MoveNext()
        //         {
        //             if (Start != null)
        //             {
        //                 Current = Start;
        //                 Visited.Add(Current);
        //                 Start = null;
        //                 return true;
        //             }

        //             var neighbors = Current.GetNeighbors().Where(x => Visited.Contains(x) is false).ToList();
        //             if (Comparison != null)
        //                 neighbors.Sort((x, y) => Comparison(x.NodeID, y.NodeID) * (int)Search);

        //             neighbors.ForEach(x => WaitingNodes.Push(x));
        //             WaitingNodes.TryPop(out Current);

        //             return Current != null && Visited.Add(Current);
        //         }


        //         public void UnLink(T x, T y)
        //         {
        //             Vertexes[x].Remove(Vertexes[y]);
        //         }

        //         public IEnumerable<(T, T)> GetEdges => this.Edges;

        //         public IEnumerable<T> GetLinks(T id)
        //         {
        //             return Vertexes[id].GetNeighbors().Select(x => x.NodeID);
        //         }

        //         public void ResetMove(T id, GraphSearch search, Func<T, T, int> comparison = null)
        //         {
        //             Start = Vertexes[id];
        //             Current = null;
        //             Search = search;
        //             Visited.Clear();
        //             WaitingNodes.Clear();
        //             Comparison = comparison ?? new Func<T, T, int>((x, y) => x.CompareTo(y));

        //             switch (search)
        //             {
        //                 case GraphSearch.BFS:
        //                     WaitingNodes = new WaitingQueue<Node>();
        //                     break;
        //                 case GraphSearch.DFS:
        //                     WaitingNodes = new WaitingStack<Node>();
        //                     break;
        //                 default:
        //                     break;
        //             }
        //         }

        //         [DebuggerDisplay("NodeID = {NodeID}")]
        //         private class Node
        //         {
        //             public T NodeID { get; private set; }
        //             private SortedList<T, Node> Linked = new SortedList<T, Node>();
        //             public Node(T id)
        //             {
        //                 NodeID = id;
        //             }

        //             public void Link(Node other)
        //             {
        //                 if (Linked.ContainsKey(other.NodeID))
        //                     return;

        //                 Linked.Add(other.NodeID, other);
        //             }

        //             public void Remove(Node other)
        //             {
        //                 Linked.Remove(other.NodeID);
        //             }

        //             public IEnumerable<Node> GetNeighbors()
        //             {
        //                 return Linked.Values;
        //             }
        //         }

        //         private class WaitingQueue<TNode> : Queue<TNode>, iWaiting<TNode>
        //         {
        //             HashSet<TNode> Items = new HashSet<TNode>();
        //             public void Push(TNode x)
        //             {
        //                 if (Items.Add(x))
        //                     base.Enqueue(x);
        //             }
        //             public TNode Pop() => base.Dequeue();
        //             public bool TryPop(out TNode value) => base.TryDequeue(out value);
        //         }

        //         private class WaitingStack<TNode> : Stack<TNode>, iWaiting<TNode>
        //         {
        //             HashSet<TNode> Items = new HashSet<TNode>();
        //             public new TNode Pop()
        //             {
        //                 var x = base.Pop();

        //                 while (Items.Add(x) is false)
        //                 {
        //                     if (base.TryPop(out x) is false)
        //                         break;
        //                 }

        //                 return x;
        //             }

        //             public new TNode Peek()
        //             {
        //                 var x = base.Peek();

        //                 while (Items.Contains(x))
        //                 {
        //                     if (base.TryPop(out x) is false)
        //                         break;
        //                 }

        //                 return x;
        //             }

        //             public new bool TryPop(out TNode value)
        //             {
        //                 if (base.TryPop(out value) is false)
        //                     return false;

        //                 while (Items.Add(value) is false)
        //                 {
        //                     if (base.TryPop(out value) is false)
        //                         return false;
        //                 }

        //                 return true;
        //             }
        //         }

        //         private interface iWaiting<TNode>
        //         {
        //             void Clear();
        //             void Push(TNode x);
        //             TNode Pop();
        //             TNode Peek();
        //             bool TryPop(out TNode value);
        //             bool TryPeek(out TNode value);
        //         }

        //         public enum GraphSearch
        //         {
        //             BFS = 1,
        //             DFS = -1
        //         }
        //     }
        // }
    }
}