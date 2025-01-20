namespace LeetCodePlayground.HardProblems
{
    /// <summary>
    /// The class for problem 2577. Minimum time to visit a cell in a grid.
    /// </summary>
    internal class MInTImeToVisitACell
    {
        /// <summary>
        /// Seems to work fine but too long
        /// </summary>
        public int MinimumTimeFirstTry(int[][] grid)
        {
            int width = grid.Length;
            int height = grid[0].Length;
            int[,] visited = new int[width, height];
            BFS(0, 0, 0);

            void BFS(int time, int x, int y)
            {
                if (x >= width || x < 0 || y >= height || y < 0)
                    return;

                if (grid[x][y] > time)
                {
                    if ((x == 0 && y == 1) || (x == 1 && y == 0))
                        return;
                    var delta = grid[x][y] - time;
                    time += delta % 2 == 0 ? delta : delta + 1; 
                }

                if (visited[x, y] != 0)
                {

                    if (visited[x, y] > time)
                        visited[x, y] = time;
                    else
                        return;
                }
                else
                    visited[x, y] = time;

                BFS(time + 1, x + 1, y);
                BFS(time + 1, x - 1, y);
                BFS(time + 1, x, y - 1);
                BFS(time + 1, x, y + 1);
            }

            return visited[width-1, height -1] == 0 ? -1 : visited[width-1, height-1];
        }

        /// <summary>
        /// Work fine, not like to store time twice in structures
        /// </summary>
        public int MinimumTimeSecondTry(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            if (grid[0][1] > 1 && grid[1][0] > 1)
                return -1;

            PriorityQueue<(int x, int y, int time), int> moves = new PriorityQueue<(int x, int y, int time), int>();
            int[,] visited = new int[m, n];

            moves.Enqueue((0, 0, 0), 0);

            while (moves.Count > 0)
            {
                var (x, y, time) = moves.Dequeue();

                if (x == m - 1 && y == n - 1)
                    return time;

                Add(x + 1, y, time + 1);
                Add(x - 1, y, time + 1);
                Add(x, y + 1, time + 1);
                Add(x, y - 1, time + 1);
            }

            void Add(int x, int y, int time)
            {
                if (x < 0 || x >= m || y < 0 || y >= n)
                    return;

                if (grid[x][y] > time)
                {
                    var delta = grid[x][y] - time;
                    time += delta % 2 == 0 ? delta : delta + 1;
                }

                if (visited[x, y] > time || visited[x, y] == 0)
                {
                    visited[x, y] = time;
                    moves.Enqueue((x, y, time), time);
                }
            }
            return -1;
        }


        /// <summary>
        /// Final implementation that fixes problem with double storing time
        /// </summary>
        public int MinimumTime(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            if (grid[0][1] > 1 && grid[1][0] > 1)
                return -1;

            PriorityQueue<(int x, int y), int> moves = new PriorityQueue<(int x, int y), int>();
            int[,] visited = new int[m, n];

            moves.Enqueue((0, 0), 0);

            while (moves.Count > 0)
            {
                (int x, int y) pos;
                int time;
                moves.TryDequeue(out pos, out time);

                if (pos.x == m - 1 && pos.y == n - 1)
                    return time;

                Add(pos.x + 1, pos.y, time + 1);
                Add(pos.x - 1, pos.y, time + 1);
                Add(pos.x, pos.y + 1, time + 1);
                Add(pos.x, pos.y - 1, time + 1);
            }

            void Add(int x, int y, int time)
            {
                if (x < 0 || x >= m || y < 0 || y >= n)
                    return;

                if (grid[x][y] > time)
                {
                    var delta = grid[x][y] - time;
                    time += delta % 2 == 0 ? delta : delta + 1;
                }

                if (visited[x, y] > time || visited[x, y] == 0)
                {
                    visited[x, y] = time;
                    moves.Enqueue((x, y), time);
                }
            }
            return -1;
        }
    }
}
