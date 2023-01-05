// 55. Jump Game
// Tags: dynamic programming, greedy
//

impl Solution {
    pub fn can_jump(nums: Vec<i32>) -> bool {

        // Edge case.
        if nums.is_empty() || nums.len() == 0 {
            return false;
        }

        // Optimizations.
        if nums.len() == 1 {
            return true;
        }
        else if nums[0] == 0 {
            return false;
        }

        let mut dist: i32 = 1;
        let mut i: usize = nums.len() - 1;

        while i > 0 {
            i -= 1;

            if nums[i] >= dist {
                dist = 0;
            }
            dist += 1;
        }

        if dist <= nums[0] { 
            return true;
        }
        false
    }
}