using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.LinkedLists
{
    public class P003190
    {
        public static void Main(string[] args)
        {
            LinkedList<(int row, int col)> snake = new LinkedList<(int row, int col)>();
            snake.AddFirst((1, 1));

            int size = int.Parse(Console.ReadLine());
            int[,] apple = new int[size + 1, size + 1];

            int countA = int.Parse(Console.ReadLine());
            for (int i = 0; i < countA; i++)
            {
                int[] point = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                apple[point[0], point[1]] = 1;
            }

            string[] actionInput = new string[10_000 + 1];
            int countM = int.Parse(Console.ReadLine());
            for (int i = 0; i < countM; i++)
            {
                string[] input = Console.ReadLine().Split();
                int time = int.Parse(input[0]);
                string direction = input[1];

                actionInput[time] = direction;
            }

            int count = 0;
            string d = "R";
            while (true)
            {
                count++;
                (int row, int col) p;
                if (d == "R")
                {
                    p = (snake.First.Value.row, snake.First.Value.col + 1);
                }
                else if (d == "L")
                {
                    p = (snake.First.Value.row, snake.First.Value.col -1);
                }
                else if (d == "T")
                {
                    p = (snake.First.Value.row - 1, snake.First.Value.col);
                }
                else
                {
                    p = (snake.First.Value.row + 1, snake.First.Value.col);
                }

                if (p.row <= 0 || p.row > size)
                    break;
                if (p.col <= 0 || p.col > size)
                    break;
                if (snake.Contains(p))
                    break;

                snake.AddFirst(p);
                if (apple[p.row, p.col] == 0)
                    snake.RemoveLast();
                else
                    apple[p.row, p.col] = 0;

                string action = actionInput[count];
                if (action == "L")
                {
                    d = d == "R" ? "T" : d == "T" ? "L" : d == "L" ? "B" : "R";
                }
                else if (action == "D")
                {
                    d = d == "R" ? "B" : d == "B" ? "L" : d == "L" ? "T" : "R";
                }
            }

            Console.WriteLine(count);
        }
    }
}