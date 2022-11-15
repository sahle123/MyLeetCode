// 26. Remove Duplicates from Sorted Array.
// Tags: two pointer
//

public class Solution 
{
    public int RemoveDuplicates(int[] nums) 
    {
        // Edge cases.
        if(nums == null)
            return 0;
        if(nums.Length == 0)
            return 0;
        
        int i = 0;
        
        for(int j = 0; j < nums.Length; j++)
        {
            nums[i] = nums[j];
            i++;
            
            // Find the next, new value.
            // We check the nums length first so we can
            // short-circuit and not check the next value
            // if the former is false.
            while(j < nums.Length - 1 && nums[j] == nums[j + 1])
                j++;
        }
        
        return i;
    }    
}