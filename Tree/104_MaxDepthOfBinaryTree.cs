// 104. Maximum Depth of Binary Tree
// Tags: fundamentals, tree, BFS, DFS
//
// Notes: This solution has 2 different implementations: BFS, DFS.
// both of those approaches have their pros and cons. i.e. memory vs. speed.
//
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

// Easier to implement, faster, but takes more memory.
public class SolutionDFS
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
    }
}

// Harder to implement, slower, but takes much less memory since we do not
// have to keep allocating a new stack via function calls.
public class SolutionBFS
{
    public int MaxDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        int result = 0;

        // First run setup
        Queue<TreeNode> depthQueue = new();
        depthQueue.Enqueue(root);

        List<TreeNode> temp = new();

        while (depthQueue.Count > 0)
        {
            temp.Clear();

            // Store queue in a list.
            while (depthQueue.Count > 0)
            {
                temp.Add(depthQueue.Dequeue());
            }

            foreach (TreeNode t in temp)
            {
                if (t.left != null)
                    depthQueue.Enqueue(t.left);
                if (t.right != null)
                    depthQueue.Enqueue(t.right);
            }
            result++;
        }

        return result;
    }
}