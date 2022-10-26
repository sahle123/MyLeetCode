// INCOMPLETE!
// 417. Pacific Atlantic Water Flow
// Tags: BFS
public class Solution 
{
    // DEV-NOTE: Add detailed description later.
    // Assuming that jagged array sub-arrays are all
    // of equal length.
    public IList<IList<int>> PacificAtlantic(int[][] heights) 
    {
        /*
        * Atlantic ocean == heights[r][heights[r].Length] OR heights[heights.Length][c] 
        * Pacific ocean == heights[r][-1] OR heights [-1][c]
        */
        List<List<int>> ans = new();

        // For checking for path to Atlantic ocean.
        Queue<(int row, int col)> qAtlantic = new();
        // For checking for path to Pacific ocean.
        Queue<(int row, int col)> qPacific = new();


        for(int i = 0; i < heights.Length; i++)
        {
            for(int j = 0; j < heights[i].Length; j++)
            {
                q.Enqueue((i, j, 0));
                while(q.Count > 0)
                {

                }
            }
        }

        return ans;
    }




    // Pacific ocean == heights[r][-1] OR heights [-1][c]
    private static bool ExistsPathToPacific(ref Queue<(int row, int col)> q, ref int[][] heights, int initRow, int initCol)
    {

    }

    // Atlantic ocean == heights[r][heights[r].Length] OR heights[heights.Length][c] 
    private static bool ExistsPathToAtlantic(ref Queue<(int row, int col)> q, ref int[][] heights, int initRow, int initCol)
    {

    }
}