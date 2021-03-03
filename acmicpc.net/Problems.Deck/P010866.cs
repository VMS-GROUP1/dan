using System;
using System.Text;

namespace acmicpc.net.Problems.Deck
{
    public class P010866
    {
        private static StringBuilder builder = new StringBuilder();
        public static void Main(string[] args)
        {
            Deck<int> deck = new Deck<int>(10_000);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] str = Console.ReadLine().Split();
                Do(str, deck);
            }

            Console.WriteLine(builder.ToString());
        }

        private static void Do(string[] str, Deck<int> deck)
        {
            switch (str[0])
            {
                case "push_front":
                    deck.PushFront(int.Parse(str[1]));
                    break;
                case "push_back":
                    deck.PushBack(int.Parse(str[1]));
                    break;
                case "pop_front":
                    builder.AppendLine((deck.IsEmpty ? -1 : deck.PopFront()).ToString());
                    break;
                case "pop_back":
                    builder.AppendLine((deck.IsEmpty ? -1 : deck.PopBack()).ToString());
                    break;
                case "size":
                    builder.AppendLine(deck.Size.ToString());
                    break;
                case "empty":
                    builder.AppendLine((deck.IsEmpty ? 1 : 0).ToString());
                    break;
                case "front":
                    builder.AppendLine((deck.IsEmpty ? -1 : deck.Front).ToString());
                    break;
                case "back":
                    builder.AppendLine((deck.IsEmpty ? -1 : deck.Back).ToString());
                    break;
                default:
                    break;
            }
        }

        class Deck<T>
        {
            private T[] D;
            private int Begin;
            private int End;

            public Deck(int max)
            {
                D = new T[max];
                Begin = 0;
                End = 0;
                Size = 0;
            }

            public void PushFront(T value)
            {
                if (Size++ == 0)
                {
                    D[Begin] = value;
                    return;
                }

                if (Begin == 0)
                    Begin = D.Length;

                D[--Begin] = value;
            }

            public void PushBack(T value)
            {
                if (Size++ == 0)
                {
                    D[End] = value;
                    return;
                }

                if (End == D.Length - 1)
                    End = -1;

                D[++End] = value;
            }

            public T PopFront()
            {
                T value = D[Begin++];
                Size--;

                if (Begin == D.Length)
                    Begin = 0;

                if (Size == 0)
                    Clear();

                return value;
            }

            public T PopBack()
            {
                T value = D[End--];
                Size--;

                if (End < 0)
                    End = D.Length - 1;

                if (Size == 0)
                    Clear();

                return value;
            }

            public bool IsEmpty => Size <= 0;

            public int Size { get; private set; }

            public T Front => D[Begin];

            public T Back => D[End];

            public void Clear()
            {
                Begin = 0;
                End = 0;
                Size = 0;
            }
        }
    }
}