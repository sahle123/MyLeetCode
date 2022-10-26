// 144. Binary Tree Preorder Traversal
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
    public IList<int> PreorderTraversal(TreeNode root) 
    {
        IList<int> result = new List<int>();
        
        // Edge case.
        if(root == null)
            return result;
        
        PreOrderPrint(root, ref result);
        
        return result;
    }
    
    // Pre-order traversal: print, left, right
    public static void PreOrderPrint(TreeNode node, ref IList<int> result)
    {
        if(node == null)
            return;
        
        result.Add(node.val);
        PreOrderPrint(node.left, ref result);
        PreOrderPrint(node.right, ref result);
    }
}