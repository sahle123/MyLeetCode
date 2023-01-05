// 944. Delete Columns to Make Sorted
// Tags: string, array
//
// Constraint: strs only consists of lowercase English letters.

public class Solution 
{
    // Since we are only using lowercase English characters, we can
    // use '`' as our min value since that is the first value before 'a'.
    private const char _MinAscii = '`';

    // Every string element is of equal length.
    public int MinDeletionSize(string[] strs) 
    {
        int deletionSize = 0;

        // Edge case
        if(strs == null || strs.Length == 0)
            return deletionSize;

        char prevChar;
        for(int j = 0; j < strs[0].Length; j++)
        {
            prevChar = _MinAscii; // ASCII = 96. Using this is our initial value.
            for(int i = 0; i < strs.Length; i++)
            {
                if((prevChar - _MinAscii) > (strs[i][j] - _MinAscii))
                {
                    deletionSize++;
                    break;
                }
                prevChar = strs[i][j];
            }
        }
        
        return deletionSize;
    }
}