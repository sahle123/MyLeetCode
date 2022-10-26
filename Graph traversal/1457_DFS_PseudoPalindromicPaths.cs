// 1457. Pseudo-Palindromic Paths in a Binary Tree
// Tags: DFS, HashMap
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
    private int _palindromeCount = 0;

    public int PseudoPalindromicPaths (TreeNode root) 
    {
      // Edge case.
      if (root == null)
        return 0;

      Dictionary<int, int> dict = new();
      DFS(root, dict);

      return _palindromeCount;
    }

    private void DFS(TreeNode node, Dictionary<int, int> dict)
    {
      if (node == null)
        return;

      // Add a new key to the hash map.
      if(!dict.ContainsKey(node.val))
        dict.Add(node.val, 0);

      // Add one to our key
      dict[node.val] += 1;

      // Check if we have a psuedo-palindrome.
      if(node.left == null && node.right == null)
        if(IsPsuedoPalindrome(dict))
          _palindromeCount++;

      // Recurse down the tree.
      DFS(node.left, dict);
      DFS(node.right, dict);

      // Decrement value since we are leaving this node behind 
      // and going up the tree.
      dict[node.val] -= 1;
    }

    // Checks if dictionary contains a psuedo-palindrome or not.
    private static bool IsPsuedoPalindrome(Dictionary<int, int> dict)
    {
      // The sum of values to see if the number of ints is even or odd.
      bool IsEven = (dict.Sum(x => x.Value) % 2 == 0);
      
      switch (IsEven)
      {
        case true:
          foreach(var (key, value) in dict)
          {
            // We cannot have any odd numbers for an even sized set of nodes.
            if(value % 2 == 1)
              return false;
          }
          return true;

        case false:
          // We can only have 1 odd number. More than that and it's no longer psuedo-palindrome.
          int oddCount = 0; 
          foreach(var (key, value) in dict)
          {
            if(value % 2 == 1)
            {
              if(++oddCount > 1)
                return false;
            }
          }
          return true;
      }
    }
}