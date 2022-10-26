// 112. Path Sum
// Tags: tree, DFS
//
// Note: This has 2 solutions.
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

// Checks if a path exists such that it is root-to-leaf.
public class Solution 
{
    public bool HasPathSum(TreeNode root, int targetSum) 
    {
        // Edge cases.
        if(root == null)
            return false;

        bool result = false;

        PreOrderPath(root, 0, targetSum, ref result);

        return result;
    }

    private static void PreOrderPath(TreeNode node, int runningSum, int targetSum, ref bool isFound)
    {
        if(node == null)
            return;
        else if(isFound)
            return;
        
        runningSum += node.val;
        
        // If we hit our target, verify that the node is a leaf node.
        if(runningSum == targetSum)
        {
            if(node.right == null && node.left == null)
                isFound = true;
        }
                

        PreOrderPath(node.left, runningSum, targetSum, ref isFound);
        PreOrderPath(node.right, runningSum, targetSum, ref isFound);
    }
}

// Checks if a path exists, doesn't have to be root-to-leaf.
public class SolutionAnyPath
{
    public bool HasPathSum(TreeNode root, int targetSum) 
    {
        // Edge cases.
        if(root == null)
            return false;

        bool result = false;

        PreOrderPath(root, 0, targetSum, ref result);

        return result;
    }

    private static void PreOrderPath(TreeNode node, int runningSum, int targetSum, ref bool isFound)
    {
        if(node == null)
            return;
        else if(isFound)
            return;
        
        runningSum += node.val;

        if(runningSum == targetSum)
            isFound = true;

        PreOrderPath(node.left, runningSum, targetSum, ref isFound);
        PreOrderPath(node.right, runningSum, targetSum, ref isFound);
    }
}