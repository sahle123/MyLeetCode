// 520. Detect Capital
// Tags: ASCII
//

public class Solution 
{
    private const int _lowercaseLowerBound = 96;
    private const int _lowercaseUpperBound = 123;
    private const int _uppercaseLowerBound = 64;
    private const int _uppercaseUpperBound = 91;

    public bool DetectCapitalUse(string word) 
    {
        // Edge case.
        if(string.IsNullOrEmpty(word))
            return false;

        byte[] asciiBytes = Encoding.ASCII.GetBytes(word);

        // Only lowercase
        if(word[0] > _lowercaseLowerBound && word[0] < _lowercaseUpperBound)
            return _IsAllLowercase(asciiBytes);

        // Either proper or all uppercase.
        return _IsProperOrAllUpper(asciiBytes);
    }

    private bool _IsAllLowercase(byte[] asciiBytes)
    {
        for(int i = 0; i < asciiBytes.Length; i++)
        {
            if(asciiBytes[i] > _lowercaseLowerBound && asciiBytes[i] < _lowercaseUpperBound)
                continue;
            else
                return false;
        }
        return true;
    }

    private bool _IsProperOrAllUpper(byte[] asciiBytes)
    {
        bool stayUpper = true;

        for(int i = 0; i < asciiBytes.Length; i++)
        {
            if(!stayUpper)
            {
                // Uppercase detected.
                if(asciiBytes[i] > _uppercaseLowerBound && asciiBytes[i] < _uppercaseUpperBound)
                {
                    return false;
                }
            }

            // Lowercase detected.
            else if(asciiBytes[i] > _lowercaseLowerBound && asciiBytes[i] < _lowercaseUpperBound)
            {
                // Edge case for when the last letter may be lower and the rest before are upper.
                if(i > 1)
                    return false;

                stayUpper = false;
            }
                
        }

        return true;
    }
}