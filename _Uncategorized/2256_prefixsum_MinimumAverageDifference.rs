// 2256. Minimum Average Difference
// Tags: math, prefix sum
// 

impl Solution {
    pub fn minimum_average_difference(nums: Vec<i32>) -> i32 {
        
        // Edge case
        if nums.is_empty() {
            return 0;
        }

        let mut left_sum: i64 = 0;
        let mut right_sum: i64 = 0;
        let mut curr: i64 = 0;
        let mut lowest: i64 = i64::MAX;
        let mut result_index: usize = 0;

        // Get the right sum
        for i in nums.iter() {
            right_sum += ((*i) as i64);
        }

        let n = nums.len() as i64;
        
        for i in 0..(nums.len() - 1) {
            let j: i64 = i as i64;
            
            left_sum += ((nums[i]) as i64);
            right_sum -= ((nums[i]) as i64);

            curr = ( (left_sum/(j + 1)) - (right_sum/(n - j - 1)) ).abs();

            if lowest > curr {
                lowest = curr;
                result_index = i;
            }
        }
        
        // Do final index. Optimization to avoid doing if checks in the for loop.
        left_sum += (nums[nums.len() - 1] as i64);
        curr = (left_sum/ n).abs();
        if lowest > curr {
            return (n - 1) as i32;
        }

        result_index as i32
    }
}