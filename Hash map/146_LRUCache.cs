// 146. LRU cache
// Tags: caching, hash map
public class LRUCache 
{
    public Dictionary<int, int> Cache { get; set;}
    
    private List<int> _lastUsed { get; set; }
    private int _capacity { get; set;}
    
    public LRUCache(int capacity) 
    {
        _capacity = capacity;
        _lastUsed = new List<int>();
        Cache = new Dictionary<int, int>();
    }
    
    public int Get(int key) 
    {
        if(!Cache.ContainsKey(key))
            return -1;
        
        _lastUsed.Remove(key);
        _lastUsed.Insert(0, key);
        return Cache[key];
    }
    
    public void Put(int key, int val) 
    {
        // Case 1: Cache doesn't have key and not full capacity
        if(!Cache.ContainsKey(key) && Cache.Count != _capacity)
        {
            Cache.Add(key, val);
            _lastUsed.Insert(0, key);
        }
        // Case 2: Cache doesn't have key and at full capacity.
        else if(!Cache.ContainsKey(key) && Cache.Count >= _capacity)
        {
            Cache.Remove(_lastUsed.Last());
            _lastUsed.Remove(_lastUsed.Last());
            Cache.Add(key, val);
            _lastUsed.Insert(0, key);
        }
        // Case 3: Cache contains key.
        else
        {
            Cache[key] = val;
            _lastUsed.Remove(key);
            _lastUsed.Insert(0, key);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */