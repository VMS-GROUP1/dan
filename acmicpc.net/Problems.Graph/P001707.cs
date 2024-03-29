using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace acmicpc.net.Problems.Graph
{
    public class P001707
    {
        public static void Main(string[] args)
        {
            int numTC = int.Parse(Console.ReadLine());

            for (int k = 0; k < numTC; k++)
            {
                int[] input = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                int n = input[0];
                int m = input[1];
                List<int>[] nodes = new List<int>[n + 1];
                int[] group = new int[n + 1];
                bool check = true;

                for (int i = 1; i <= n; i++)
                {
                    nodes[i] = new List<int>();
                }

                for (int i = 0; i < m; i++)
                {
                    var edge = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                    nodes[edge[0]].Add(edge[1]);
                    nodes[edge[1]].Add(edge[0]);
                }

                for (int i = 1; i <= n; i++)
                {
                    if (group[i] > 0 || Dfs(nodes, i, group))
                        continue;

                    check = false;
                    break;
                }

                Console.WriteLine(check ? "YES" : "NO");
            }
        }

        private static bool Dfs(List<int>[] nodes, int start, int[] group)
        {
            Stack<int> queue = new Stack<int>();
            bool check = true;

            int number = 1;
            queue.Push(start);
            group[start] = 1;

            while (queue.Count > 0)
            {
                int i = queue.Pop();
                number = group[i];

                foreach (var j in nodes[i])
                {
                    if (group[j] == 0)
                    {
                        group[j] = 3 - number;
                        queue.Push(j);
                    }
                    else if (group[j] == number)
                    {
                        check = false;
                        break;
                    }
                }
            }

            return check;
        }


        // public class Graph<T> where T : IComparable
        // {
        //     private Node Start;
        //     private GraphSearch Search;
        //     private Node Current;
        //     private Dictionary<T, Node> Vertexes = new Dictionary<T, Node>();
        //     private HashSet<Node> Visited = new HashSet<Node>();
        //     private iWaiting<Node> WaitingNodes = new WaitingStack<Node>();
        //     private Func<T, T, int> Comparison;
        //     private HashSet<(T, T)> Edges = new HashSet<(T, T)>();
        //     private Dictionary<Node, Node> Guide = new Dictionary<Node, Node>();

        //     public T Value => Current == null ? default(T) : Current.NodeID;

        //     public bool Add(T index)
        //     {
        //         if (Vertexes.ContainsKey(index) is false)
        //         {
        //             Vertexes.Add(index, new Node(index));
        //             return true;
        //         }

        //         return false;
        //     }

        //     public void Link(T x, T y)
        //     {
        //         Vertexes[x].Link(Vertexes[y]);
        //         Edges.Add((x, y));
        //     }

        //     public bool MoveNext()
        //     {
        //         if (Start != null)
        //         {
        //             Current = Start;
        //             Visited.Add(Current);
        //             Start = null;
        //             return true;
        //         }

        //         //var neighbors = Current.GetNeighbors().Where(x => Visited.Contains(x) is false).ToList();
        //         // if (Comparison != null)
        //         //     neighbors.Sort((x, y) => Comparison(x.NodeID, y.NodeID) * (int)Search);
        //         var neighbors = Current.GetNeighbors().Where(x => Visited.Contains(x) is false);
        //         foreach (var node in (int)Search < 0 ? neighbors.Reverse() : neighbors)
        //         {
        //             if ((int)Search < 0)
        //                 Guide[node] = Current;
        //             else
        //                 Guide.TryAdd(node, Current);

        //             WaitingNodes.Push(node);
        //         }

        //         WaitingNodes.TryPop(out Current);

        //         return Current != null && Visited.Add(Current);
        //     }

        //     public bool TryGetGuide(T x, out T value)
        //     {
        //         var node = Vertexes[x];
        //         if (Guide.TryGetValue(node, out var guide) is false)
        //         {
        //             value = default(T);
        //             return false;
        //         }

        //         value = guide.NodeID;
        //         return true;
        //     }

        //     public void UnLink(T x, T y)
        //     {
        //         Vertexes[x].Remove(Vertexes[y]);
        //     }

        //     public IEnumerable<(T, T)> GetEdges => this.Edges;

        //     public IEnumerable<T> GetLinks(T id)
        //     {
        //         return Vertexes[id].GetNeighbors().Select(x => x.NodeID);
        //     }

        //     public void ResetMove(T id, GraphSearch search, Func<T, T, int> comparison = null)
        //     {
        //         Start = Vertexes[id];
        //         Current = null;
        //         Search = search;
        //         Comparison = comparison ?? new Func<T, T, int>((x, y) => x.CompareTo(y));
        //         Visited.Clear();
        //         WaitingNodes.Clear();
        //         Guide.Clear();

        //         switch (search)
        //         {
        //             case GraphSearch.BFS:
        //                 WaitingNodes = new WaitingQueue<Node>();
        //                 break;
        //             case GraphSearch.DFS:
        //                 WaitingNodes = new WaitingStack<Node>();
        //                 break;
        //             default:
        //                 break;
        //         }
        //     }

        //     [DebuggerDisplay("NodeID = {NodeID}")]
        //     private class Node
        //     {
        //         public T NodeID { get; private set; }
        //         private SortedList<T, Node> Linked = new SortedList<T, Node>();

        //         public Node(T id)
        //         {
        //             NodeID = id;
        //         }

        //         public void Link(Node other)
        //         {
        //             if (Linked.ContainsKey(other.NodeID))
        //                 return;

        //             Linked.Add(other.NodeID, other);
        //         }

        //         public void Remove(Node other)
        //         {
        //             Linked.Remove(other.NodeID);
        //         }

        //         public IEnumerable<Node> GetNeighbors()
        //         {
        //             return Linked.Values;
        //         }
        //     }

        //     private class WaitingQueue<TNode> : Queue<TNode>, iWaiting<TNode>
        //     {
        //         HashSet<TNode> Items = new HashSet<TNode>();
        //         public void Push(TNode x)
        //         {
        //             if (Items.Add(x))
        //                 base.Enqueue(x);
        //         }
        //         public TNode Pop() => base.Dequeue();
        //         public bool TryPop(out TNode value) => base.TryDequeue(out value);
        //     }

        //     private class WaitingStack<TNode> : Stack<TNode>, iWaiting<TNode>
        //     {
        //         HashSet<TNode> Items = new HashSet<TNode>();
        //         public new TNode Pop()
        //         {
        //             var x = base.Pop();

        //             while (Items.Add(x) is false)
        //             {
        //                 if (base.TryPop(out x) is false)
        //                     break;
        //             }

        //             return x;
        //         }

        //         public new TNode Peek()
        //         {
        //             var x = base.Peek();

        //             while (Items.Contains(x))
        //             {
        //                 if (base.TryPop(out x) is false)
        //                     break;
        //             }

        //             return x;
        //         }

        //         public new bool TryPop(out TNode value)
        //         {
        //             if (base.TryPop(out value) is false)
        //                 return false;

        //             while (Items.Add(value) is false)
        //             {
        //                 if (base.TryPop(out value) is false)
        //                     return false;
        //             }

        //             return true;
        //         }
        //     }

        //     private interface iWaiting<TNode>
        //     {
        //         void Clear();
        //         void Push(TNode x);
        //         TNode Pop();
        //         TNode Peek();
        //         bool TryPop(out TNode value);
        //         bool TryPeek(out TNode value);
        //     }

        //     public enum GraphSearch
        //     {
        //         BFS = 1,
        //         DFS = -1
        //     }
        // }
    }
}