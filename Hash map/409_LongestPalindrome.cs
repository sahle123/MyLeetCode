// 409. Longest Palindrome
// Tags: hash map
//
public class Solution 
{
    public int LongestPalindrome(string s) 
    {
        // Edge cases + optimiztion.
        if(string.IsNullOrEmpty(s))
            return 0;
        else if(s.Length == 1)
            return 1;
        
        int result = 0;
        Dictionary<char, int> dict = new();
        
        // Store all values in hash map.
        foreach(char c in s)
        {
            if(!dict.ContainsKey(c))
                dict.Add(c, 1);
            else
                dict[c] += 1;
        }
        
        // Count all the even lengthed and odd lengthed 
        // (greater than or equal to 3) entries.
        bool oddEncountered = false;
        foreach(KeyValuePair<char, int> i in dict)
        {
            // Even numbers.
            if(i.Value % 2 == 0)
            {
                result += i.Value;
            }
            // Odd numbers.
            else
            {
                oddEncountered = true;
                result += i.Value - 1;
            }
        }
        
        // If we had any odd number entries, add 1 to the middle
        // of our palindrome.
        if(oddEncountered)
            result++;
        
        return result;
    }
}