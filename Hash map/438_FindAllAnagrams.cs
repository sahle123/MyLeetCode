// 438. Find All Anagrams in String
// Tags: hash map, sliding window
//
// Note: This has 2 solutions.

public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        // Since we only have lowercase English letters, 
        // this assumption is safe.
        // Each index represents the frequencies a certain
        // letter appears in the s and p strings, respectively.
        int[] sf = new int[26];
        int[] pf = new int[26];

        IList<int> result = new List<int>();

        // Capture the frequency in the p string for each character.
        foreach(char c in p)
            pf[c - 'a']++;

        for(int i = 0; i < s.Length; i++)
        {
            sf[s[i] - 'a']++;

            // Remove the old sf[] entries in our sliding window.
            if(i - p.Length >= 0)
                sf[s[i - p.Length] - 'a']--;

            // If we have a match, get the right starting
            // index to add to our result.
            if((i >= p.Length - 1) && IsEqual(pf, sf))
                result.Add(i - p.Length + 1);
        }

        return result;
    }

    private bool IsEqual(int[] pf, int[] sf)
    {
        for(int i = 0; i < pf.Length; i++)
            if(pf[i] != sf[i])
                return false;
                
        return true;
    }
}

// This solution times out. Fairly slow.
public class SolutionOld
{
    public IList<int> FindAnagrams(string s, string p) 
    {
        IList<int> result = new List<int>();
        
        Dictionary<char, int> dict = new();
        Dictionary<char, int> temp;
        
        // Convert p to a hash map
        foreach(char c in p)
        {
            if(!dict.ContainsKey(c))
                dict.Add(c, 1);
            else
                dict[c] += 1;
        }
        
        for(int i = 0; i <= s.Length - p.Length; i++)
        {
            temp = new(dict);
            
            for(int j = 0; j < p.Length; j++)
            {
                if(temp.ContainsKey(s[i + j]))
                {
                    if(temp[s[i + j]] == 1)
                        temp.Remove(s[i + j]);
                        
                    else
                        temp[s[i + j]] -= 1;   
                }
                // Anagram not found.
                else
                    break;
            }
            
            if(temp.Count == 0)
                result.Add(i);
        }
        
        return result;
    }
}