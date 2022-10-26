// 417. Pacific Atlantic Water Flow
// Tags: DFS, union
public class Solution 
{
    public IList<IList<int>> PacificAtlantic(int[][] heights) 
    {
        int rowLength = heights.Length;
        int colLength = heights[0].Length;

        List<IList<int>> result = new();
        if (rowLength == 0) 
            return result;
        
        /*
        * Pacific ocean == heights[r][-1] OR heights [-1][c]
        * Atlantic ocean == heights[r][heights[r].Length] OR heights[heights.Length][c] 
        */
        // Is this cell capable of reaching the pacific/atlantic ocean?
        var pacificReachable = new bool[rowLength, colLength];
        var atlanticReachable = new bool[rowLength, colLength];


        // Backwards approach.
        // Mapping all cells that are reachable to either the Pacific
        // or Atlantic ocean.
        for(int i = 0; i < rowLength; i++)
        {
            for(int j = 0; j < colLength; j++)
            {
                // Pacific edge.
                if(i == 0 || j == 0)
                    DFS(ref heights, int.MinValue, i, j, pacificReachable);

                // Atlantic edges.
                if(i == rowLength - 1 || j == colLength - 1)
                    DFS(ref heights, int.MinValue, i, j, atlanticReachable);
            }
        }

        // Match all cells that are reachable to both oceans.
        for(int i = 0; i < rowLength; i++)
        {
            for(int j = 0; j < colLength; j++)
            {
                if(pacificReachable[i, j] && atlanticReachable[i, j])
                    result.Add(new List<int>() { i, j });
            }
        }

        return result;
    }
    
    private void DFS(ref int[][] heights, int prevHeight, int r, int c, bool[,] isVisited)
    {
        // Bounds checking.
        if (r < 0 || c < 0 || r >= heights.Length || c >= heights[r].Length)
            return;

        // Return early if we already visited here. Otherwise, we'd get a stack overflow.
        if(isVisited[r, c])
            return;

        // Return early if the previous cell's height is higher than the current one's.
        // This means that the rain wasn't able to make it to the next cell because
        // the height was too high.
        if (prevHeight > heights[r][c])
            return;

        isVisited[r, c] = true;

        DFS(ref heights, heights[r][c], r + 1, c, isVisited);
        DFS(ref heights, heights[r][c], r - 1, c, isVisited);
        DFS(ref heights, heights[r][c], r, c + 1, isVisited);
        DFS(ref heights, heights[r][c], r, c - 1, isVisited);
    }
}