// 1706. Where Will the Ball Fall
// Tags: DFS
//
// Time complexity:
// Space complexity:

public class Solution 
{
    private static int _rowLen { get; set; }
    private static int _colLen { get; set; }
    private static int[] _result { get; set; }
    
    // Assuming jagged array is uniform across all of 1st dimension.
    public int[] FindBall(int[][] grid) 
    {
        // Edge cases.
        if(grid == null)
            return new int[1];
        else if(grid[0]== null)
            return new int[1];
        
        _rowLen = grid.Length;
        _colLen = grid[0].Length;
        _result = new int[_colLen];
        
        // DEBUG CODE.
        //System.Console.WriteLine($"Dimensions: [{_rowLen}, {_colLen}]");
        
        // Initialize array to -1 default values.
        Array.Fill(_result, -1);        
        
        // Do a DFS over each column in the first row.
        for(int j = 0; j < _colLen; j++)
        {
            // DFS over the current column.
            _columnDFS(ref grid, 0, j, j);
        }
        
        return _result;
    }
    
    private static void _columnDFS(ref int[][] grid, int row, int col, int ballNo)
    {
        //System.Console.WriteLine($"[{row}, {col}], Ball: {ballNo}");
        
        // Bounds checking.
        if(row < 0 || col < 0 || col >= _colLen)
            return;
        
        // Ball has reached bottom, we have found our answer.
        else if(row >= _rowLen)
        {
            _result[ballNo] = col;
            return;
        }
        
        // For down-right slopes (1).
        if(grid[row][col] == 1)
        {
            if(col < (_colLen - 1))
            {
                if(grid[row][col + 1] == 1)
                    _columnDFS(ref grid, ++row, ++col, ballNo);
            }
        }
        // For down-left slopes (-1).
        else if(grid[row][col] == -1)
        {
            if(col > 0)
            {
                if(grid[row][col - 1] == -1)
                    _columnDFS(ref grid, ++row, --col, ballNo);
            }
        }
    }
}