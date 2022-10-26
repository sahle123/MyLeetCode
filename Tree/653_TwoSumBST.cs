// 653. Two Sum IV - Input is BST
// Tags: hash set, tree, binary search tree
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
    public bool FindTarget(TreeNode root, int k) 
    {
        // Edge case.
        if(root == null)
            return false;
        
        bool result = false;
        HashSet<int> s = new();
        
        PreOrderSearch(root, k, ref s, ref result);
        
        return result;
    }
    
    private static void PreOrderSearch(TreeNode node, int k, ref HashSet<int> s, ref bool isFound)
    {
        // Base cases.
        if(node == null)
            return;
        
        else if(isFound == true)
            return;
        
        if(s.Contains(k - node.val))
        {
            isFound = true;
            return;
        }
            
        s.Add(node.val);
        PreOrderSearch(node.left, k, ref s, ref isFound);
        PreOrderSearch(node.right, k, ref s, ref isFound);
    }
}