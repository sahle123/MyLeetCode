// 947. Most Stones Removed with Same Row or Column.
// Tags: disjoint set union, DFS
//

public class Solution
{
    // Assuming the jagged array is uniform across all
    // members.
    public int RemoveStones(int[][] stones) 
    {
        // Edge cases.
        if(stones == null)
            return 0;
        else if(stones[0] == null)
            return 0;
        else if(stones.Length == 1)
            return 0;

        // We don't care about the coordinates. We just need a 
        // unique value that points to the stones. In this case,
        // the first indexer of the jagged array does that job.
        // The second indexer tells us if we are looking at
        // x or y.
        DSU groups = new(stones.Length);

        // We create groups based on whether the stone
        // shares a column or row with the other stone.
        for(int i = 0; i < stones.Length; i++)
        {
            for(int j = i + 1; j < stones.Length; j++)
            {
                // Create a group if row or column match.
                if(stones[i][0] == stones[j][0]
                || stones[i][1] == stones[j][1])
                {
                    //Console.WriteLine(groups.Union(i, j));
                    groups.Union(i, j);
                }
            }
        }
        //Console.WriteLine($"Groups: {groups.count}");

        // Given our groups, this is the formula to calculate the
        // max amount of stones we can remove.
        return (stones.Length - groups.count);
    }

    // Basic Disjoint Union Set class.
    public class DSU
    {
        // This is the 'representative node' for a group. When we Find() some group,
        // the root is what gets returned.
        private int[] _root;

        // The size of this instanced set.
        private int _n { get; set; }

        // Represents the number of groups.
        // Initially, the number of groups == to the size of the array.
        public int count { get; private set; }

        public DSU(int size)
        {
            _n = size;
            count = _n;
            _root = new int[_n];

            // Initialize _root
            for(int i = 0; i < _n; i++)
            {
                _root[i] = i;
            }
        }

        // Finds the root value for some value belonging to a set.
        // Uses path compression.
        public int Find(int x)
        {
            if(x == _root[x])
                return x;
            else
            {
                // path compression
                _root[x] = Find(_root[x]);
                return _root[x];
            }      
        }

        // DEV-NOTE: not in use.
        public int FindDepth(int x)
        {
            if(x == _root[x])
                return 1;
            else
                return _root[x] + 1;
        }

        // Returns true on successful union and false if the two values belong
        // to the same set.
        public bool Union(int a, int b)
        {
            // Find the root values for a and b
            a = Find(a);
            b = Find(b);

            // If they don't belong in the same group, union them.
            if(a != b)
            {
                _root[a] = b;
                count--;
                return true;
            }
            return false;
        }
    }
}