// 2131. Longest Palindrome by Concatenating Two Letters Words
// Tags: Hash map
//
public class Solution 
{
    public int LongestPalindrome(string[] words) 
    {
        if(words == null)
            return 0;
        
        int result = 0;
        Dictionary<string, int> dict = new();
        
        // Store words into our hash map.
        foreach(string s in words)
        {
            if(!dict.ContainsKey(s))
                dict.Add(s, 1);
            else
                dict[s] += 1;
        }
        
        foreach(var kv in dict)
        {
            char[] charArr = kv.Key.ToCharArray();
            
            // Case 1: same character string. e.g. aa
            if(charArr[0] == charArr[1])
            {
                if(kv.Value % 2 == 0)
                {
                    result += (kv.Value * 2);
                    dict[kv.Key] = 0;
                }
                else
                {
                    result += (kv.Value * 2) - 2;
                    dict[kv.Key] = 1;
                }
            }
            
            // Case 2: different character string. e.g. ab
            else if (kv.Value > 0)
            {
                // See if we have the reverse of the key.
                string rev = ReverseString(kv.Key);
                
                if(dict.ContainsKey(rev))
                {
                    if(dict[rev] > kv.Value)
                    {
                        result += kv.Value * 4;
                        dict[rev] -= kv.Value;
                        dict[kv.Key] = 0;
                    }
                    else
                    {
                        result += dict[rev] * 4;
                        dict[kv.Key] -= dict[rev];
                        dict[rev] = 0;
                    }
                }
            }
        }
        
        // Last check for any double character strings we can add as
        // our final (middle) substring in the palindrome.
        foreach(var kv in dict)
        {
            char[] charArr = kv.Key.ToCharArray();
            
            // Case 1: same character string. e.g. aa
            if(charArr[0] == charArr[1])
            {
                if(kv.Value > 0)
                {
                    result += 2;
                    return result;
                }
            }
        }
        
        return result;
    }
    
    public static string ReverseString(string s)
    {
        char[] charArr = s.ToCharArray();
        Array.Reverse(charArr);
        return new string(charArr);
    }
}