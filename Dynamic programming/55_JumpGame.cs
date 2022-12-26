// 55. Jump Game
// Tags: dynamic programming, greedy
//

public class Solution 
{
    public bool CanJump(int[] nums) 
    {
        // Edge case.
        if(nums == null || nums.Length == 0)
            return false;

        // Optimizations.
        if(nums.Length == 1)
            return true;
        else if(nums[0] == 0)
            return false;

        int dist = 1;
        // Greedy. Count backwards to see if it is possible to reach the end
        // of the array.
        // Note we are not interested in the last index since it's value is
        // allowed to be anything.
        for(int i = nums.Length - 2; i >= 0; i--)
        {
            if(nums[i] >= dist)
                dist = 0;

            dist++;
        }

        return (dist <= nums[0]) ? true : false;
    }
}