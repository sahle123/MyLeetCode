// 1704. Determine if String Halves are Alike
// Tags: 
//

using System.Collections.Generic;

public class Solution 
{
    private static List<char> _vowels = new() {'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};

    public bool HalvesAreAlike(string s) 
    {
        // Edge case.
        if(string.IsNullOrEmpty(s))
            return false;

        char[] ca = s.ToCharArray();
        int halfLength = ca.Length/2;

        int aCount = 0;
        int bCount = 0;

        // Count all of the vowels for both halves.
        for(int i = 0; i < halfLength; i++)
        {
            if(_vowels.Contains(ca[i]))
                aCount++;
            
            if(_vowels.Contains(ca[i + halfLength]))
                bCount++;
        }
        
        return aCount == bCount ? true : false;
    }
}