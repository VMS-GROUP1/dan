using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace acmicpc.net.Problems.LinkedLists
{
    //요세푸스 문제
    public class P001158
    {
        public static void Main(string[] args)
        {
            LinkedList<int> items = new LinkedList<int>();

            int[] n = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            for (int i = 0; i < n[0]; i++)
                items.Add(i + 1);

            List<int> ans = new List<int>();
            while (items.IsEmpty is false)
            {
                items.MoveNext(n[1]);
                ans.Add(items.Value);
                items.Remove();
            }

            Console.WriteLine($"<{string.Join(", ", ans)}>");
        }

        public class LinkedList<T>
        {
            private Node Start;
            private Node End;
            private Node Cursor;

            public bool IsEmpty => End is null;

            public T Value => Cursor.Value;

            public void Add(T value)
            {
                Node node = new Node(value);

                node.Link(Cursor == null ? Start : Cursor.Next);
                Cursor?.Link(node);

                Start = node.Prev == null ? node : Start;
                End = node.Next == null ? node : End;

                Cursor = node;
            }

            public void Remove()
            {
                if (Cursor == null)
                    return;

                var temp = Cursor;
                var prev = Cursor.Prev;
                var next = Cursor.Delink();
                prev?.Link(next);

                Start = prev == null ? next : Start;
                End = next == null ? prev : Start;

                Cursor = prev;
            }

            public bool MoveNext()
            {
                if (IsEmpty)
                    return false;

                var temp = Cursor;
                if (Cursor == null)
                    Cursor = Start;
                else
                    Cursor = Cursor.Next ?? Cursor;

                return Cursor != temp;
            }

            public bool MoveNext(int count, bool circular = true)
            {
                if (IsEmpty)
                    return false;

                int move = 0;
                var temp = Cursor;
                for (int i = 0; i < count; i++)
                {
                    if (MoveNext())
                    {
                        move++;
                    }
                    else if (circular)
                    {
                        move++;
                        MoveStart();
                    }
                    else
                    {
                        break;
                    }
                }

                Cursor = move == count ? Cursor : temp;
                return move == count;
            }

            public bool MovePrev()
            {
                if (IsEmpty)
                    return false;

                var temp = Cursor;
                Cursor = Cursor?.Prev;
                return Cursor != temp;
            }

            public bool MovePrev(int count, bool circular = true)
            {
                if (IsEmpty)
                    return false;

                int move = 0;
                var temp = Cursor;
                for (int i = 0; i < count; i++)
                {
                    if (MovePrev())
                    {
                        move++;
                    }
                    else if (circular)
                    {
                        move++;
                        MoveEnd();
                    }
                    else
                    {
                        break;
                    }
                }

                Cursor = move == count ? Cursor : temp;
                return move == count;
            }

            public void ResetCursor()
            {
                Cursor = null;
            }

            public void MoveStart()
            {
                Cursor = Start;
            }

            public void MoveEnd()
            {
                Cursor = End;
            }

            public override string ToString()
            {
                if (Start is null)
                    return null;

                StringBuilder stringBuilder = new StringBuilder();
                var temp = Cursor;
                ResetCursor();
                while (MoveNext())
                {
                    stringBuilder.Append(Cursor.Value.ToString());
                }
                Cursor = temp;

                return stringBuilder.ToString();
            }

            private class Node
            {
                public Node Prev { get; private set; }
                public Node Next { get; private set; }
                public T Value { get; private set; }
                public Node(T value)
                {
                    Value = value;
                }

                public void Link(Node next)
                {
                    Next = next;
                    if (next != null)
                        next.Prev = this;
                }

                public Node Delink()
                {
                    var next = this.Next;
                    this.Next = null;

                    if (next != null)
                        next.Prev = null;

                    return next;
                }
            }
        }
    }
}