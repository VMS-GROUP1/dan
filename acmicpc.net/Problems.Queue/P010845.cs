using System;
using System.Text;

namespace acmicpc.net.Problems.Queue
{
    public class P010845
    {
        private static StringBuilder builder = new StringBuilder();
        public static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(10_000);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] str = Console.ReadLine().Split();
                Do(str, queue);
            }

            Console.WriteLine(builder.ToString());
        }

        private static void Do(string[] str, Queue<int> queue)
        {
            switch (str[0])
            {
                case "push":
                    queue.Push(int.Parse(str[1]));
                    break;
                case "pop":
                    builder.AppendLine((queue.IsEmpty ? -1 : queue.Pop()).ToString());
                    break;
                case "size":
                    builder.AppendLine(queue.Size.ToString());
                    break;
                case "empty":
                    builder.AppendLine((queue.IsEmpty ? 1 : 0).ToString());
                    break;
                case "front":
                    builder.AppendLine((queue.IsEmpty ? -1 : queue.Front).ToString());
                    break;
                case "back":
                    builder.AppendLine((queue.IsEmpty ? -1 : queue.Back).ToString());
                    break;
                default:
                    break;
            }
        }

        class Queue<T>
        {
            private T[] Q;
            private int Begin;
            private int End;

            private void Shift()
            {
                T[] temp = new T[this.Size];
                Begin = 0;
                End = this.Size;
                Q = temp;
            }

            public Queue(int max)
            {
                Q = new T[max];
                Begin = 0;
                End = 0;
            }

            public void Push(T value)
            {
                if (End == Q.Length && this.Size < Q.Length)
                {
                    Shift();
                }

                Q[End++] = value;
            }

            public T Pop()
            {
                return Q[Begin++];
            }

            public bool IsEmpty => End == Begin;

            public int Size => End - Begin;

            public T Front => Q[Begin];

            public T Back => Q[End - 1];

            public void Clear()
            {
                Begin = 0;
                End = 0;
            }
        }
    }
}