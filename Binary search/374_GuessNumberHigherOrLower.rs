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
        
        let mut lowerBound: i32 = 1;
        let mut upperBound: i32 = n;
        let mut mid: i32;
        let mut ourGuess: i32;
        
        while lowerBound < upperBound {
            mid = (lowerBound + ((upperBound - lowerBound + 1) / 2));
            ourGuess = guess(mid);
            
            if ourGuess == 0 {
                return mid;
            } 
            else if ourGuess == -1 {
                upperBound = mid - 1;
            } 
            else {
                lowerBound = mid;
            }
        }
        
        // Edge case where the final lower bound
        // value is the answer.
        return lowerBound;
    }
}