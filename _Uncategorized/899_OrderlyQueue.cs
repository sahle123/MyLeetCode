// 899. Orderly Queue
// Tags: array-heavy, hard
//
// Note: this code needs to be cleaned up.
// Note: this has 2 solutions
public class Solution
{
    public string OrderlyQueue(string s, int k) 
    {
        // Supposedly it is trivial to sort with rotations when k > 1.
        // So we use a built-in sort function to handle that.
        if(k > 1)
        {
            char[] temp = s.ToCharArray();
            Array.Sort(temp);
            return new string(temp);
        }
        
        // Else, everything gets too complicated and you need to use KMP or
        // Booth's algorithm or something or another. This question is wicked
        // difficult to understand. I am doing it the plebbian,
        // brute-force way where I'll just iterate till
        // I find the smallest string. Since we can only do as
        // many rotations as the length of string before we repeat,
        // we will check that many times to find the smallest
        // lexicographically smallest string and return that.
        else
        {
            // Using char arrays for potential speed boost since
            // strings are immutable.
            char[] result = s.ToCharArray();
            char[] temp = s.ToCharArray();
            char[] temp2 = new char[temp.Length];
            char holder;
            
            for(int i = 0; i < temp.Length; i++)
            {
                // We are appending the first part of the string
                // to the last s.Length times.
                holder = temp[0];
                Array.Copy(temp, 1, temp2, 0, temp.Length - 1);
                temp2[temp.Length - 1] = holder;
                Array.Copy(temp2, temp, temp.Length);

                if(Compare(result, temp))
                    Array.Copy(temp, result, temp.Length);
                
               //System.Console.WriteLine(result);
            }
            
            return new string(result);
        }
    }
    
    // If str1 is lexographically smaller than str2, return false.
    // If str1 is lexographically bigger than str2, return true.
    // If str1 == str2, return false;
    private bool Compare(char[] str1, char[] str2)
    {
        
        // Edge case.
        if(str1.Length != str2.Length)
            return false;
        
        for(int i = 0; i < str1.Length; i++)
        {
            //System.Console.WriteLine(str1[i].CompareTo(str2[i]));
            
            if(str1[i].CompareTo(str2[i]) < 0)
                return false;
            else if(str1[i].CompareTo(str2[i]) > 0)
                return true;
        }
        return false;
    }
}

// Time complexity: O(n^2) --> 
// Space complexity: O(n) --> where n is the size of the passed in string 's'.
public class SolutionString
{
    public string OrderlyQueue(string s, int k) 
    {
        // Supposedly it is trivial to sort with rotations when k > 1.
        // So we use a built-in sort function to handle that.
        if(k > 1)
        {
            char[] temp = s.ToCharArray();
            Array.Sort(temp);
            return new string(temp);
        }
        
        // Else, everything gets too complicated and you need to use KMP or
        // Booth's algorithm or something or another. This question is wicked
        // difficult to understand. I am doing it the plebbian,
        // brute-force way where I'll just iterate till
        // I find the smallest string. Since we can only do as
        // many rotations as the length of string before we repeat,
        // we will check that many times to find the smallest
        // lexicographically smallest string and return that.
        else
        {
            string result = s;
            for(int i = 0; i < s.Length; i++)
            {
                // We are appending the first part of the string
                // to the last s.Length times.
                s = s.Substring(1, s.Length - 1) + s[0];
                
                // The .CompareTo() method returns 
                // 0 if the strings are equal in sort-order.
                // < 0 if the argument comes before the object string.
                // > 0 if the argument comes after the object string.
                if(s.CompareTo(result) < 0)
                    result = s;
            }
            
            return result;
        }
    }
}