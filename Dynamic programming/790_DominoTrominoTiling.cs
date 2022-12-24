// 790. Domino And Tromino Tiling
// Tags: dynamic programming, math-heavy
//
// Note: I couldn't solve this one on my own. The math was difficult. Need to review.

public class Solution 
{
    public int NumTilings(int n)
    {
        if(n == 1 || n == 2)
            return n;

        const int M = 1_000_000_007;
        long result = 0;
        long runningSum = 0;
        long p1 = 2;
        long p2 = 1;

        for(int i = 3; i <= n; i++)
        {
            result = (p1 + p2 + 2*(runningSum + 1)) % M;

            runningSum = (runningSum + p2) % M;

            p2 = p1;
            p1 = result;
        }

        return (int)result;
    }
}