// 350. Intersection of two arrays II
// Tags: hash map, two pointer
//
// Space: O(n)
// Time: O(n^2)
//
// Notes: this code needs refinement.
public class Solution 
{
    public int[] Intersect(int[] nums1, int[] nums2) 
    {
        Dictionary<int, int> dict = new(); // <value, count>
        int size = 0;
        const int searchedVal = int.MinValue;
        
        
        // Search over nums1 and nums2 arrays and any
        // intersecting values will be added or incremented
        // inside of dict.
        for(int i = 0; i < nums1.Length; i++)
        {
            for(int j = 0; j < nums2.Length; j++)
            {
                // Add to dictionary and set index in nums2 to searchedVal.
                if(nums1[i] == nums2[j])
                {
                    if(!dict.ContainsKey(nums1[i]))
                        dict.Add(nums1[i], 1);
                    else
                        dict[nums1[i]] += 1;
                    nums2[j] = searchedVal;
                    size++;
                    break;
                }
            }
        }
        
        int[] result = new int[size];
        
        // Populate result array with our dictionary.
        // Keys above the value 1 will be added as many times
        // as their value in the dictionary.
        int k = 0;
        foreach(var kv in dict)
        {
            for(int p = 0; p < kv.Value; p++)
            {
                result[k] = kv.Key;
                k++;
            }
        }
        
        return result;
    }
}