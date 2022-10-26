// 98. Validate Binary Search Tree
// Tags: fundamentals, tree, binary search tree
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
    public bool IsValidBST(TreeNode root) 
    {
        return IsValidBST(root, long.MinValue, long.MaxValue);
    }

    public bool IsValidBST(TreeNode node, long minVal, long maxVal)
    {
        if(node == null)
            return true;
        if(node.val >= maxVal || node.val <= minVal)
            return false;
        
        return IsValidBST(node.left, minVal, node.val) && IsValidBST(node.right, node.val, maxVal);
    }
}