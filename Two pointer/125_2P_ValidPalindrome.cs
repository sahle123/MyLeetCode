// 125. Valid Palindrome.
// Tags: Two pointer
//
public class Solution 
{
    public bool IsPalindrome(string s) 
    {
        // Edge cases.
        if(string.IsNullOrEmpty(s))
            return true;
        else if(s.Length == 1)
            return true;
        
        // C#, efficient way to build a screen since strings are immutable objects.
        StringBuilder sb = new();
        int ascii;
        string subject;
        
        // Build new string that only contains alphanumeric characters.
        foreach(char c in s)
        {
            // Get ASCII code for lowercase letter.
            ascii = (int)(Char.ToLower(c));
            
            // Space key. Continue.
            if(ascii == 32)
                continue;
            
            // Match ASCII lowercase letters and numbers.
            else if((ascii > 47 && ascii < 58) || (ascii > 96 && ascii < 123))
                sb.Append(Char.ToLower(c));
        }
        
        subject = sb.ToString();
        
        //
        // Two-pointer approach to check if characters match
        int j = subject.Length - 1;
        for(int i = 0; i < subject.Length; i++)
        {
            // Mismatch found.
            if(subject[i] != subject[j])
                return false;
            
            // For cases where the palindrome length is odd.
            else if(i == j)
                return true;
            
            j--;
        }
        
        
        return true;
    }
}