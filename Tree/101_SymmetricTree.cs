// 101. Symmetric Tree
// Tags: BFS, tree
//
// Note: This solution has 2 examples. One with order and one without order solution.
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
// Order matters solution
public class Solution 
{
    public bool IsSymmetric(TreeNode root) 
    {
        // Edge cases.
        if(root == null)
            return true;

        else if(root.left == null && root.right == null)
            return true;
        
        else if(root.left == null || root.right == null)
            return false;
        
        else if(root.left.val != root.right.val)
            return false;
        
        // First run setup
        Queue<TreeNode> tier = new();
        tier.Enqueue(root.left);
        tier.Enqueue(root.right);

        TreeNode[] temp;

        while(tier.Count > 0)
        {
            temp = new TreeNode[tier.Count];

            // Store tree tier into a list.
            int tierSize = tier.Count;
            for(int i = 0; i < tierSize; i++)
            {
                temp[i] = tier.Dequeue();
            }
            
            // Check if node children are symmetric.
            for(int i = 0; i < (temp.Length/2); i++)
            {
                if(temp[i].left == null && temp[temp.Length - i - 1].right == null)
                {
                    ; // Purposefully empty.
                }
                else if(temp[i].left != null && temp[temp.Length - i - 1].right != null)
                {
                    if(temp[i].left.val != temp[temp.Length - i - 1].right.val)
                        return false;
                }
                else 
                    return false;
                
                if(temp[i].right == null && temp[temp.Length - i - 1].left == null)
                {
                    ; // Purposefully empty.
                }
                else if(temp[i].right != null && temp[temp.Length - i - 1].left != null)
                {
                    if(temp[i].right.val != temp[temp.Length - i - 1].left.val)
                        return false;
                }
                else 
                    return false;                
            }

            // Queue up children to check next tree tier.
            foreach(TreeNode t in temp)
            {
                if(t.left != null)
                    tier.Enqueue(t.left);
                if(t.right != null)
                    tier.Enqueue(t.right);
            }
        }
        return true;
    }
}

 // Order does not matter solution.
public class SolutionOrderDoesNotMatter
{
    public bool IsSymmetric(TreeNode root) 
    {
        // Edge cases.
        if(root == null)
            return true;

        else if(root.left == null && root.right == null)
            return true;
        
        else if(root.left == null || root.right == null)
            return false;
        
        // First run setup
        Queue<TreeNode> tier = new();
        tier.Enqueue(root.left);
        tier.Enqueue(root.right);

        TreeNode[] temp;

        while(tier.Count > 0)
        {
            // Tier must be divisilbe by 2 otherwise it is asymmetric.
            if(tier.Count % 2 != 0)
                return false;

            temp = new TreeNode[tier.Count];

            // Store tree tier into a list.
            int tierSize = tier.Count;
            for(int i = 0; i < tierSize; i++)
            {
                temp[i] = tier.Dequeue();
            }
            
            // Check if list is symmetric down the middle.
            for(int i = 0; i < (temp.Length/2); i++)
            {                
                if(temp[i].val != temp[temp.Length - i - 1].val)
                    return false;
            }

            // Queue up children to check next tree tier.
            foreach(TreeNode t in temp)
            {
                if(t.left != null)
                    tier.Enqueue(t.left);
                if(t.right != null)
                    tier.Enqueue(t.right);
            }
        }
        return true;
    }
}