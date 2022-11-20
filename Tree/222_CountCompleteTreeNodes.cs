// 222. Count Complete Tree Nodes 
// Tags: tree, complete tree
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
    public int CountNodes(TreeNode root) 
    {
        // Edge cases.
        if(root == null)
            return 0;
        
        TreeNode ptr = root;
        int lHeight = 1;
        int rHeight = 1;
        
        // Get the height of the left-most nodes.
        while(ptr.left != null)
        {
            lHeight++;
            ptr = ptr.left;
        }
        
        ptr = root;
        // Get the height of the right-most nodes.
        while(ptr.right != null)
        {
            rHeight++;
            ptr = ptr.right;
        }
        
        //Console.WriteLine($"{lHeight}, {rHeight}");
        
        // Tree is balanced.
        if(lHeight == rHeight)
            return (int)Math.Pow(2, lHeight) - 1;
        // Manual count.
        else
            return CountNodes(root.left) + CountNodes(root.right) + 1;
    }
}