using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePlayground.HardProblems
{
    /// <summary>
    /// The class for problem 1568. Minimum Number of Days to Disconnect Island
    /// </summary>
    public class IslandMinDays
    {
        public int MinDays(int[][] grid)
        {
            if (CountIslands(grid) != 1) return 0;

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[0].Length; j++)
                    if (grid[i][j] == 1)
                    {
                        grid[i][j] = 0;
                        if (CountIslands(grid) != 1) return 1;
                        grid[i][j] = 1;
                    }

            return 2;
        }

        private int CountIslands(int[][] grid)
        {
            int rows = grid.Length, cols = grid[0].Length, islandCount = 0;
            bool[,] visited = new bool[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (grid[i][j] == 1 && !visited[i, j])
                    {
                        islandCount++;
                        if (islandCount > 1) return islandCount;
                        DFS(grid, visited, i, j);
                    }

            return islandCount;
        }

        private void DFS(int[][] grid, bool[,] visited, int r, int c)
        {
            int rows = grid.Length, cols = grid[0].Length;
            if (r < 0 || c < 0 || r >= rows || c >= cols || grid[r][c] == 0 || visited[r, c]) return;

            visited[r, c] = true;

            DFS(grid, visited, r + 1, c);
            DFS(grid, visited, r - 1, c);
            DFS(grid, visited, r , c + 1);
            DFS(grid, visited, r, c - 1);
        }
    }
}
