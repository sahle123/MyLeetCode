// 295. Find Median from Data stream.
// Tags: ??
//
// Note: This has 2 solutions.

// This solution TLEs
public class MedianFinderOld 
{
    private List<int> _nums { get; }
    
    public MedianFinder() 
    {
        _nums = new List<int>();
    }
    
    public void AddNum(int num) 
    {
        _nums.Add(num);
    }
    
    public double FindMedian() 
    {
        _nums.Sort();
        int middlePoint = _nums.Count/2;
        
        // For odd-numbered of entries.
        if(_nums.Count % 2 == 1)
            return Convert.ToDouble(_nums[middlePoint]);
        
        // Calculate meaned median and return
        else
        {
            //Console.WriteLine($"{_nums[middlePoint - 1]}, {_nums[middlePoint]}");
            return Convert.ToDouble((_nums[middlePoint - 1] + _nums[middlePoint])) / 2;
        }
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */