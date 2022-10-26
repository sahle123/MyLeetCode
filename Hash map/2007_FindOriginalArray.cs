// 2007. Find Original Array From Doubled Array
// Tags: HashMap
// N.B. slow, but works for even arrays that contain duplicate values.
public class Solution 
{
    public int[] FindOriginalArray(int[] changed) 
    {
        if(changed == null)
            return new int[0];
        else if(changed.Length % 2 != 0)
            return new int[0];
        
        DoubleCheck[] doubles = new DoubleCheck[changed.Length];
        
        // Stored doubled values in separate array. Needs to be in order.
        for(int i = 0; i < changed.Length; i++)
            doubles[i] = new DoubleCheck(changed[i]);
        
        Array.Sort(doubles);
        
        int[] original = new int[changed.Length/2];
        
        int index = 0;
        bool cont = false;
        do
        {
            cont = false;
            for(int i = doubles.Length - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if((doubles[i].val == doubles[j].val*2)
                        && (doubles[i].keep && doubles[j].keep))
                    {
                        doubles[i].keep = false;
                        doubles[j].keep = false;
                        original[index] = doubles[j].val;
                        index++;
                        cont = true;
                    }
                }
                
            }
        }
        while(cont);
        
        // Edge case for when we don't get a full matching array
        if (index == original.Length)
            return original;
        else
            return new int[0];
    }
    
    public class DoubleCheck : IComparable<DoubleCheck>
    {
        public int val { get; set; }
        public bool keep { get; set; }
        
        public DoubleCheck(int val)
        {
            this.val = val;
            this.keep = true;
        }
        
        public int CompareTo(DoubleCheck other)
        {
            return val.CompareTo(other.val);
        }
    }
}

// Faster solution, but doesn't work if our array
// has any duplicate values.
public class Solution2
{
    public int[] FindOriginalArray(int[] changed) 
    {
        if(changed == null)
            return new int[0];
        
        int n = changed.Length;
        
        if(n % 2 != 0)
            return new int[0];
        
        Dictionary<int, int> freq = new();
        
        // Populate dictionary with all numbers as key
        // NOTE THAT THIS DOES NOT WORK FOR NUMBERS THAN CAN REPEAT.
        foreach(int num in changed)
        {
            if(freq.ContainsKey(num))
                freq[num]++;
            else
                freq.Add(num, 1);
        }
        
        Array.Sort(changed);
        
        int[] original = new int[n/2];
        int index = 0;
        foreach (int i in changed)
        {
            if(freq[i] == 0)
                continue;
            
            int doubledVal = i*2;
            
            // Edge case for when we don't get a full matching array
            // Or if the doubled value does not exist.
            if(!freq.ContainsKey(doubledVal) || index >= n/2)
                return new int[0];
            
            original[index] = i;
            freq[i]--;
            freq[doubledVal]--;
            index++;
        }
    
        return original;
    }
}