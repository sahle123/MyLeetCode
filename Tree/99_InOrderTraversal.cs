// 94. Binary Tree Inorder Traversal
// Tags: fundamentals, tree, DFS
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
public class Solution 
{
    public IList<int> InorderTraversal(TreeNode root) 
    {
        IList<int> result = new List<int>();

        // Edge case.
        if(root == null)
            return result;
        
        InOrderPrint(root, ref result);

        return result;
    }

    // In-order traversal: left, print, right
    public static void InOrderPrint(TreeNode node, ref IList<int> result)
    {
        if(node == null)
            return;

        InOrderPrint(node.left, ref result);
        result.Add(node.val);
        InOrderPrint(node.right, ref result);
    }
}