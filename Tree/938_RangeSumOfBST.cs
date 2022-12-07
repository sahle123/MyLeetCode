// 938. Range Sum of BST
// Tags: tree, DFS
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
    public int RangeSumBST(TreeNode root, int low, int high) 
    {
        // Edge cases.
        if(low > high)
            return -1;
        else if(root == null)
            return -1;

        int result = 0;

        _InOrderPrint(root, low, high, ref result);

        return result;
    }

    private void _InOrderPrint(TreeNode node, int low, int high, ref int sum)
    {
        if(node == null)
            return;

        _InOrderPrint(node.left, low, high, ref sum);

        if(node.val >= low && node.val <= high)
            sum += node.val;

        _InOrderPrint(node.right, low, high, ref sum);
    }
}