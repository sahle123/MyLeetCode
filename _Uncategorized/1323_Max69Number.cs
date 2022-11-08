// 1323. Maxmium 69 Number
// Tags: puzzle

public class Solution 
{
    public int Maximum69Number(int num)
    {
        StringBuilder sb = new(num.ToString());
        
        for(int i = 0; i < sb.Length; i++)
        {
            if(sb[i] == '6')
            {
                sb[i] = '9';
                return Int32.Parse(sb.ToString());
            }
        }
        
        return num;
    }
}