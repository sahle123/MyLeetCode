// 701. Insert into a Binary Search Tree
// Tags: fundamentals, tree, binary search tree
//
// Note: Ths isn't a great implementation since this tree can 
// quickly get unbalanced and messy. It will technically be a valid
// BST, but not an efficient one.
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
    public TreeNode InsertIntoBST(TreeNode root, int val) 
    {
        // Edge case.
        if(root == null)
            return new TreeNode(val);

        InsertBST(ref root, val);
        return root;
    }

    private static void InsertBST(ref TreeNode node, int val)
    {
        // Edge case. This shouldn't hit.
        if(node == null)
            return;
        
        // Value is smaller, go left.
        else if(node.val > val)
        {
            // We have reached the bottom and can insert a node.
            if(node.left == null)
                node.left = new TreeNode(val);
            
            // Go deeper.
            else
                InsertBST(ref node.left, val);
        }
            
        // Value is bigger, go right.
        else if(node.val < val)
        {
            // We have reached the bottom and can insert a node.
            if(node.right == null)
                node.right = new TreeNode(val);
            
            // Go deeper.
            else
                InsertBST(ref node.right, val);
        }
    }
}