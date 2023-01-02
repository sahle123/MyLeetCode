// 290. Word Problem
// Tags: hash table, bijection
//

public class Solution 
{
    public bool WordPattern(string pattern, string s) 
    {
        // Edge case.
        if (string.IsNullOrEmpty(pattern) || string.IsNullOrEmpty(s))
            return false;

        Dictionary<char, string> dict = new();
        // To ensure 1-to-1 correspondence.
        Dictionary<string, char> bijection = new();

        string[] words = s.Split(' ');

        // Edge case.
        if(words.Length != pattern.Length)
            return false;

        for(int i = 0; i < words.Length; i++)
        {
            if(!dict.ContainsKey(pattern[i])) 
            {
                if(!bijection.ContainsKey(words[i]))
                {
                    dict.Add(pattern[i], words[i]);
                    bijection.Add(words[i], pattern[i]);
                }
                else
                    return false;
            }
                
            else if(dict[pattern[i]] != words[i] || bijection[words[i]] != pattern[i])
                return false;
        }
        return true;
    }
}