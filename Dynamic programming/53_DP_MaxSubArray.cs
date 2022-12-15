// 53. Maximum Subarray
// Tags: dynamic programming
//
public class Solution 
{
    public int MaxSubArray(int[] nums) 
    {
        int n = nums.Length;
        int[] sub = new int[n];
        sub[0] = nums[0];
        int max = nums[0];
        
        for(int i = 1; i < n; i++)
        {
            if(sub[i - 1] > 0)
                sub[i] = nums[i] + sub[i - 1];
            else
                sub[i] = nums[i];
            max = Math.Max(max, sub[i]);
        }
        
        return max;
    }
}