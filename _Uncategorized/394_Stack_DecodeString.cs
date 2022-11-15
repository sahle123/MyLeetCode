// 394. Decode String
// Tags: stack, decoding
//
// Time:
// Space:

public class Solution 
{
    private readonly List<char> _nums = new() {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
    private const char _opening = '[';
    private const char _closing = ']';
    
    public string DecodeString(string s) 
    {
        Stack<char> _stack = new();
        StringBuilder sb = new();
        StringBuilder charMultiplier = new();
        int multiplier = 0;
        
        for(int i = 0; i < s.Length; i++)
        {
            // Found a closing bracket. Time for complicated stuff...
            if(s[i] == _closing)
            {   
                // Add up the string
                sb.Clear();
                while(_stack.Peek() != _opening)
                {
                    sb.Insert(0, _stack.Pop());
                }
                
                // Remove the '[' char
                _stack.Pop();
                
                // Find out how many times we need to "multiply" the string
                //multiplier = 0;
                charMultiplier.Clear();
                while(_nums.Contains(_stack.Peek()))
                {
                    charMultiplier.Insert(0, _stack.Pop());
                    
                    // Edge case. When we are at the end of the string.
                    if(_stack.Count == 0)
                        break;
                }
                multiplier = int.Parse(charMultiplier.ToString());
                
                // "Multiply" this string and push all chars into our stack.
                while(multiplier > 0)
                {
                    for(int j = 0; j < sb.Length; j++)
                    {
                        _stack.Push(sb[j]);
                    }
                    multiplier--;
                }
            }
            
            else
                _stack.Push(s[i]);
        }
        
        // Final step is to convert our stack into a string.
        // Need to reverse the stack however.
        char[] charArr = new char[_stack.Count];
        int k = _stack.Count - 1;
        while(_stack.Count > 0)
        {
            charArr[k] = _stack.Pop();
            k--;
        }
        
        return new string(charArr);
    }
}