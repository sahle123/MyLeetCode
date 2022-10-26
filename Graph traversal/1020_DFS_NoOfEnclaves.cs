// 1020. Number of Enclaves
// Tag: DFS, non-static solution

public class Solution 
{
    private int _counter { get; set; }
    
    public int NumEnclaves(int[][] grid) 
    {
        int inaccessibleLand = 0;
        
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                // 1 == land
                if(grid[i][j] == 1)
                {
                    _counter = 0;
                   if (_IsEdgeAccessible(ref grid, i, j))
                       inaccessibleLand += _counter;
                }
            }
        }
        return inaccessibleLand;
    }
    
    private bool _IsEdgeAccessible(ref int[][] grid, int i, int j)
    {        
        if(i < 0 || j < 0 || i >= grid.Length || j >= grid[i].Length)
            return false;
        
        if(grid[i][j] != 1)
            return true;
        
        // Land has been searched, changint it to -1.
        grid[i][j] = -1;
        _counter++;
        
        //System.Console.WriteLine($"{grid[i][j]}");
        
        return _IsEdgeAccessible(ref grid, i + 1, j)
            & _IsEdgeAccessible(ref grid, i - 1, j)
            & _IsEdgeAccessible(ref grid, i, j + 1)
            & _IsEdgeAccessible(ref grid, i, j - 1);
    }
    
    // Not in use
    public class Tracker
    {
        public int Count { get; set; }
        public bool IsValid { get; set; } // Valid only if we aren't hitting the edges.
        
        public Tracker(int count, bool isValid)
        {
            Count = count;
            IsValid = isValid;
        }
        
        // Overloading & operator
        public static Tracker operator &(Tracker a, Tracker b)
        {
            return new Tracker(a.Count + b.Count, a.IsValid & b.IsValid);
        }
    }
}