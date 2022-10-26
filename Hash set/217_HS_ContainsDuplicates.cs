// 217. Contains Duplicates
// Tags: hash set
public class Solution 
{
    public bool ContainsDuplicate(int[] nums) 
    {
        // HashSets are good for hash-based arrays that only contain unique values.
        // Same as a math set.
        // Note that HashSets do not store any values, only the key.
        HashSet<int> s = new();
        
        foreach(int i in nums)
        {
            if(s.Contains(i))
                return true;
            else
                s.Add(i);
        }
        
        return false;
    }
}