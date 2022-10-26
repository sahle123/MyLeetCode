// This solution uses DFS since we are using the callstack (or we could use the Stack class)
// which would likely be more suitable for larger data sets.
public class Solution 
{
    private int _runningAreaTemp;

    // Assumes that the jagged array is the same length
    // across all elements.
    public int MaxAreaOfIsland(int[][] grid) 
    {
        int result = 0;

        for(int i = 0; i < grid.Length; i++)
        {
            for(int j = 0; j < grid[i].Length; j++)
            {
                if(grid[i][j] == 1)
                {
                    _runningAreaTemp = 0;

                    // Do DFS
                    IsleDFS(ref grid, i, j);

                    // Copy over new largest area.
                    if (_runningAreaTemp > result)
                        result = _runningAreaTemp;
                }
            }
        }
        return result;
    }

    // Any searched land node will be reassigned to -1.
    // (Current area, increment). The increment is needed for recursion.
    private void IsleDFS(ref int[][] grid, int i, int j)
    {
        // At the edges; return 0 for area.
        if (i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length)
            return;

        // We found water/searched here already; return 0 for area.
        if (grid[i][j] == 0)
            return;

        // Mark as searched.
        grid[i][j] = 0;
        _runningAreaTemp++;

        // Do DFS search
        foreach(var d in _dirs())
            IsleDFS(ref grid, i+d[0], j+d[1]);
    }

    // 4-way directions from node. Up, down, left, right.
    private static int[][] _dirs()
    {
        return new int[][]
        {
            new int[]{1,0}, new int[]{-1,0}, new int[]{0,-1}, new int[]{0,1}
        };
    }
}