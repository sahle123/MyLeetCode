// 704. Binary Search
// Tags: binary search, fundamentals
//

use std::cmp::Ordering;

impl Solution {

    // Assumes vector is already sorted (ASC).
    pub fn search(nums: Vec<i32>, target: i32) -> i32 {
        // Edge cases.
        if nums.is_empty() {
            return -1;
        }

        // Edge case for 1-length arrays.
        if nums.len() == 1usize {
            return if nums[0] == target { 0 } else { -1 }
        }
        
        let (mut low, mut high, mut mid) = (0, nums.len(), 0);

        while low < high {
            mid = low + ((high - low)/2);
            match nums[mid].cmp(&target) {
                Ordering::Equal => return mid as _,
                Ordering::Less => low = mid + 1,
                Ordering::Greater => high = mid,
            }
        }
        -1
    }
}