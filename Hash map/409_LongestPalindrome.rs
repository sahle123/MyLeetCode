// 409. Longest Palindrome
// Tags: hash map, closures
//

// Most credit goes to:
// https://leetcode.com/problems/longest-palindrome/solutions/1949080/rust-solution/
impl Solution {
    pub fn longest_palindrome(s: String) -> i32 {
        let mut dict = std::collections::HashMap::new();

        // Setup our hash map.
        s.chars().for_each(|c| {
            *dict.entry(c).or_insert(0) += 1;
        });

        // Count all the even lengthed and odd lengthed 
        // (greater than or equal to 3) entries.
        let mut count = dict.values().fold(0, |acc, &v| {
            acc + match v % 2 == 0 {
                true => v,
                false => v - 1, // We remove one number from our odd count so as to keep the palindrome valid for the timebeing.
            }
        });

        // If we have remove, add another character (one of our odd characters that were removed)
        // to the final answer.
        if count < s.len() {
            count += 1;
        }

        count as i32
    }
}