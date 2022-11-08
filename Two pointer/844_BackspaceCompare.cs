// 844. Backspace String Compare
// Tags: two pointer, hard
//
// Time: O(s + t)
// Space: O(1)
public class Solution 
{
    private static char _backspace = '#';
    
    public bool BackspaceCompare(string s, string t) 
    {
        Console.WriteLine(s + ", " + t);
        int s_backspace = 0;
        int t_backspace = 0;
        
        int j = t.Length - 1;
        int i = s.Length - 1;
        while(i >= 0 || j >= 0)
        {
            while(i >= 0)
            {
                // Add backspace and decrement
                if(s[i] == _backspace)
                {
                    s_backspace++;
                    i--;
                }
                // Add any remaining backspaces and decrement
                else if(s_backspace > 0)
                {
                    s_backspace--;
                    i--;
                }
                else
                    break;
            }

            while(j >= 0)
            {
                // Add backspace and decrement
                if(t[j] == _backspace)
                {
                    t_backspace++;
                    j--;
                }
                // Add any remaining backspaces and decrement
                else if(t_backspace > 0)
                {
                    t_backspace--;
                    j--;
                }
                else
                    break;
            }

            // Check if chars match.
            if((i >= 0 && j >= 0) && (s[i] != t[j]))
                return false;
            
            // If we are comparing a char to nothing, then return false.
            if((i >= 0) != (j >= 0))
                return false;
            
            //Console.WriteLine($"{s[i]}, {t[j]}");
            //Console.WriteLine($"{i}, {j}");

            i--;
            j--;
        }

        return true;
    }
}