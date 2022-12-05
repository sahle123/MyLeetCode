// 215. Kth Largest Element in an Array
// Tags: priority queue (heap)
//

public class Solution 
{
    public int FindKthLargest(int[] nums, int k) 
    {
        // Edge cases.
        if(k < 1)
            return -1;
        else if (nums == null || nums.Length == 0)
            return -1;
        
        PriorityQueue<int, int> pq = new();
        
        foreach(int i in nums)
        {
            pq.Enqueue(i, i);
            
            // Keep the PQ no larger than K.
            // Since this PQ by default is a Min Heap,
            // we can ensure that the smallest values
            // will be popped off first, always.
            if(pq.Count > k)
                pq.Dequeue();
        }
        
        return pq.Peek();
    }
}