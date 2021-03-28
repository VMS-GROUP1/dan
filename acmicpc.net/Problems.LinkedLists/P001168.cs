using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace acmicpc.net.Problems.LinkedLists
{
    public class P001168
    {
        public static void Main(string[] args)
        {
            int number = 5000;
            LinkedList<LinkedList<int>> items = new LinkedList<LinkedList<int>>();
            //LinkedList<int> items = new LinkedList<int>();

            int[] n = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            LinkedList<int> group = new LinkedList<int>();
            for (int i = 0; i < n[0]; i++)
            {
                if (i % number == 0)
                {
                    group = new LinkedList<int>();
                    items.Add(group);
                    items.SaveCursor();
                    items.MovePrev();
                    items.Value?.ResetCursor();
                    items.LoadCursor();
                }

                group.Add(i + 1);
            }

            Stopwatch watch = new Stopwatch();
            watch.Start();
            int count = n[1];
            List<int> ans = new List<int>();
            items.MoveStart();
            int tempCount = count;

            while (items.IsEmpty is false)
            {
                while (tempCount > 0)
                {
                    if (tempCount <= items.Value.Count)
                        break;

                    tempCount -= items.Value.Count;
                    items.MoveNext();
                    items.Value.ResetCursor();
                }

                group = items.Value;
                group.MoveNext(count % number);
                ans.Add(group.Value);
                group.Remove();
                var tempGroup = group;
                items.SaveCursor();

                int shiftCount = 0;
                while (items.MoveNext())
                {
                    tempGroup.MoveEnd();
                    items.Value.MoveStart();
                    shiftCount++;
                    for (int i = 0; i < shiftCount; i++)
                    {
                        tempGroup.Add(items.Value.Value);
                        items.Value.Remove();
                        items.Value.MoveStart();
                        if (items.Value.IsEmpty)
                        {
                            items.Remove();
                            //items.MoveEnd();
                            break;
                        }
                    }
                    tempGroup = items.Value;
                }

                items.LoadCursor();
                if (items.Value.IsEmpty)
                {
                    items.Remove();
                    items.MoveStart();
                }

                tempCount = count - (group.Count - count % number);

            }
            Console.WriteLine($"<{string.Join(", ", ans)}>");
            // watch.Stop();
            // Console.WriteLine(watch.Elapsed.TotalSeconds);
        }

        public class LinkedList<T>
        {
            private Node Start;
            private Node End;
            private Node Cursor;
            private Node Save;
            public int Count {get; private set;}

            public bool IsEmpty => End is null;

            public T Value => Cursor == null ? default(T) : Cursor.Value;

            public void Add(T value)
            {
                Node node = new Node(value);

                node.Link(Cursor == null ? Start : Cursor.Next);
                Cursor?.Link(node);

                Start = node.Prev == null ? node : Start;
                End = node.Next == null ? node : End;

                Cursor = node;
                Count++;
            }

            public void SaveCursor()
            {
                Save = Cursor;
            }

            public void LoadCursor()
            {
                Cursor = Save;
                Save = null;
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
                End = next == null ? prev : End;

                Cursor = prev;
                Count--;

                if (Save == temp)
                    Save = null;
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

                int countM = count;

                if (circular is false)
                {
                    if (count > this.Count)
                        return false;
                    else if (count == this.Count && Cursor != null)
                        return false;
                }
                else
                {
                    if (count == this.Count || count % this.Count == 0)
                    {
                        Cursor = Cursor ?? End;
                        return true;
                    }
                    else if (count > this.Count)
                    {
                        countM = count % this.Count;
                    }

                    if (countM * 2 > this.Count)
                    {
                        MovePrev(this.Count - countM, true);
                        return true;
                    }
                }

                int move = 0;
                var temp = Cursor;
                for (int i = 0; i < countM; i++)
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

                Cursor = move == countM ? Cursor : temp;
                return move == countM;
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
                        if (circular && Cursor == null)
                        {
                            MoveEnd();
                        }
                    }
                    else if (circular)
                    {
                        MoveEnd();
                        MovePrev();
                        move++;
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