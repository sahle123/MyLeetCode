// 35. Search Insert Position
// Tags: binary search
public class Solution 
{
    public int SearchInsert(int[] nums, int target) 
    {
        // Edge cases.
        if(nums == null)
            return 0;
        if(nums.Length == 1)
        {
            if(target > nums[0])
                return 1;
            else
                return 0;
        }
        
        int n = nums.Length;
        
        int lb = 0; // Lower bound
        int ub = n - 1; // Upper bound
        int mid = 0;
        
        while(lb < ub)
        {
            mid = CalculateMid(lb, ub);
            
            if(target == nums[mid])
                return mid;
            
            else if (target < nums[mid])
                ub = mid - 1;
            
            else // mid > target
                lb = mid;
        }
        
        mid = CalculateMid(lb, ub);
        
        // Number does not exist in nums[].
        if(target > nums[mid])
            return mid + 1;
        else
            return mid;
    }
    
    public static int CalculateMid(int lb, int ub)
    {
        // No need for Math.Floor() since integers are automatically truncated.
        return (lb + ((ub - lb + 1)/2));
    }
}