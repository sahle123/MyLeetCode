// 2244. Minimum Rounds to Complete All Tasks
// Tags: hash map, math
//

public class Solution 
{
    public int MinimumRounds(int[] tasks) 
    {
        // Edge cases
        if(tasks == null || tasks.Length < 2)
            return -1;

        int result = 0;
        Dictionary<int, int> dict = new();

        // Build hash table
        foreach(var i in tasks)
        {
            if(!dict.ContainsKey(i))
                dict.Add(i, 1);
            else
                dict[i] += 1;
        }

        foreach(var kv in dict)
        {
            if(kv.Value < 2)
                return -1;
            else 
            {
                // Since these are integers, the fractional remainder is truncated.
                result += (kv.Value + 2)/3;
            }
        }

        return result;
    }
}