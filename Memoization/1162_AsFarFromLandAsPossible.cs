// 1162. As far from land as possible
// Tags: BFS, dynamic programming, memoization
public class Solution 
{
    // Assuming jagged array has same size sub-arrays.
    public int MaxDistance(int[][] grid) 
    {
        int largestManhattanDist = 0;
        int rowLength = grid.Length;
        int colLength = grid[0].Length;
        
        // Memoization.
        // Keeping track of each cells distance to the nearest 1 on the grid.
        int[,] shortestDists = new int[rowLength, colLength];
        
        Queue<(int row, int col, int dist)> q = new();
        
        // Setting up queue.
        // Queuing all 0-cells and initializing their distances to -1.
        for(int i = 0; i < rowLength; i++)
        {
            for(int j = 0; j < colLength; j++)
            {
                // Queue up BFS for a 0-cells.
                // 1-cells' distance is set to 0.
                if(grid[i][j] == 1)
                {
                    q.Enqueue((i, j, 0));
                    shortestDists[i, j] = 0;
                }
                // Otherwise, 0-cell and we initialize to -1
                // to indicate that the distance hasn't been
                // calculated yet.
                else
                    shortestDists[i, j] = -1;
            }
        }
        
        // BFS
        // 1. Pop queue and see if the next 'shortest' distance is the biggest.
        // 2. Traverse cells in 4-directions and add to queue and shortestDist array.
        while(q.Count > 0)
        {
            var (row, col, dist) = q.Dequeue();
            largestManhattanDist = Math.Max(largestManhattanDist, dist);
            QueueIfValidCell(ref q, ref shortestDists, row + 1, col, dist + 1, rowLength, colLength);
            QueueIfValidCell(ref q, ref shortestDists, row - 1, col, dist + 1, rowLength, colLength);
            QueueIfValidCell(ref q, ref shortestDists, row, col + 1, dist + 1, rowLength, colLength);
            QueueIfValidCell(ref q, ref shortestDists, row, col - 1, dist + 1, rowLength, colLength);
        }
        
        return largestManhattanDist == 0 ? -1 : largestManhattanDist;
    }
    
    // Determines distance for cell and continues the BFS if
    // we are on an uninitialized 0-cell.
    public static void QueueIfValidCell(ref Queue<(int row, int col, int dist)> q, 
                                        ref int[,] shortestDists, 
                                        int row, int col, int dist, int rowLength, int colLength)
    {
        // Bounds checking.
        if(row < 0 || col < 0 || row >= rowLength || col >= colLength)
            return;
        
        // Optimization.
        // If we are not on an unintialized 0-cell, then skip it and
        // stop BFS from that cell onward.
        if(shortestDists[row, col] != -1)
            return;
        
        shortestDists[row, col] = dist;
        q.Enqueue((row, col, dist)); 
    }
}