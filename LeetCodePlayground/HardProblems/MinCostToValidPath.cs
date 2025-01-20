namespace LeetCodePlayground.HardProblems
{
    /// <summary>
    /// The class for problem 1368. Minimum Cost to Make at Least One Valid Path in a Grid
    /// </summary>
    internal class MinCostToValidPath
    {
        public int MinCost(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            var pq = new PriorityQueue<(int X, int Y), int>();
            var visisted = new bool[m, n];

            pq.Enqueue((0, 0), 0);

            while (pq.Count > 0)
            {
                pq.TryDequeue(out var cell ,out var priority);

                if (cell.X == m - 1 && cell.Y == n - 1)
                    return priority;

                if (cell.X < 0 || cell.X >= m || cell.Y < 0 || cell.Y >= n || visisted[cell.X,cell.Y])
                    continue;

                visisted[cell.X,cell.Y] = true;

                switch (grid[cell.X][cell.Y]) 
                {
                    case 1: 
                        pq.Enqueue((cell.X, cell.Y+1), priority);
                        break;
                    case 2:
                        pq.Enqueue((cell.X, cell.Y-1), priority);
                        break;
                    case 3:
                        pq.Enqueue((cell.X+1, cell.Y), priority);
                        break;
                    case 4:
                        pq.Enqueue((cell.X-1, cell.Y), priority);
                        break;
                }
                pq.Enqueue((cell.X, cell.Y + 1), priority + 1);
                pq.Enqueue((cell.X, cell.Y - 1), priority + 1);
                pq.Enqueue((cell.X + 1, cell.Y), priority + 1);
                pq.Enqueue((cell.X - 1, cell.Y), priority + 1);
            }

            return 0;
        }
    }
}
