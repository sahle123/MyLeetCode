// 2279. Maximum Bags With Full Capacity of Rocks
// Tags: greedy
//
// Note: this code is ugly. Refactor and optimize it eventually.
public class Solution 
{
    public int MaximumBags(int[] capacity, int[] rocks, int additionalRocks) 
    {
        int[] diff = new int[capacity.Length];
        int filledBags = 0;

        int i = 0;
        for(; i < capacity.Length; i++)
        {
            diff[i] = capacity[i] - rocks[i];
        }
        Array.Sort(diff);

        i = 0;
        while(additionalRocks > 0 && i < capacity.Length)
        {
            if(diff[i] == 0)
            {
                filledBags++;
                i++;
                continue;
            }
            else if(additionalRocks >= diff[i])
            {
                additionalRocks -= diff[i];
                filledBags++;
                i++;
                continue;
            }
            else
            {
                break;
            }
        }

        return filledBags;
    }
}