using System;

namespace acmicpc.net.Problems.Stack
{
    public class P009012
    {
        public static void Main(string[] args)
        {
            Stack<bool> stack = new Stack<bool>(50);
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                stack.Clear();
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < input.Length; j++)
                {
                    if (input[j] == '(')
                    {
                        stack.Push(true);
                    }
                    else if (stack.IsEmpty)
                    {
                        stack.Push(true);
                        break;
                    }
                    else
                    {
                        stack.Pop(out _);
                    }
                }

                Console.WriteLine(stack.IsEmpty ? "YES" : "NO");
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

            public bool Pop(out T value)
            {
                if (this.IsEmpty)
                {
                    value = default(T);
                    return false;
                }

                value = stack[size--];
                return true;
            }

            public bool IsEmpty => size < 0;

            public int Size => size + 1;

            public bool Top(out T value)
            {
                if (this.IsEmpty)
                {
                    value = default(T);
                    return false;
                }

                value = stack[size];
                return true;
            }

            public void Clear()
            {
                size = -1;
            }
        }
    }
}