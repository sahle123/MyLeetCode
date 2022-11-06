// 509. Fibonacci Number
// Tags: memoization, dynamic programming
//
// Note: This has 2 solutions.

// Regular solution
public class Solution 
{   
    public int Fib(int n) 
    {
        if(n == 0)
            return 0;
        if(n == 1)
            return 1;
        
        return Fib(n - 1) + Fib(n - 2);
    }
}

// Memoized solution
public class Solution 
{
    private int[] _cache;
    
    public int Fib(int n) 
    {
        if(n == 0)
            return 0;
        if(n == 1)
            return 1;
        if(_cache == null)
            _cache = new int[n];
        
        // Since C# arrays initialize to 0, it is safe
        // to assume that an array value of 0 is
        // uninitialized.
        if(_cache[n - 1] == 0)
            _cache[n - 1] = Fib(n - 1) + Fib(n - 2);
            
        return _cache[n - 1];
    }
}