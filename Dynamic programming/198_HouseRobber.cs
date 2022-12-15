// 198. House Robber
// Tags: dynamic programming
//
// Time: O(n)
// Space: O(n)
public class Solution 
{
    public int Rob(int[] nums) 
    {
        // Edge cases.
        if(nums == null)
            return 0;
        else if(nums.Length == 1)
            return nums[0];
        else if(nums.Length == 2)
            return Math.Max(nums[0], nums[1]);
        else if(nums.Length == 3)
            return Math.Max((nums[0] + nums[2]), nums[1]);

        int length = nums.Length;

        int[] dp = new int[length];

        // Optimization.
        dp[0] = nums[0];
        dp[1] = nums[1];
        dp[2] = nums[0] + nums[2];

        for(int i = 3; i < length; i++)
        {
            dp[i] = nums[i] + Math.Max(dp[i - 2], dp[i - 3]);
        }

        return Math.Max(dp[length - 1], dp[length - 2]);
    }
}