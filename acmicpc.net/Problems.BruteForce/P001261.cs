using System;
using System.Collections.Generic;
using System.Linq;

namespace acmicpc.net.Problems.BruteForce
{
    public class P001261
    {
        private static int N;
        private static int M;
        private static int[,] Map;
        private static int[,] Visited;
        public static void Main(string[] args)
        {
            int[] p = Array.ConvertAll(Console.ReadLine().Split(), x => int.Parse(x));
            N = p[0];
            M = p[1];
            Map = new int[M, N];
            Visited = new int[M, N];

            for (int i = 0; i < M; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < N; j++)
                {
                    Map[i, j] = line[j] - '0';
                    Visited[i, j] = -1;
                }
            }

            int ans = Bfs();
            Console.WriteLine(ans);
        }

        private static int Bfs()
        {
            Queue<Room> waiting = new Queue<Room>();
            waiting.Enqueue(new Room(0, 0, 0));
            //int ans = 0;

            while (waiting.TryDequeue(out var room))
            {
                if (CanUpdate(room) is false)
                    continue;

                Visited[room.X, room.Y] = room.Cost;
                if (room.X == M - 1 && room.Y == N - 1)
                    continue;

                for (int i = 0; i < 4; i++)
                {
                    int x = room.X + (i + 1) % 2 * (2 * (i / 2) - 1);
                    int y = room.Y + i % 2 * (2 * (i / 2) - 1);

                    if (x < 0 || y < 0 || x >= M || y >= N)
                        continue;

                    Room next = new Room(x, y, room.Cost + Map[x, y]);
                    if (CanUpdate(next) is false)
                        continue;

                    waiting.Enqueue(next);
                }
            }

            return Visited[M - 1, N - 1];
        }

        private static bool CanUpdate(Room room)
        {
            int cost = Visited[room.X, room.Y];
            return cost == -1 || cost > room.Cost;
        }

        private struct Room
        {
            public int X;
            public int Y;
            public int Cost;

            public Room(int x, int y, int cost)
            {
                this.X = x;
                this.Y = y;
                this.Cost = cost;
            }
        }
    }
}