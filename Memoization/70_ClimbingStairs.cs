// 70. Climbing Stairs
// Tags: memoization, dynamic programming
//

public class Solution 
{
    private int[] _cache;
    
    public int ClimbStairs(int n) 
    {
        // Edge cases.
        if(n <= 0)
            return 0;
        if(n == 1)
            return 1;
        if(n == 2)
            return 2;
        
        if(_cache == null)
            _cache = new int[n];
        
        // Uninitialized C# array indexes default to 0.
        // Therefore, it is safe to assume that uninitialized
        // indexes are 0-valued.
        if(_cache[n - 1] == 0)
            _cache[n - 1] = ClimbStairs(n - 1) + ClimbStairs(n - 2);
        
        return _cache[n - 1];
    }
}