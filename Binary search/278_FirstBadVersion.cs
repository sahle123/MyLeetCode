// 278. First Bad Version
// Tags: binary search
//

// The IsBadVersion() API is defined in the parent class VersionControl.
// bool IsBadVersion(int version);

public class Solution : VersionControl 
{
    public int FirstBadVersion(int n) 
    {
        // Edge case.
        if(n == 1)
            return 1;
        
        int low = 0;
        int high = n;
        int mid;
        
        // Binary search till we find the first false.
        while(low < high)
        {
            mid = low + ((high - low)/2);
            
            if(base.IsBadVersion(mid))
                high = mid;
            else
                low = mid + 1;
        }
        
        return low;
    }
}