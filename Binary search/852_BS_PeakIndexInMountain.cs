// 852. Peak Index in a Mountain Array
// Tags: binary search
public class Solution 
{
    public int PeakIndexInMountainArray(int[] M) 
    {
        int peakIndex = 0;
        
        int lb = 0;
        int ub = M.Length - 1;
        int mid;
        
        while(lb < ub)
        {
            mid = lb + ((ub - lb + 1)/2);
            
            //System.Console.WriteLine(peakIndex + ", " + lb + ", " + ub + ", " + mid);
            
            // If this mid point is bigger, that's our new peak.
            if(M[mid] > M[peakIndex])
                peakIndex = mid;
            
            // Check which neighbor is larger and traverse 
            // in towards the higher one.
            if(M[mid] < M[mid + 1])
                lb = mid;
            else // M[mid] < M[mid - 1]
                ub = mid -1;
        }
        return peakIndex;
    }
}