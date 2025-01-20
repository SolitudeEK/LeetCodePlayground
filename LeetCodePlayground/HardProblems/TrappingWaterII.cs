namespace LeetCodePlayground.HardProblems
{
    /// <summary>
    /// The class for problem 407. Trapping Rain Water II.
    /// </summary>
    internal class TrappingWaterII
    {
        public int TrapRainWater(int[][] heightMap)
        {
            int m = heightMap.Length;
            int n = heightMap[0].Length;

            bool[,] visited = new bool[m, n];
            PriorityQueue<(int height, int x, int y), int> minHeap = new();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
                    {
                        minHeap.Enqueue((heightMap[i][j], i, j), heightMap[i][j]);
                        visited[i, j] = true;
                    }
                }
            }

            int[][] directions = new int[][] {
            new int[] { -1, 0 }, // up
            new int[] { 1, 0 },  // down
            new int[] { 0, -1 }, // left
            new int[] { 0, 1 }   // right
        };

            int trappedWater = 0;

            while (minHeap.Count > 0)
            {
                var (height, x, y) = minHeap.Dequeue();

                foreach (var dir in directions)
                {
                    int newX = x + dir[0];
                    int newY = y + dir[1];

                    if (newX >= 0 && newX < m && newY >= 0 && newY < n && !visited[newX, newY])
                    {
                        visited[newX, newY] = true;
                        trappedWater += Math.Max(0, height - heightMap[newX][newY]);
                        minHeap.Enqueue((Math.Max(height, heightMap[newX][newY]), newX, newY), Math.Max(height, heightMap[newX][newY]));
                    }
                }
            }

            return trappedWater;
        }
    }
}
