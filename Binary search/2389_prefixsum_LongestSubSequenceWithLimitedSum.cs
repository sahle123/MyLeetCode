// 2389. Longest Subsequence With Limited Sum
// Tags: prefix sum, binary search
//
// Note: this can be rewritten better. Too much jank, not enough finesse.
public class Solution 
{
    public int[] AnswerQueries(int[] nums, int[] queries) 
    {
        int[] result = new int[queries.Length];

        // Edge cases.
        if(nums == null || queries == null)
            return new int[] { 0 };
        
        // Optimization. Special case for a single number in nums array.
        else if(nums.Length == 1)
        {
            int i = 0;
            foreach(var q in queries)
            {
                if (q >= nums[0])
                    result[i] = 1;
                else 
                    result[i] = 0;
                
                i++;
            }
            return result;
        }
        
        int numsIndex = 0;
        int low;
        int high;
        int mid;
        bool isFound = false;

        Array.Sort(nums);

        // Prefix summing nums array
        for(int i = 1; i < nums.Length; i++)
        {
            nums[i] = nums[i] + nums[i - 1];
        }

        foreach(var target in queries)
        {
            low = 0;
            mid = 0;
            high = nums.Length - 1;
            isFound = false;

            // Edge case.
            if(target < nums[0])
            {
                result[numsIndex] = 0;
                numsIndex++;
                continue;
            }

            // Binary search to find our answer
            while(low < high)
            {
                mid = low + ((high - low + 1)/2);

                if(target == nums[mid])
                {
                    result[numsIndex] = mid + 1;
                    isFound = true;
                    break;
                }
                else if(target < nums[mid])
                    high = mid - 1;
                else
                    low = mid;
            }

            // Edge case.
            if(!isFound) 
            {
                if(target > nums[mid])
                    result[numsIndex] = mid + 1;
                else 
                    result[numsIndex] = mid;
            }
            
            numsIndex++;
        }
        return result;
    }
}