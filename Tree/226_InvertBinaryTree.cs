// 226. Invert Binary Tree
// Tags: tree, DFS
//
// Note: this has 2 solutions.
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

public class SimpleSolution
{
    public TreeNode InvertTree(TreeNode root) 
    {
        if (root == null)
            return null;
        
        TreeNode temp = InvertTree(root.left);
        root.left = InvertTree(root.right);
        root.right = temp;
        
        return root;
    }
}

public class Solution 
{
    public TreeNode InvertTree(TreeNode root) 
    {
        if(root == null)
            return root;
        
        PostOrderSwitch(root);
        return root;
    }

    private static void PostOrderSwitch(TreeNode node)
    {
        if(node == null)
            return;

        PostOrderSwitch(node.left);
        PostOrderSwitch(node.right);

        // Switch nodes
        if(node.left != null && node.right != null)
        {
            TreeNode temp = node.left;
            node.left = node.right;
            node.right = temp;
        }
        else if(node.left != null && node.right == null)
        {
            node.right = node.left;
            node.left = null;
        }
        else if(node.left == null && node.right != null)
        {
            node.left = node.right;
            node.right = null;
        }
    }
}