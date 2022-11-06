// 79. Word Search
// Tags: DFS, backtracking, brute-force, hash set
//
// Note: This contains 2 solutions.

// This one does not use a hash set. Let's us save on some CPU.
public class Solution
{
    private static string _word { get; set; }

    // NOTE: Assuming that the jagged array is uniform
    // across all members. Honestly... why aren't 2D
    // arrays used instead!?
    public bool Exist(char[][] board, string word) 
    {
        // Edge cases.
        if(string.IsNullOrEmpty(word))
            return false;
        if(board == null)
            return false;
        if(board[0] == null)
            return false;

        _word = word;

        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board[i].Length; j++)
            {
                // Do DFS if we find the first letter of the word.
                if(board[i][j] == _word[0])
                {
                    // See if we found a path. If so, we are done; we found the word.
                    if(_4WayWordSearch(ref board, i, j, 0))
                        return true;
                }
            }
        }
        return false;
    }

    // k will represent the current index in the word that we are searching
    // for. It uses the class prop _word. i.e. _word[k];
    private static bool _4WayWordSearch(ref char[][] board, int i, int j, int k)
    {
        // No need to search anymore since we found our answer.
        if(k == _word.Length)
            return true;
        
        // Edge cases.
        if(i < 0 || j < 0 || i >= board.Length || j >= board[i].Length)
            return false;

        // We found one of the leters that we need.
        if(board[i][j] == _word[k])
        {   
            k++;
            
            // Save the char in a temp and set it to empty so we don't search over it again.
            char temp = board[i][j];
            board[i][j] = ' ';
            bool result =  _4WayWordSearch(ref board, i + 1, j, k)
                | _4WayWordSearch(ref board, i - 1, j, k)
                | _4WayWordSearch(ref board, i, j + 1, k)
                | _4WayWordSearch(ref board, i, j - 1, k);
            
            // Return the node's value back to its original.
            board[i][j] = temp;
            return result;
        }
        return false;
    }
}

// This one uses a hash set.
public class SolutionOld
{
    private static string _word { get; set; }

    // NOTE: Assuming that the jagged array is uniform
    // across all members. Honestly... why aren't 2D
    // arrays used instead!?
    public bool Exist(char[][] board, string word) 
    {
        // Edge cases.
        if(string.IsNullOrEmpty(word))
            return false;
        if(board == null)
            return false;
        if(board[0] == null)
            return false;

        _word = word;

        // The hash set will keep track of nodes we have already searched.
        // This will prevent looping and double counting.
        HashSet<(int x, int y)> path = new();

        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board[i].Length; j++)
            {
                // Do DFS if we find the first letter of the word.
                if(board[i][j] == _word[0])
                {
                    System.Console.WriteLine("Starting search...");
                    // See if we found a path. If so, we are done; we found the word.
                    if(_4WayWordSearch(ref board, ref path, i, j, 0))
                        return true;

                    // Reset the hash set. NOTE: This step may not be needed...
                    else
                        path.Clear();
                }
            }
        }
        return false;
    }

    // k will represent the current index in the word that we are searching
    // for. It uses the class prop _word. i.e. _word[k];
    private static bool _4WayWordSearch(ref char[][] board, ref HashSet<(int x, int y)> path, int i, int j, int k)
    {
        // No need to search anymore since we found our answer.
        if(k == _word.Length)
            return true;
        
        // Edge cases.
        if(i < 0 || j < 0 || i >= board.Length || j >= board[i].Length)
            return false;

        // Check if we have already traversed here or not
        if(path.Contains((i, j)))
        {
            System.Console.WriteLine($"This has already been checked... ({i}, {j})");
            return false;
        }
            

        // We found one of the leters that we need.
        if(board[i][j] == _word[k])
        {
            System.Console.WriteLine($"{board[i][j]}, ({i}, {j}), k: {k}");
            
            k++;
            path.Add((i, j));
            bool result =  _4WayWordSearch(ref board, ref path, i + 1, j, k)
                | _4WayWordSearch(ref board, ref path, i - 1, j, k)
                | _4WayWordSearch(ref board, ref path, i, j + 1, k)
                | _4WayWordSearch(ref board, ref path, i, j - 1, k);
            
            path.Remove((i, j));
            return result;
        }
        
        return false;
    }
}

/*
Sample inputs:

[["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]]
"ABCCED"
[["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]]
"SEE"
[["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]]
"ABCB"
[["C","A","A"],["A","A","A"],["B","C","D"]]
"AAB"

*/