// 700. Search in a Binary Search Tree
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
    public TreeNode SearchBST(TreeNode root, int val) 
    {
        // Edge case.
        if(root == null)
            return null;
        
        else if(root.val == val)
            return root;
        
        else if (root.val < val)
            return SearchBST(root.right, val);
        
        else if (root.val > val)
            return SearchBST(root.left, val);
        
        return null;
    }
}