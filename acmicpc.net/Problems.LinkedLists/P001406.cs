using System;
using System.Text;

namespace acmicpc.net.Problems.LinkedLists
{
    public class P001406
    {
        public static void Main(string[] args)
        {
            LinkedList<char> data = new LinkedList<char>();
            string str = Console.ReadLine();
            foreach (char c in str)
                data.Add(c);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                if (command[0] == "L")
                {
                    data.MovePrev();
                }
                else if (command[0] == "D")
                {
                    data.MoveNext();
                }
                else if (command[0] == "B")
                {
                    data.Remove();
                }
                else if (command[0] == "P")
                {
                    data.Add(command[1][0]);
                }
            }

            Console.WriteLine(data.ToString());
        }

        public class LinkedList<T>
        {
            private Node Start;
            private Node End;
            private Node Cursor;

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
                var temp = Cursor;
                if (Cursor == null)
                    Cursor = Start;
                else
                    Cursor = Cursor.Next ?? Cursor;

                return Cursor != temp;
            }

            public bool MovePrev()
            {
                var temp = Cursor;
                Cursor = Cursor?.Prev;
                return Cursor != temp;
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