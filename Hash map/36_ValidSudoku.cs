// 36. Valid Sudoku
// Tags: Puzzle, Hash map, Brute-force
//
// Note: We should use a hash set instead of a hash map.
//
// Space: O(1). We never use more than 9 values in the hash map.
// Time: O(n). More specifically, 2187 iterations. --> 9x9x9x3. 

// Brute-force method
public class Solution 
{
    private const char _EmptySpace = '.';

    // Assuming jagged array is uniform.
    public bool IsValidSudoku(char[][] board) 
    {
        // Edge cases.
        if(board == null)
            return false;
        else if(board.Length != 9)
            return false;
        else if(board[0].Length != 9)
            return false;
        
        // Keeps track of row, col, quadrant number count.
        // If any value exceeds 1, then we return false.
        Dictionary<char, int> dict = new();
        bool IsValid = true;
        
        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board[i].Length; j++)
            {
                if(i % 3 == 0)
                    if(j % 3 == 0)
                        IsValid = IsValid && IsValidQuadPass(ref board, ref dict, i, j);
                
                IsValid = IsValid && IsValidRowPass(ref board, ref dict, i);
                IsValid = IsValid && IsValidColPass(ref board, ref dict, j);
                
                if(!IsValid)
                    return false;
            }
        }
        return true;
    }
    
    // Returns whether or not the row is valid.
    public static bool IsValidRowPass(ref char[][] board, ref Dictionary<char, int> dict, int index)
    {
        char ch; // For readability.
        
        for(int j = 0; j < board[index].Length; j++)
        {
            ch = board[index][j];
            
            if(ch == _EmptySpace)
                continue;
            
            else if(!dict.ContainsKey(ch))
                dict.Add(ch, 1);
            
            else
                return false;
        }
        
        dict.Clear();
        return true;
    }
    
    // Returns whether or not the column is valid.
    public static bool IsValidColPass(ref char[][] board, ref Dictionary<char, int> dict, int index)
    {
        char ch; // For readability.
        
        for(int i = 0; i < board.Length; i++)
        {
            ch = board[i][index];
            
            if(ch == _EmptySpace)
                continue;
            
            else if(!dict.ContainsKey(ch))
                dict.Add(ch, 1);
            
            else
                return false;
        }
        
        dict.Clear();
        return true;
    }
    
    // Returns whether or not the quadrant is valid.
    public static bool IsValidQuadPass(ref char[][] board, ref Dictionary<char, int> dict, int row, int col)
    {
        char ch; // For readability.
        int rowLength = row + 3;
        int colLength = col + 3;
        
        for(int i = row; i < rowLength; i++)
        {
            for(int j = col; j < colLength; j++)
            {
                ch = board[i][j];
                
                if(ch == _EmptySpace)
                    continue;
                
                else if(!dict.ContainsKey(ch))
                    dict.Add(ch, 1);
                
                else
                    return false;
            }
        }
        dict.Clear();
        return true;
    }
}


// Broken solution, don't use...
public class BrokenSolution 
{
    private const char _EmptySpace = '.';

    // Assuming jagged array is uniform.
    public bool IsValidSudoku(char[][] board) 
    {
        // Edge cases.
        if(board == null)
            return false;
        else if(board.Length != 9)
            return false;
        else if(board[0].Length != 9)
            return false;
        
        // Keeps track of row, col, quadrant number count.
        // If any value exceeds 1, then we return false.
        Dictionary<char, int> dict = new();
        bool IsValid = true;
        
        for(int i = 0; i < board.Length; i++)
        {
            if(i % 3 == 0)
                IsValid = IsValid && IsValidQuadPass(ref board, ref dict, i);
            IsValid = IsValid && IsValidRowPass(ref board, ref dict, i);
            IsValid = IsValid && IsValidColPass(ref board, ref dict, i);
            
            if(!IsValid)
                return false;
        }

        // Go in reverse to catch edge cases.
        // Since quadrants are already verified, we can skip that step.
        for(int i = (board.Length - 1); i >= 0; i--)
        {
            IsValid = IsValid && IsValidRowPass(ref board, ref dict, i);
            IsValid = IsValid && IsValidColPass(ref board, ref dict, i);
            
            if(!IsValid)
                return false;
        }

        return true;
    }
    
    // Returns whether or not the row is valid.
    public static bool IsValidRowPass(ref char[][] board, ref Dictionary<char, int> dict, int index)
    {
        char ch; // For readability.
        
        for(int j = index; j < board[index].Length; j++)
        {
            ch = board[index][j];
            
            if(ch == _EmptySpace)
                continue;
            
            else if(!dict.ContainsKey(ch))
                dict.Add(ch, 1);
            
            else
                return false;
        }
        
        dict.Clear();
        return true;
    }
    
    // Returns whether or not the column is valid.
    public static bool IsValidColPass(ref char[][] board, ref Dictionary<char, int> dict, int index)
    {
        char ch; // For readability.
        
        for(int i = index; i < board.Length; i++)
        {
            ch = board[i][index];
            
            if(ch == _EmptySpace)
                continue;
            
            else if(!dict.ContainsKey(ch))
                dict.Add(ch, 1);
            
            else
                return false;
        }
        
        dict.Clear();
        return true;
    }
    
    // Returns whether or not the quadrant is valid.
    public static bool IsValidQuadPass(ref char[][] board, ref Dictionary<char, int> dict, int index)
    {
        char ch; // For readability.
        int length = index + 3;
        
        for(int i = index; i < length; i++)
        {
            for(int j = index; j < length; j++)
            {
                ch = board[i][j];
                
                if(ch == _EmptySpace)
                    continue;
                
                else if(!dict.ContainsKey(ch))
                    dict.Add(ch, 1);
                
                else
                    return false;
            }
        }
        dict.Clear();
        return true;
    }
}