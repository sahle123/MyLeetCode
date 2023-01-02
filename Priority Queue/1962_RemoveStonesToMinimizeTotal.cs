// 1962. Remove Stones to Minimize the Total
// Tags: priority queue (heap)
//

public class Solution 
{
    public int MinStoneSum(int[] piles, int k) 
    {
        // Edge cases.
        if(k < 1)
            return -1;
        else if (piles == null || piles.Length == 0)
            return -1;

        PriorityQueue<int, int> pq = new(new IntMaxComparer());
        int result = 0;

        // Populate priority queue
        foreach(var i in piles)
        {
            pq.Enqueue(i, i);
        }

        // Perform operation on largest value and decrement k.
        double temp;
        int temp2;
        while(k > 0)
        {
            temp = pq.Dequeue();
            temp2 = (int)Math.Ceiling(temp / 2);
            pq.Enqueue(temp2, temp2);

            k--;
        }

        // Sum up queue
        while(pq.Count > 0)
            result += pq.Dequeue();

       return result;
    }

    public class IntMaxComparer : IComparer<int>
    {
        public int Compare(int x, int y) => y.CompareTo(x);
    }
}