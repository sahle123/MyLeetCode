// 299. Bulls and Cows
// Tags:
//

public class Solution 
{
    public string GetHint(string secret, string guess) 
    {
        Dictionary<int, int> sec = new();
        List<int> positions = new();
        int bulls = 0;
        int cows = 0;
        
        // Add bulls and add all missed values into a hash map.
        for(int i = 0; i < secret.Length; i++)
        {
            if(secret[i] == guess[i])
                bulls++;
            
            else if(!sec.ContainsKey(secret[i]))
            {
                sec.Add(secret[i], 1);
                positions.Add(i);
            }
            else
            {
                sec[secret[i]] += 1;
                positions.Add(i);
            }
        }
        
        // Iterate again to check if we had any cows
        foreach(int i in positions)
        {
            if(sec.ContainsKey(guess[i]))
            {
                if(sec[guess[i]] > 0)
                {
                    sec[guess[i]] -= 1;
                    cows++;
                }
            }
        }

        return new string(bulls.ToString() + "A" + cows.ToString() + "B");
    }
}