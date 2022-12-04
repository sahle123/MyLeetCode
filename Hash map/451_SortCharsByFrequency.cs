// 451. Sort Characters By Frequency
// Tags: hash map
//
public class Solution 
{
    public string FrequencySort(string s) 
    {
        // Edge case
        if(string.IsNullOrEmpty(s))
            return null;
        
        Dictionary<char, int> dict = new();
        StringBuilder sb = new();
        
        // Get all character counts
        foreach(char c in s)
        {
            if(!dict.ContainsKey(c))
                dict.Add(c, 1);
            
            else
                dict[c] += 1;
        }
        
        foreach(var kv in dict.OrderByDescending(e => e.Value))
        {
            
            //Console.WriteLine($"{kv.Key.ToString()}, {kv.Value.ToString()}");
            for(int i = 0; i < kv.Value; i++)
                sb.Append(kv.Key);
        }
        
        return sb.ToString();
    }
}