// 1. Two Sum
// Tags: fundamentals, hash maps
// Time complexity: O(n)
// Space complexity: O(n)
public class Solution 
{
    public int[] TwoSum(int[] nums, int target) 
    {
        // Edge cases.
        if(nums == null)
            return new int[2];
        else if (nums.Length < 2)
            return new int[2];
        
        // <value, index>
        Dictionary<int, int> d = new();
        int subTarget;
        
        for(int i = 0; i < nums.Length; i++)
        {
            subTarget = target - nums[i];
            
            if(!d.ContainsKey(nums[i]))
                d.Add(nums[i], i);
            
            if(d.ContainsKey(subTarget))
                // Prevent from counting the same index twice.
                if(d[subTarget] != i)
                    return new int[] { d[subTarget], i };
        }
        
        return new int[] {-1, -1};
    }
}

// Time complexity: O(n^2)
// Space complexity: O(1)
public class OldSolution 
{
    public int[] TwoSum(int[] nums, int target) 
    {
        int[] twoSum = new int[2];
        
        // Edge cases.
        if(nums == null)
            return twoSum;
        else if (nums.Length < 2)
            return twoSum;
        
        for(int i = 0; i < nums.Length; i++)
        {
            for(int j = i + 1; j < nums.Length; j++)
            {
                if(nums[i] + nums[j] == target)
                {
                    twoSum[0] = i;
                    twoSum[1] = j;
                }
            }
        }
        
        return twoSum;
    }
}