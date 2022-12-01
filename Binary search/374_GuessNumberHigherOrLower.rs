/** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * unsafe fn guess(num: i32) -> i32 {}
 */

 impl Solution {
    unsafe fn guessNumber(n: i32) -> i32 {
        
        // Edge case and optimization.
        if n <= 0 {
            return 0;
        }
        if n == 1 {
            return 1;
        }
        
        let mut lower_bound: i32 = 1;
        let mut upper_bound: i32 = n;
        let mut mid: i32;
        let mut our_guess: i32;
        
        while lower_bound < upper_bound {
            mid = (lower_bound + ((upper_bound - lower_bound + 1) / 2));
            our_guess = guess(mid);
            
            if our_guess == 0 {
                return mid;
            } 
            else if our_guess == -1 {
                upper_bound = mid - 1;
            } 
            else {
                lower_bound = mid;
            }
        }
        
        // Edge case where the final lower bound
        // value is the answer.
        lower_bound
    }
}