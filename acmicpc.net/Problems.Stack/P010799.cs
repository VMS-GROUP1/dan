using System;

namespace acmicpc.net.Problems.Stack
{
    public class P010799
    {
        public static void Main(string[] args)
        {
            Stack<bool> stack = new Stack<bool>(100_000);

            char[] input = Console.ReadLine().ToCharArray();
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    if (stack.IsEmpty is false && stack.Top())
                        stack.Pop();

                    stack.Push(false);
                    stack.Push(true);
                }
                else if (stack.Top())
                {
                    stack.Pop();
                    stack.Pop();
                    count += stack.Size;
                }
                else
                {
                    stack.Pop();
                    count++;
                }
            }

            Console.WriteLine(count);
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
                return stack[size--];
            }

            public bool IsEmpty => size < 0;

            public int Size => size + 1;

            public T Top()
            {
                return stack[size];
            }

            public void Clear()
            {
                size = -1;
            }
        }
    }
}