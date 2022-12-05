// 1046. Last Stone Weight
// Tags: priority queue (heap)
//

public class Solution 
{
    public int LastStoneWeight(int[] stones) 
    {
        // Edge case.
        if(stones == null)
            return -1;
        
        // To flip our Min Heap to a Max Heap.
        PriorityQueue<int, int> pq = new(new IntMaxComparer());
        int tempStone = 0;

        // Populate priority queue
        foreach(var stone in stones)
        {
            pq.Enqueue(stone, stone);
        }

        // Smash stones together and enqueue stone if its size
        // is NOT 0.
        while(pq.Count > 1)
        {
            tempStone = Math.Abs(pq.Dequeue() - pq.Dequeue());
            
            if(tempStone > 0)
                pq.Enqueue(tempStone, tempStone);
        }

        // Return the last stone or 0 if the PQ is empty.
        if (pq.Count == 0)
            return 0;
        else
            return pq.Peek();
    }

    public class IntMaxComparer : IComparer<int> 
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }
}