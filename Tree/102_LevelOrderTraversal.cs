// 102. Binary Tree Level Order Traversal
// Tags: fundamentals, tree, BFS

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
public class Solution 
{
    private List<IList<int>> _result = new List<IList<int>>();

    public IList<IList<int>> LevelOrder(TreeNode root) 
    {
        if(root == null)
            return _result;
        
        // First run setup
        Queue<TreeNode> level = new();
        level.Enqueue(root);

        IList<TreeNode> temp = new List<TreeNode>();
        IList<int> levelVals;

        while(level.Count > 0)
        {
            // Reset values for next level run.
            temp.Clear();
            levelVals = new List<int>();

            // Store queue in a list.
            while(level.Count > 0)
            {
                temp.Add(level.Dequeue());
            }
            // Add values for this level to result
            // and queue up for the next row of children.
            foreach(TreeNode t in temp)
            {
                levelVals.Add(t.val);
                if(t.left != null)
                    level.Enqueue(t.left);
                if(t.right != null)
                    level.Enqueue(t.right);
            }
            _result.Add(levelVals);
        }

        return _result;
    }
}