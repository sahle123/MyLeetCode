// 151. Reverse Word in a String
// Tags: two pointer
//

public class Solution 
{
    private const char _space = ' ';
    
    public string ReverseWords(string s) 
    {
        // Edge case.
        if(string.IsNullOrEmpty(s))
            return null;
        
        StringBuilder sb = new();
        
        // 'j' will be a pointer for the substring starting point.
        int j = 0;
        for(int i = 0; i < s.Length; i++)
        {
            // Ignore white spaces.
            if(s[i] == _space)
                continue;
            
            // Otherwise, we found a word and need to keep track of its starting point.
            else
            {
                j = i;
                
                // find the entire word
                while(i < s.Length && s[i] != _space)
                    i++;
                
                sb.Insert(0, _space);
                sb.Insert(0, s.Substring(j, i-j));
            }
        }
        
        // Removing trailing space.
        return new string(sb.ToString(0, (sb.Length - 1)));
    }
}