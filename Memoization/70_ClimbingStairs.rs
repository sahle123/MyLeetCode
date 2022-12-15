// 70. Climbing Stairs
// Tags: memoization, dynamic programming
//

impl Solution {
    pub fn climb_stairs(n: i32) -> i32 {

        let mut cache:[i32; 45] = [0; 45];

        fn count_stairs(n: usize, cache: &mut [i32; 45]) -> i32 {
            // Edge cases.
            if n <= 0 {
                return 0;
            }
            else if n == 1 {
                return 1;
            }
            else if n == 2 {
                return 2;
            }

            if cache[n - 1] == 0 {
                cache[n - 1] = count_stairs((n - 1), cache) + count_stairs((n - 2), cache);
            }

            cache[n - 1]
        }
        
        count_stairs((n as usize), &mut cache)
    }
}