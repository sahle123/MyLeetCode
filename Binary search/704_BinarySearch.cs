// 704. Binary Search
// Tags: binary search, fundamentals
//

public class Solution 
{
    // Assumes array is already sorted (ASC).
    public int Search(int[] nums, int target) 
    {
        // Edge case
        if (nums == null)
            return -1;
        
        // Edge case for 1-length arrays.
        if (nums.Length == 1)
            return nums[0] == target ? 0 : -1;
        
        // Indexes
        int low = 0;
        int high = nums.Length - 1;
        int mid;
        
        while(low < high) 
        {
            mid = low + ((high - low + 1)/2);
            
            // We found our target
            if (target == nums[mid])
                return mid;
            // Target is smaller; go lower.
            else if(target < nums[mid])
                high = mid -1;
            // Target is bigger; go higher.
            else
                low = mid;
        }
        
        // Edge case where the final low value
        // is possibly the answer.
        return nums[low] == target ? low : -1;
    }
}