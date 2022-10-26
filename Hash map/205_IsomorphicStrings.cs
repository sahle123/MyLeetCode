// 205. Isomorphic strings
// Tag: Hash map, Hash set
public class Solution 
{
    public bool IsIsomorphic(string s, string t) 
    {
        // Edge cases.
        if(string.IsNullOrEmpty(s) || string.IsNullOrEmpty(s))
            return false;
        else if (s.Length != t.Length)
            return false;
        
        Dictionary<char, char> dict = new();
        // Keeps track of all values that already having a mapping to a key.
        HashSet<char> tSet = new();
        
        // We can assume at this point that the lengths of
        // s and t are equal.
        for(int i = 0; i < s.Length; i++)
        {
            // Add mapping to letters.
            if(!dict.ContainsKey(s[i]))
            {
                // Prevent double mapping.
                // If a value is already mapped to
                // a key, then we return false.
                if(tSet.Contains(t[i]))
                    return false;
                else
                {
                    dict.Add(s[i], t[i]);
                    tSet.Add(t[i]);
                }   
            }    
            
            // If mapping exists, but is mismatched, then 
            // the strings are not isomorphic to each other.
            else if(dict[s[i]] != t[i])
                return false;
        }
        
        return true;
    }
}

public class OldSolution 
{
    public bool IsIsomorphic(string s, string t) 
    {
        // Edge cases.
        if(string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
            return false;
        else if (s.Length != t.Length)
            return false;
     
        Dictionary<char, char> d = new();
        
        // Populate dictionary.
        // Make sure all keys (s[i]) map to a unique value (t[i]).
        for(int i = 0; i < s.Length; i++)
        {
            // Add new key/val. This can't change, otherwise not isomorphic.
            if(!d.ContainsKey(s[i]))
                d.Add(s[i], t[i]);

            // If a key gets remapped, we know our answer is no longer isomorphic.
            else if(d[s[i]] != t[i])
                return false;
        }
        
        // Catching any other keys that were mapped to the same value.
        foreach(char c in d.Keys)
        {
            foreach(char c2 in d.Keys)
            {
                // Skip if we already checked the character.
                if(c == c2)
                    continue;
                // Backwards check if a differnt value maps to the same key.
                else if (d[c] == d[c2])
                    return false;    
            }
        }
        
        return true;
    }
}