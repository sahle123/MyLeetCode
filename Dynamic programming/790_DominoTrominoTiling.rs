// 790. Domino And Tromino Tiling
// Tags: dynamic programming, math-heavy
//
// Note: I couldn't solve this one on my own. The math was difficult. Need to review.

const MOD: i64 = 1_000_000_007;

impl Solution {
    pub fn num_tilings(n: i32) -> i32 {
        if n == 1 || n == 2 {
            return n;
        }

        let mut result: i64 = 0;
        let mut running_sum: i64 = 0;
        let mut p1: i64 = 2;
        let mut p2: i64 = 1;

        for i in 3..=n {
            result = (p1 + p2 + 2*(running_sum + 1)) % MOD;

            running_sum = (running_sum + p2) % MOD;

            p2 = p1;
            p1 = result;
        }

        return result as i32;
    }
}