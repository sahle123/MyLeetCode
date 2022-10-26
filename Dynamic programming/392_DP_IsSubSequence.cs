// 392. Is Subsequence
// Tags: dynamic programming
public class Solution 
{
    public bool IsSubsequence(string s, string t) 
    {
        // Edge cases.
        if (s.Length > t.Length)
            return false;
        
        // An empty string can be a substring.
        else if (string.IsNullOrEmpty(s))
            return true;
        
        else if (string.IsNullOrEmpty(t))
            return false;
        
        
        int counter = 0;
        int j = 0;
        for(int i = 0; i < s.Length; i++)
        {
            for(; j < t.Length; j++)
            {
                if(t[j] == s[i])
                {
                    counter++;
                    j++;
                    break;
                }
            }
        }
        
        return counter == s.Length ? true : false;
    }
}