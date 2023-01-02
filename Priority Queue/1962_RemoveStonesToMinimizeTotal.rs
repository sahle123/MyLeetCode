// 1962. Remove Stones to Minimize the Total
// Tags: priority queue (heap)
//

use std::collections::BinaryHeap;

impl Solution {
    pub fn min_stone_sum(piles: Vec<i32>, k: i32) -> i32 {
        
        // Edge cases.
        if piles.is_empty() {
            return -1;
        }
        else if k < 1 {
            return -1;
        }

        // Note: the binary_heap struct in Rust is implemented as 
        // a Max Heap.
        let mut pq = BinaryHeap::<i32>::with_capacity(piles.len());

        // Populate priority queue
        for el in piles {
            pq.push(el);
        }

        let mut k = k;
        while k > 0 {

            if let Some(el) = pq.pop() {
                let temp = el - (el / 2);
                pq.push(temp);
            }
            k -= 1;
        }

        pq.iter().sum()
    }
}