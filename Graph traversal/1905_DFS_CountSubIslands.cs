// 1905. Count Sub Islands
// Tag: DFS
// Time complexity: O(2*m*n) ==> O(n*m)
// Space complexity: O(1)

public class Solution 
{
    // Assuming jagged arrays are equal length.
    // Assuming grid1 and grid2 are the same exact same size.
    public int CountSubIslands(int[][] grid1, int[][] grid2) 
    {
        int subIslands = 0;
        
        for(int i = 0; i < grid2.Length; i++)
        {
            for(int j = 0; j < grid2[i].Length; j++)
            {
                // 1 == land
                // 0 == water
                // -1 == searched land
                if(grid2[i][j] == 1)
                {
                    SearchIsland(ref grid2, i, j);
                    if(IsValidSubIsland(ref grid2, ref grid1, i, j))
                        subIslands++;
                }
            }
        }
        return subIslands;
    }
    
    // Search grid2 island and set all searched land to -1.
    public static void SearchIsland(ref int[][]grid2, int i, int j)
    {
        // Check if we are out-of-bounds; this is water.
        if(i < 0 || j < 0 || i >= grid2.Length || j >= grid2[i].Length)
            return;
        
        // If it's water or searched land, no need to dig.
        if (grid2[i][j] == 0 || grid2[i][j] == -1)
            return;
        
        // Mark land as searched
        if(grid2[i][j] == 1)
            grid2[i][j] = -1;
        
        // DFS
        SearchIsland(ref grid2, i + 1, j);
        SearchIsland(ref grid2, i - 1, j);
        SearchIsland(ref grid2, i, j + 1);
        SearchIsland(ref grid2, i, j - 1);
    }
    
    // Check if there is any mismatch between grid2 and grid1 island.
    // If so, returns false, otherwise true.
    // Requires that the land in grid2 has been searched i.e. -1.
    public static bool IsValidSubIsland(ref int[][] grid2, ref int[][] grid1, int i, int j)
    {
        // Check if we are out-of-bounds; this is water.
        if(i < 0 || j < 0 || i >= grid2.Length || j >= grid2[i].Length)
            return true;
        
        // We encountered water, nothing interesting
        else if(grid2[i][j] == 0)
            return true;
        
        // If we have valid land on both grids, continue DFS.
        if(grid2[i][j] == -1 && grid1[i][j] == 1)
        {
            // To prevent recursing to infinity, setting searched land to water.
            grid2[i][j] = 0;
            
            // Short-circuit to save on CPU.
            return IsValidSubIsland(ref grid2, ref grid1, i + 1, j)
                && IsValidSubIsland(ref grid2, ref grid1, i - 1, j)
                && IsValidSubIsland(ref grid2, ref grid1, i, j + 1)
                && IsValidSubIsland(ref grid2, ref grid1, i, j - 1);
        }
        
        // Otherwise, we have encountered searched land in 
        // grid2 where there is no land in grid1.
        // Debug, remove later.
        if(grid2[i][j] == 1)
            System.Console.WriteLine("Encoutered unsearched land weirdly...");
        
        return false;
        
    }
}