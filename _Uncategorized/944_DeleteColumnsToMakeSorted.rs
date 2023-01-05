// 944. Delete Columns to Make Sorted
// Tags: string
//
// Constraint: strs only consists of lowercase English letters.

// This solution is MUCH better, rust-wise.
impl Solution {
    pub fn min_deletion_size(strs: Vec<String>) -> i32 {
        let mut deletion_size = 0;

        let word_length = strs[0].len();
        let vec_length = strs.len();

        // Convert string vector into a vector of vector of unsigned int 32.
        let strs: Vec<Vec<u8>> = strs
                                    .into_iter()
                                    .map(|s| s.into_bytes())
                                    .collect();

        for j in 0..word_length {
            for i in 1..vec_length {
                if strs[i - 1][j] > strs[i][j] {
                    deletion_size += 1;
                    break;
                }
            }
        }
        deletion_size
    }
}

// NOTE: In the context of Rust, this solution is horrendously slow.
impl BadSolution {
    pub fn min_deletion_size(strs: Vec<String>) -> i32 {
        let mut deletion_size = 0;

        // Edge case.
        if strs.is_empty() || strs.len() == 0 {
            return deletion_size;
        }
        else {
            let word_length = strs[0].len();

            let mut prev_char = '`';
            let mut curr_char;

            for j in 0..word_length {
                prev_char = '`';

                for i in 0..strs.len() {
                    curr_char = strs[i].chars().nth(j).unwrap(); // I think the bottleneck is right here.

                    if (prev_char as u32) > (curr_char as u32) {
                        deletion_size += 1;
                        break;
                    }

                    prev_char = curr_char;
                } 
            } 
        }

        deletion_size
    }
}