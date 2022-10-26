// 208. Implement Trie (prefix tree)
// Tags: prefix tree, fundamentals
// Time: O(m)
// Space: O(m)
public class Trie 
{

    private Node _root;
    
    public Trie() 
    {
        // Using Unicode 'null' for our root
        // node. This can be any char, it's not
        // important.
        _root = new Node('\0');
    }
    
    public void Insert(string word) 
    {
        Node curr = _root;
        for(int i = 0; i < word.Length; i++)
        {
            char c = word[i];
            // Add char if missing
            // This c - 'a' syntax is syntactic sugar for
            // changing both chars to their ASCII int values and
            // subtracting them. We use 'a' because we can only use
            // indexes 0 to 25.
            if(curr.children[c - 'a'] == null)
                curr.children[c - 'a'] = new Node(c);
            
            // Move down the tree to the next node. (Or the
            // node we just inserted.)
            curr = curr.children[c - 'a'];
        }
        
        // The last node should always be marked as a word since
        // have finished inserting out word.
        curr.isWord = true;
    }
    
    public bool Search(string word) 
    {
        Node n = _getNode(word);
        return (n != null && n.isWord);
    }
    
    public bool StartsWith(string prefix) 
    {
        return _getNode(prefix) != null;
    }
    
    // Helper method.
    // Checks, for some 'word' passed, if all those characters
    // exists as children for the _root node.
    // Returns the leaf node if true, otherwise returns null.
    private Node _getNode(string word)
    {
        Node curr = _root;
        
        for(int i = 0; i < word.Length; i++)
        {
            char c = word[i];
            if(curr.children[c - 'a'] == null)
                return null;
            
            curr = curr.children[c- 'a'];
        }
        return curr;
    }
    
    // Helper class.
    private class Node 
    {
        public char c;
        public bool isWord;
        // In this example, since we know we're only
        // expecting lower case, Latin characters,
        // then we can safely initialize this array
        // to 26.
        public Node[] children;
        
        public Node(char c)
        {
            this.c = c;
            isWord = false;
            children = new Node[26];
        }
    }
}

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */

/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */