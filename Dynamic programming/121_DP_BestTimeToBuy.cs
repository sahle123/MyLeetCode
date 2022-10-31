// 121. Best Time to Buy and Sell Stock.
// Tags: dynamic programming
//
public class Solution 
{
    public int MaxProfit(int[] prices) 
    {
        int buyNumber = int.MaxValue;
        int max = 0;
        
        for(int i = 0; i < prices.Length; i++)
        {
            buyNumber = Math.Min(prices[i], buyNumber);
            max = Math.Max(prices[i] - buyNumber, max);
        }
        
        return max;
    }
}