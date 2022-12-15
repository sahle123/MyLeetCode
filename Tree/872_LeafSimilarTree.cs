// 872. Leaf-Similar Trees.
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
    public bool LeafSimilar(TreeNode root1, TreeNode root2) 
    {
        // Edge case.
        if(root1 == null || root2 == null)
            return false;

        List<int> leaves1 = new();
        List<int> leaves2 = new();

        _DFS(root1, ref leaves1);
        _DFS(root2, ref leaves2);

        if(leaves1.Count != leaves2.Count)
            return false;
        else 
        {
            for(int i = 0; i < leaves1.Count; i++)
            {
                if(leaves1[i] != leaves2[i])
                    return false;
            }
        }
        return true;
    }

    private void _DFS(TreeNode node, ref List<int> leaves)
    {
        if(node == null)
            return;

        else if(node.left == null && node.right == null)
            leaves.Add(node.val);

        _DFS(node.left, ref leaves);
        _DFS(node.right, ref leaves);
    }
}