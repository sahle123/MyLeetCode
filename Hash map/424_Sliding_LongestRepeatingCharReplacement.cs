// 424. Longest Repeating Character Replacement
// Tags: sliding window, hash map
//

public class Solution 
{
    public int CharacterReplacement(string s, int k) 
    {
        int result = 0;
        Dictionary<char, int> dict = new();

        int maxOccurringElement = 0;
        int lowerBound = 0;

        for(int i = 0; i < s.Length; i++)
        {
            if(!dict.ContainsKey(s[i]))
                dict.Add(s[i], 1);
            else
                dict[s[i]]++;

            // Get the maxmimum occuring char in string s.
            maxOccurringElement = Math.Max(maxOccurringElement, dict[s[i]]);

            // (i - lowerBound + 1) is our sliding window.
            // If the max recurring element in our window is greater than 
            // k, then it is invalid. We need to move the window
            // up one space.
            // 
            if(i - lowerBound + 1 - maxOccurringElement > k)
            {
                dict[s[lowerBound]]--;
                lowerBound++;
            }
            // Otherwise, we check if this window is greater than
            // our current best result.
            else
                result = Math.Max(result, (i - lowerBound + 1));
        }

        return result;
    }
}