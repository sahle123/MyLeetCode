// 145. Binary Tree Postorder Traversal
// Tags: fundamentals, tree, DFS
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
    public IList<int> PostorderTraversal(TreeNode root) 
    {
        IList<int> result = new List<int>();

        // Edge case.
        if(root == null)
            return result;

        PostOrderPrint(root, ref result);

        return result;
    }

    // Post-order traversal: left, right, print
    public static void PostOrderPrint(TreeNode node, ref IList<int> result)
    {
        if(node == null)
            return;
        
        PostOrderPrint(node.left, ref result);
        PostOrderPrint(node.right, ref result);
        result.Add(node.val);
    }
}