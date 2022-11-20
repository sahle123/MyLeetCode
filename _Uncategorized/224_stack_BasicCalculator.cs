// 224. Basic Calculator
// Tags: stack, math, hard
//

// Most credit goes to: yuanzhi247012
public class Solution 
{
    public int Calculate(string s) 
    {
        int sign = 1;
        int num = 0;
        int runningSum = 0;
        Stack<int> stk = new();

        // Edge case.
        if(string.IsNullOrEmpty(s))
            return 0;
        
        for(int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            // Ignore all whitespaces.
            if(c == ' ')
                continue;

            // Opening parenthesis
            else if(c == '(')
            {
                stk.Push(runningSum);
                stk.Push(sign);
                runningSum = 0;
                sign = 1;
            }

            // Closing parenthesis
            else if(c == ')')
            {
                runningSum = runningSum + sign*num;
                int subSign = stk.Pop();
                int prevSum = stk.Pop();
                runningSum = prevSum + subSign*runningSum;
                num = 0;
            }

            // Addition operator
            else if(c == '+')
            {
                runningSum = runningSum + sign*num;
                sign = 1;
                num = 0;
            }

            // Subtraction operator/unary negation
            else if(c == '-')
            {
                runningSum = runningSum + sign*num;
                sign = -1;
                num = 0;
            }

            // Plain, integer digit
            else 
            {
                // Shortcut for getting the correct ASCII value into
                // an integer.
                int temp = c - '0';
                num = num * 10 + temp;
            }
        }

        runningSum = runningSum + sign*num;
        return runningSum;
    }
}