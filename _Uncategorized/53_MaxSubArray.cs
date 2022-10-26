// 53. Maximum Subarray
// Tags: Unga-bunga
public class Solution 
{
    public int MaxSubArray(int[] nums) 
    {
        // Edge cases.
        if(nums == null)
            return 0;
        else if (nums.Length < 1)
            return 0;
        
        int max = int.MinValue;
        int runningSum = 0;
        
        foreach(int i in nums)
        {
            runningSum += i;
            
            if (runningSum > max)
                max = runningSum;
            if (runningSum < 0)
                runningSum = 0;
        }
        
        return max;
    }
}