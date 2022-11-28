// 392. Is Subsequence
// Tags: dynamic programming
//
// Constraints: s and t only consist of lowercase English letters.

// Better solution
impl Solution {
    pub fn is_subsequence(s: String, t: String) -> bool {
        // Edge cases.
        if s.len() <= 0 {
            return true;
        }
        else if t.is_empty() {
            return false;
        }

        let sub_str = s.chars().collect::<Vec<char>>();
        let mut i: usize = 0;

        for ch in t.chars() {
            if ch == sub_str[i] {
                i += 1;
                if i == s.len() {
                    return true;
                }
            }
        }

        false
    }
}

// Note: a very lousy, Rust solution. It needs to be updated. I tried writing
// this as I normally write my C# solutions.
impl CrappySolution {
    pub fn is_subsequence(s: String, t: String) -> bool {

        //println!("s: {}, t: {}", s.len(), t.len());
        
        // Edge cases.
        if s.len() > t.len() {
            return false;
        }
        else if s.is_empty() {
            return true;
        }
        else if t.is_empty() {
            return false;
        }

        let mut counter: usize = 0;
        let mut j: usize = 0;

        for i in 0..s.len() {
            while j < t.len() {

                if t.chars().nth(j) == s.chars().nth(i) {
                    counter += 1;
                    j += 1;
                    break;
                }
                j += 1;
            }
        }

        if counter == s.len() {
            return true;
        }
        
        false
    }
}