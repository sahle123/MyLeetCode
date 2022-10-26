// 20. Valid Parentheses
// Tags: Stack
// Space: O(n)
// Time: O(n)

public class Solution 
{
    public bool IsValid(string s) 
    {
        Stack<char> ins = new();
        
        foreach(char c in s)
        {
            switch(c)
            {
                case ')':
                    if(CheckBalance(ref ins, c) == false)
                        return false;
                    break;
                case ']':
                    if(CheckBalance(ref ins, c) == false)
                        return false;
                    break;
                case '}':
                    if(CheckBalance(ref ins, c) == false)
                        return false;
                    break;
                default:
                    ins.Push(c);
                    break;
            }
        }
        
        return ins.Count == 0 ? true : false;
    }
    
    public static bool CheckBalance(ref Stack<char> ins, char c)
    {
        if(ins.Count == 0)
            return false;
        else
        {
            char x = ins.Pop();
            
            switch(x)
            {
                case '(':
                    return c == ')' ? true : false;
                case '[':
                    return c == ']' ? true : false;
                case '{':
                    return c == '}' ? true : false;
                default:
                    return false;
            }
        }
    }
}