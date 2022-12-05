// 215. Kth Largest Element in an Array
// Tags: priority queue (heap)
//

use std::collections::BinaryHeap;

impl Solution {
    pub fn find_kth_largest(nums: Vec<i32>, k: i32) -> i32 {
        
        // Edge cases.
        if nums.is_empty() {
            return -1;
        }
        else if k < 1 {
            return -1;
        }

        let mut k = k as usize;

        // Note: the binary_heap struct in Rust is implemented as 
        // a Max Heap.
        let mut pq = BinaryHeap::with_capacity(k);

        for el in nums.iter() {
            
            pq.push(core::cmp::Reverse(el));

            if pq.len() > k {
                pq.pop();
            }
        }
        
        *pq.peek().unwrap().0
    }
}