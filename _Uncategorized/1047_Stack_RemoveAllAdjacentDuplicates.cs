// 1047. Remove All Adjacent Duplicate Strings
// Tags: stack
//
// Note: This has 2 solutions.

// Uses a stack and is much faster compared to the old solution.
public class Solution 
{
    public string RemoveDuplicates(string s) 
    {
        // Edge case.
        if(s.Length <= 1)
            return s;
        
        Stack<char> stk = new();
        
        stk.Push(s[0]);
        
        for(int i = 1; i < s.Length; i++)
        {   
            // Duplicate found, pop from stack.
            if(stk.Count > 0 && stk.Peek() == s[i])
                stk.Pop();
            
            // Otherwise, add it to the stack.
            else
                stk.Push(s[i]);
        }
        
        // Pop stack and construct string
        char[] charArr = new char[stk.Count];
        for(int i = charArr.Length - 1; i >= 0; i--)
            charArr[i] = stk.Pop();
        
        return new string(charArr);
    }
}

// This solution TLEs.
public class SolutionOld
{
    public string RemoveDuplicates(string s) 
    {
        StringBuilder sb = new(s);
        
        for(int i = 0; i < sb.Length - 1; i++)
        {
            // Found duplicate
            if(sb[i] == sb[i + 1])
            {
                sb.Remove(i, 2);
                i = -1;
            }
        }
        
        return new string(sb.ToString());
    }
}