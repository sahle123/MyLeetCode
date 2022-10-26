// 1254. Number of closed islands
// Tags: DFS 
public class Solution
{
    // Since this is a jagged array, this solution assumes
    // that all sub-arrays are equal length.
    public int ClosedIsland(int[][] grid)
    {
        int islandCount = 0;
        
        // Edge case.
        if (grid == null)
            return islandCount;
        
        // Scan the whole grid, once
        for(int i = 0; i < grid.Length; i++)
        {
            for(int j = 0; j < grid[i].Length; j++)
            {
                // Check if this land and all of its contiguous
                // land members are also enclosed.
                // If so, we increment to our final answer.
                if(grid[i][j] == 0 && _IsEnclosed(ref grid, i, j))
                    islandCount++;
            }
        }
        return islandCount;
    }
    
    // Note: will mark searched islands as -1.
    private static bool _IsEnclosed(ref int[][] grid, int i, int j)
    {
        // We can only encounter land that is not a closed 
        // island iff any of the parts of the land for that 
        // island touches the edge.
        // Otherwise, we will eventually come across water
        // and have a closed island to count.
        // Checking if we hit an edge.
        if(i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length)
            return false;
        
        // -1 indicates land that was searched.
        // 1 indicates water.
        if(grid[i][j] == 1 || grid[i][j] == -1)
            return true;
        
        // Indicate we have searched this piece of land so we
        // don't search here again later in our DFS or in our
        // for loop when we scan the grid.
        grid[i][j] = -1;
        
        // Check all 4 directions recursively to see if we
        // are still enclosed.
        // If we find a single case where we are not,
        // then our final result will be false.
        // In order to prevent short-circuiting in C#
        // we have to use the logical operator '&' instead
        // of &&, otherwise some of the directions may
        // not execute.
        return _IsEnclosed(ref grid, i + 1, j)
            & _IsEnclosed(ref grid, i - 1, j)
            & _IsEnclosed(ref grid, i, j + 1)
            & _IsEnclosed(ref grid, i, j - 1);
    }
}