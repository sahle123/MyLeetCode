// 2256. Minimum Average Difference
// Tags: math, prefix sum
// 

public class Solution 
{
    public int MinimumAverageDifference(int[] nums) 
    {
        // Edge case.
        if(nums == null)
            return 0;
        
        long leftSum = 0;
        long rightSum = 0;
        //long rightSum = nums.Aggregate((temp, x) => temp + x);
        long curr = 0;
        
        for(int i = 0; i < nums.Length; i ++)
        {
            rightSum += nums[i];
        }

        long lowest = long.MaxValue;
        int resultIndex = -1;
        
        for(int i = 0; i < nums.Length - 1; i++)
        {
            leftSum += nums[i];
            rightSum -= nums[i];
            
            curr = Math.Abs( (long)(leftSum/(i+1)) - (long)(rightSum/(nums.Length - i - 1)) );

            if(lowest > curr) 
            {
                lowest = curr;
                resultIndex = i;
            }
        }

        // Do final index. Optimization to avoid doing if checks in the for loop.
        leftSum += nums[nums.Length - 1];
        curr = Math.Abs(leftSum/(nums.Length));
        if(lowest > curr)
            return nums.Length - 1;


        return resultIndex;
    }
}