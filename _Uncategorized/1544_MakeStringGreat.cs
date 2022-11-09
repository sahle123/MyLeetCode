// 1544. Make The String Great
// Tags: char[] manipulation
//

// This does not use stacks for string methods.
public class Solution 
{
    private static char _deleteMark = '_';
    
    public string MakeGood(string s) 
    {
        // Edge case.
        if(string.IsNullOrEmpty(s))
            return string.Empty;
        
        char[] charArr = s.ToCharArray();
        StringBuilder result = new();
        
        bool repeat;
        
        // Mark values for deletion
        do 
        {
            repeat = false;
            int j = 0;
            for(int i = 0; i < charArr.Length - 1; i++)
            {
                if (charArr[i] == _deleteMark)
                    continue;
                    
                j = i + 1;
                
                // Find next non-deletemark neighbor, if possible.
                if (charArr[j] == _deleteMark)
                {
                    while(j < charArr.Length)
                    {
                        if(charArr[j] != _deleteMark)
                            break;
                        
                        j++;
                    }
                    
                    // Edge case.
                    if(j == charArr.Length)
                        break;
                }
                
                // Mark these 2 chars for deletion.
                if(
                    ((Char.IsLower(charArr[i]) && Char.IsUpper(charArr[j]))
                        && (charArr[i] == Char.ToLower(charArr[j])))
                    || 
                    ((Char.IsUpper(charArr[i]) && Char.IsLower(charArr[j]))
                        && (charArr[i] == Char.ToUpper(charArr[j])))
                )
                {
                    charArr[i] = _deleteMark;
                    charArr[j] = _deleteMark;
                    i++;
                    repeat = true;
                }
            }
            //System.Console.WriteLine(charArr);
        } while(repeat);
    

        // Return a new string w/ only the valid chars.
        for(int i = 0; i < charArr.Length; i++)
        {
            if(charArr[i] != _deleteMark)
                result.Append(charArr[i]);
        }
        
        //System.Console.WriteLine(charArr);
        return new string(result.ToString());
    }
}