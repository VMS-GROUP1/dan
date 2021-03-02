using System;
using System.Collections.Generic;
using System.Text;

namespace acmicpc.net.Problems.Stack
{
    public class P010828
    {
        private static StringBuilder builder = new StringBuilder();
        public static void Main(string[] args)
        {

            Stack<int> stack = new Stack<int>(10_000);

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] str = Console.ReadLine().Split();
                Do(str, stack);
            }

            Console.WriteLine(builder.ToString());
        }

        private static void Do(string[] str, Stack<int> stack)
        {
            switch (str[0])
            {
                case "push":
                    stack.Push(int.Parse(str[1]));
                    break;
                case "pop":
                    builder.AppendLine((stack.IsEmpty ? -1 : stack.Pop()).ToString());
                    break;
                case "size":
                    builder.AppendLine(stack.Size.ToString());
                    break;
                case "empty":
                    builder.AppendLine((stack.IsEmpty ? 1 : 0).ToString());
                    break;
                case "top":
                    builder.AppendLine((stack.IsEmpty ? -1 : stack.Top).ToString());
                    break;
                default:
                    break;
            }
        }

        public class Stack<T>
        {
            private int size;
            private T[] stack;

            public Stack(int max)
            {
                stack = new T[max];
                size = -1;
            }

            public void Push(T value)
            {
                stack[++size] = value;
            }

            public T Pop()
            {
                T value = stack[size--];
                return value;
            }

            public bool IsEmpty => size < 0;

            public int Size => size + 1;

            public T Top => stack[size];
        }
    }
}