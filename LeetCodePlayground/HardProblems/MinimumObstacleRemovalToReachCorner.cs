namespace LeetCodePlayground.HardProblems
{
    /// <summary>
    /// The class for problem 2290. Minimum obstacle removal to reach corner
    /// </summary>
    internal class MinimumObstacleRemovalToReachCorner
    {
        public int MinimumObstacles(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            PriorityQueue<(int x, int y), int> moves = new PriorityQueue<(int x, int y), int>();
            bool[,] visited = new bool[m, n];

            AddMove(0,0, grid[0][0]);

            while (moves.Count > 0)
            {
                (int x, int y) cell;
                int removals;

                moves.TryDequeue(out cell, out removals);

                if(cell.x == m -1 && cell.y == n - 1)
                    return removals;

                AddMove(cell.x + 1, cell.y, removals);
                AddMove(cell.x - 1, cell.y, removals);
                AddMove(cell.x, cell.y + 1, removals);
                AddMove(cell.x, cell.y - 1, removals);
            }

            void AddMove(int x,int y, int removals)
            {
                if(x < 0 || x >= m || y < 0 || y >= n)
                    return;

                if (visited[x,y])
                    return;

                visited[x,y] = true;
                moves.Enqueue((x, y), removals + grid[x][y]);
            }

            return -1;
        }
    }
}
