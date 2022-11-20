// 587. Erect the Fence
// Tags: hard, math, Graham Scan
//
// Note: I still don't fully understand this solution. I took it from the solution for this problem
// on LeetCode...
public class Solution 
{
    private int[] _bottomMostTree { get; set; }

    // Gets the bottom-left-most point.
    private int[] FindBottomLeftTree(int[][] trees)
    {
        int[] bottomLeft = trees[0];

        // Find bottom-left-most point.
        foreach (var i in trees)
        {
            if(i[1] < bottomLeft[1])
                bottomLeft = i;
        }

        return bottomLeft;
    }

    private int Orientation(int[] p, int[] q, int[] r)
    {
        int result = (q[1] - p[1]) * (r[0] - q[0]);
        result -= (q[0] - p[0]) * (r[1] - q[1]);

        return result;
    }

    private int Distance(int[] p, int[] q)
    {
        int result = (p[0] - q[0]) * (p[0] - q[0]);
        result += (p[1] - q[1]) * (p[1] - q[1]);

        return result;
    }

    // Sorts array based on orientation and distance
    // from our starting point, which is the bottom-most
    // tree in the graph.
    private int Sorter(int[]p, int[] q)
    {
        double diff = Orientation(_bottomMostTree, p, q) - Orientation(_bottomMostTree, q, p);

        if(diff == 0)
            return Distance(_bottomMostTree, p) - Distance(_bottomMostTree, q);
        else if (diff > 0)
            return 1;
        else
            return -1;
    }

    // Assuming jagged array is uniform
    // across all members.
    public int[][] OuterTrees(int[][] trees) 
    {
        // Edge case.
        if(trees.Length <= 1)
            return trees;

        _bottomMostTree = FindBottomLeftTree(trees);
        Array.Sort(trees, Sorter);

        int i = trees.Length - 1;

        while(i >= 0 && Orientation(_bottomMostTree, trees[trees.Length - 1], trees[i]) == 0)
            i--;

        int j = i + 1;
        int k = trees.Length - 1;
        for(; j < k; )
        {
            int[] temp = trees[j];
            trees[j] = trees[k];
            trees[k] = temp;

            j++;
            k--;
        }

        Stack<int[]> stk = new();

        stk.Push(trees[0]);
        stk.Push(trees[1]);

        for(int r = 2; r < trees.Length; r++)
        {
            int[] top = stk.Pop();
            while(Orientation(stk.Peek(), top, trees[r]) > 0)
                top = stk.Pop();

            stk.Push(top);
            stk.Push(trees[r]);
        }

        List<int[]> result = new();
        while(stk.Count > 0)
            result.Add(stk.Pop());

        return result.ToArray();
    }
}