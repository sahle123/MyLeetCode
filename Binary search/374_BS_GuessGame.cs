// 374. Guess Number Higher or Lower
// Tags: binary search, fundamentals

/** 
 * Forward declaration of guess API.
 * @param  num  your guess
 * @return      -1 if num is higher than the picked number
 *		        1 if num is lower than the picked number
 *              otherwise return 0
 * int guess(int num);
 */
public class Solution : GuessGame 
{
    public int GuessNumber(int n) 
    {
        // Edge case.
        if(n <= 0)
            return 0;
        
        // Optiization
        if(n == 1)
            return 1;
            
        // Binary search
        int lowerBound = 1;
        int upperBound = n;
        int mid;
        int ourGuess;
        
        while(lowerBound < upperBound)
        {
            mid = _calculateMiddleBound(lowerBound, upperBound);
            ourGuess = guess(mid);
            
            // We found the right number.
            if(ourGuess == 0)
                return mid;
            // Our number is too big; go lower.
            else if (ourGuess == -1)
                upperBound = mid - 1;
            // Our number is too small; go higher.
            else
                lowerBound = mid;
        }
        
        // Edge case where the final lowerBound
        // value is the answer
        return lowerBound;
    }
}