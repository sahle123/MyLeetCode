// 88. Merge Sorted Array
// Tags: two pointer
//
// Note: Contains 2 solutions.
//
// Space: O(m + n)
// Time: O(2(m + n))
public class Solution 
{
    public void Merge(int[] nums1, int m, int[] nums2, int n) 
    {
        // Edge case.
        if(m < 0 || n < 0 || nums1.Length < 0 || nums2.Length < 0)
            return;
        
        int arrSize = m + n;
        int[] temp = new int[arrSize];
        
        // Populate + order temp array
        int j = 0; // nums1 index
        int k = 0; // nums2 index
        int i = 0; // temp index
        while(j < m && k < n)
        {
            if(nums1[j] > nums2[k])
            {
                temp[i] = nums2[k];
                k++;
            }
            else 
            {
                temp[i] = nums1[j];
                j++;
            }
            i++;
        }
        
        // If one array was bigger than the other, add up the remaining elements.
        // For nums1
        if (j < m)
        {
            for(; i < arrSize; i++)
            {
                temp[i] = nums1[j];
                j++;
            }
        }
        // For nums2
        else if (k < n)
        {
            for(; i < arrSize; i++)
            {
                temp[i] = nums2[k];
                k++;
            }
        }
        
        // Overwrite nums1 w/ temp array.
        for(int p = 0; p < nums1.Length; p++)
            nums1[p] = temp[p];
        
        return;
    }
}

public class OldSolution 
{
    public void Merge(int[] nums1, int m, int[] nums2, int n) 
    {        
        int totalLen = nums1.Length;
        int[] temp = new int[totalLen];
        
        int offset = 0;
        int i = 0;
        int j = 0;
        int steps = 0;
        while(steps < totalLen)
        {
            // We added all of nums1, so adding nums2.
            if(i >= m && j < n)
            {
                temp[offset] = nums2[j];
                j++;
                offset++;
            }
            // We added all of nums2, so adding nums1.
            else if (j >= n && i < m)
            {
                temp[offset] = nums1[i];
                i++;
                offset++;
            }
            else if(nums1[i] <= nums2[j])
            {
                temp[offset] = nums1[i];
                i++;
                offset++;
            }
            else // nums1[i] > nums2[j]
            {
                temp[offset] = nums2[j];
                j++;
                offset++;
            }
            steps++;
        }
        
        // Reassign nums1 to temp array values.
        i = 0;
        for(; i < totalLen; i++)
        {
            nums1[i] = temp[i];   
        }
    }
}