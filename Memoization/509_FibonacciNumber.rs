// 509. Fibonacci Number
// Tags: memoization, dynamic programming
//

impl Solution {
    pub fn fib(n: i32) -> i32 {

        let mut cache:[i32; 30] = [0; 30];

        fn fib_seq(m: usize, cache: &mut [i32; 30]) -> i32 {
            if m == 0 {
                return 0;
            }
            if m == 1 {
                return 1;
            }
            
            if cache[m - 1] == 0 {
                cache[m - 1] = fib_seq((m - 1), cache) + fib_seq((m - 2), cache);
            }

            cache[m - 1]
        }

        fib_seq((n as usize), &mut cache)
    }
}