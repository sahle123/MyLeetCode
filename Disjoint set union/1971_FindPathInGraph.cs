// 1971. Find if Path Exists in Graph
// Tags: disjoint set union, union find
//

public class Solution 
{
    // Assuming jagged array is uniform across all members.
    public bool ValidPath(int n, int[][] edges, int source, int destination) 
    {
        // Edge cases + optimizations.
        if(edges == null || edges.Length == 0)
            return true;
        else if (edges[0] == null || edges[0].Length == 0) 
            return true;
        else if (n == 1)
            return true;

        DSU paths = new(n);

        // Create all unions so as to find all paths.
        foreach(var i in edges)
        {
            paths.Union(i[0], i[1]);
        }

        // Check if our source and destination are in the same graph.
        if(paths.Find(source) == paths.Find(destination))
            return true;
        else
            return false;
    }

    public class DSU
    {
        private int[] _root;
        private int _n { get; set; }

        public DSU(int size)
        {
            _n = size;
            _root = new int[_n];

            // initialize _root
            for(int i = 0; i < _n; i++)
            {
                _root[i] = i;
            }
        }

        public int Find(int x)
        {
            if(x == _root[x])
            {
                return x;
            }
            else 
            {
                // Path compression.
                _root[x] = Find(_root[x]);
                return _root[x];
            }
        }

        public bool Union(int a, int b)
        {
            a = Find(a);
            b = Find(b);

            if(a != b)
            {
                _root[a] = b;
                return true;
            }
            return false;
        }
    }
}