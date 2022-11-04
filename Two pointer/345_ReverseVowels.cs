// 345. Reverse Vowels of a String.
// Tags: two pointer
//
public class Solution 
{
    private static List<char> _vowels = new List<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
    
    public string ReverseVowels(string s) 
    {
        // Edge case.
        if(string.IsNullOrEmpty(s))
            return null;
        
        char[] temp = new char[s.Length];
        Stack<char> vowelStack = new();
        
        // Add consonants.
        for(int i = 0; i < temp.Length; i++)
        {
            if(_vowels.Contains(s[i]))
            {
               vowelStack.Push(s[i]);
            }
            else
            {
                temp[i] = s[i];
            }
        }
        
        // Add vowels.
        for(int i = 0; i < temp.Length; i++)
        {
            if(_vowels.Contains(s[i]))
            {
                temp[i] = vowelStack.Pop();
            }
        }
        return new string(temp);
    }
}