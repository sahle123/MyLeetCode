// 746. Min Cost Climbing Stairs
// Tags: dynamic programming, greedy
//
public class Solution 
{
    public int MinCostClimbingStairs(int[] cost) 
    {
        // Edge cases.
        if(cost == null)
            return 0;
        if(cost.Length == 1)
            return 0;
        if(cost.Length == 2)
            return Math.Min(cost[0], cost[1]);
        
        int length = cost.Length;

        int[] dp = new int[length];

        // Optimizations. Add the first 2 indexes in our
        // dynamic programming array.
        dp[0] = cost[0];
        dp[1] = cost[1];

        for(int i = 2; i < length; i++)
            dp[i] = cost[i] + Math.Min(dp[i - 1], dp[i - 2]);

        return Math.Min(dp[length - 1], dp[length - 2]);
    }
}