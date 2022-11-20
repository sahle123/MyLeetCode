// 121 Best Time to Buy and Sell Stock.
// Tags: dynamic programming
//
impl Solution {
    pub fn max_profit(prices: Vec<i32>) -> i32 {
        let mut buy_number: i32 = i32::MAX;
        let mut profit: i32 = 0;

        for n in prices {
            profit = profit.max(n - buy_number);
            buy_number = buy_number.min(n);
        }

        return profit;
    }
}