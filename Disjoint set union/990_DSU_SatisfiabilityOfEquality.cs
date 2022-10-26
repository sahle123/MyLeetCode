// 990. Satisfiability of equality equations
// Tags: disjoint set union, union find

public class Solution 
{
    public bool EquationsPossible(string[] equations) 
    {
        // We use 26 because that's how many letters are in the alphabet.
        // Lower case only.
        DSU groups = new DSU(26);

        // First, group up '==' into a set
        foreach(string e in equations)
        {
            if(e[1] == '=')
                groups.Union(e[0] -'a', e[3] - 'a');
        }       
        
        // Then, check if '!=' group overlaps w/ '==' set.
        foreach(string e in equations)
        {
            if(e[1] == '!')
            {
                // If both values belong to the same group, then we know we have
                // a logic error and thus we need to return false.
                // e.g. a==b and b!=a is a logic error.
                if(groups.Find(e[0] - 'a') == groups.Find(e[3] - 'a'))
                    return false;
            }
        }
        return true;
    }

    // General Disjoint Union Set class.
    public class DSU
    {
        private int[] _root;
        private int _n { get; set; }

        // Represents the number of groups.
        // Initially, the number of groups == to the size of the array.
        public int count { get; set; }

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