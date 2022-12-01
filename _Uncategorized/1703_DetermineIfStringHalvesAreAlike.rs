// 1704. Determine if String Halves are Alike
// Tags: 
//

impl Solution {
    const VOWELS: &'static [char; 10] = &['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];
    
    pub fn is_vowel(c: char) -> bool {
        
        for v in Solution::VOWELS {
            if (*v) == c {
                return true;
            }
        }
        false
    }
    
    pub fn halves_are_alike(s: String) -> bool {
        
        let chars: Vec<char> = s.chars().collect();
        let half_length = chars.len()/2;
        
        let mut a_count = 0;
        let mut b_count = 0;
        
        for i in 0..half_length {
            if Solution::is_vowel(chars[i]) {
                a_count += 1;
            }
            
            if Solution::is_vowel(chars[i + half_length]) {
                b_count += 1;
            }
        }
        
        a_count == b_count
    }
}