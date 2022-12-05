// 692. Top K Frequent Words
// Tags: priority queue (heap), hash table
//

public class Solution 
{
    public IList<string> TopKFrequent(string[] words, int k) 
    {
        List<string> result = new();

        // Edge cases.
        if(k < 1)
            return result;
        else if (words == null || words.Length == 0)
            return result;

        // Min heap
        PriorityQueue<string, KeyValuePair<string, int>> pq = new(new LexicographicalComparer());
        Dictionary<string, int> dict = new();
        
        // Populate hash table first
        foreach(var word in words)
        {
            if(!dict.ContainsKey(word))
                dict.Add(word, 1);
            else
                dict[word] += 1;
        }

        // Build up PQ with our hash map values, but trim 
        // anytime we go over K entries.
        // Since we are using a min heap, it is okay if we
        // trim off the highest priority values.
        foreach(KeyValuePair<string, int> i in dict)
        {
            pq.Enqueue(i.Key, i);

            // If we have gone beyond K entries, start
            // dequeuing the PQ to keep the size K.
            if(pq.Count > k)
            {
                // We don't care about the value; throw it away.
                while(pq.Count != k)
                    _ = pq.Dequeue();
            }
        }

        while(pq.TryDequeue(out string key, out KeyValuePair<string, int> _))
            result.Add(key);

        // Since we were using a Min Heap, we need to flip the order of
        // the result List.
        result.Reverse();
        return result;
    }

    // Lexicographically compare Key entries if their values are equal.
    public class LexicographicalComparer : IComparer<KeyValuePair<string, int>>
    {
        public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
        {
            if(x.Value == y.Value)
                return y.Key.CompareTo(x.Key);
            else
                return (x.Value - y.Value);
        }
    }
}