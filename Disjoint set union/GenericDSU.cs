public class MainDSU
{
    #region Disjoint Set Union implementation

    // Generic class-based Disjoint Union Set class.
    public class DSU<T> where T : IIdentifier
    {
        // This is the 'representative node' for a group. When we Find() some group,
        // the root is what gets returned.
        private T[] _root { get; set; }

        // The size of this instanced set.
        private int _n { get; }

        // Represents the number of groups.
        // Initially, the number of groups == to the size of the array.
        public int groupCount { get; private set; }

        public DSU(T[] graph, int size)
        {
            _n = size;
            groupCount = _n;
            _root = new T[_n];

            // Initialize _root.
            // Cloning it to the passed in grap.
            for(int i = 0; i < _n; i++)
            {
                _root[i] = graph[i];
            }
        }

        // Finds the root value for some value belonging to a set.
        // Uses path compression.
        public T Find(T x)
        {
            if(x.id == _root[x.id])
                return x;
            
            else
            {
                // path compression for perf. boost.
                _root[x.id] = Find(_root[x.id]);
                return _root[x.id];
            }
        }

        public bool Union(T a, T b)
        {
            // Find the root values for a and b.
            a = Find(a);
            b = Find(b);

            // Union these two sets if they are unrelated.
            if(a.id != b.id)
            {
                _root[a.id] = b;
                groupCount--;
                return true;
            }

            return false;
        }
    }

    public interface IIdentifier
    {
        // Must be unique for all members.
        public int id;
    }
    #endregion
}