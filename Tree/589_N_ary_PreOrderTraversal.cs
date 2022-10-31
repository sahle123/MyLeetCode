// 589. N-ary Tree Preorder Traversal
// Tags: tree, fundamentals, DFS

/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution 
{
    public IList<int> Preorder(Node root) 
    {
        IList<int> result = new List<int>();
        
        // Edge case.
        if(root == null)
            return result;
        
        _preOrderPrint(root, ref result);
        
        return result;
    }
    
    // Pre-order traversal: print, left, ..., right
    private static void _preOrderPrint(Node node, ref IList<int> result)
    {
        if(node == null)
            return;
        
        result.Add(node.val);
        
        foreach(Node i in node.children)
            _preOrderPrint(i, ref result);
    }
}