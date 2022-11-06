// 212. Work Seach II
// Tags: backtracking-DFS, trie, difficult
//
// Note: This solution is quite inefficient. We need to come back to this later
// and write one that is faster. One suggestion is simplifying the trie data structure
// more. Instead of passing the whole trie each DFS, maybe consider only the next
// letter to save on doing multiple searches.

public class Solution
{
    private static IList<string> _foundWordList { get; set; }

    // NOTE: Assuming that the jagged array is uniform
    // size across all members.
    public IList<string> FindWords(char[][] board, string[] words) 
    {
        // Edge cases.
        if(board == null)
            return null;
        if(board[0] == null)
            return null;
        if(words == null)
            return null;

        Trie wordTree = new();
        _foundWordList = new List<string>();

        // Convert words into a prefix tree (trie).
        foreach(string w in words)
            wordTree.Insert(w);

        // Iterate over the board and DFS as needed.
        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board[i].Length; j++)
            {
                if(wordTree.StartsWith(board[i][j]))
                    _4WayWordSearch(ref board, ref wordTree, i, j, "");                    
            }
        }

        return _foundWordList;
    }

    private static void _4WayWordSearch(ref char[][] board, ref Trie wordTree, int i, int j, string word)
    {
        // Edge case.
        if(i < 0 || j < 0 || i >= board.Length || j >= board[i].Length)
            return;
        
        // This node has already been searched so we return early.
        if(board[i][j] == ' ')
            return;

        word = word + board[i][j];

        // If this word exists in the trie, then we add this to our word list.
        if(wordTree.Search(word))
        {
           // Add the word if we haven't added it to the list yet.
            if(!_foundWordList.Contains(word))
                _foundWordList.Add(word);
        }

        // Otherwise, if our unfinished word still exits in the trie, DFS deeper.
        if(wordTree.StartsWith(word))
        {
            char temp = board[i][j];
            board[i][j] = ' ';

            _4WayWordSearch(ref board, ref wordTree, i + 1, j, word);
            _4WayWordSearch(ref board, ref wordTree, i - 1, j, word);
            _4WayWordSearch(ref board, ref wordTree, i, j + 1, word);
            _4WayWordSearch(ref board, ref wordTree, i, j - 1, word);

            board[i][j] = temp;
        }
    }

    public class Trie
    {
        private TrieNode _root;

        public Trie()
        {
            // Using Unicode 'null' for our root
            // node. This can be any char, it's not
            // important.
            _root = new TrieNode('\0');
        }

        public void Insert(string word)
        {
            TrieNode curr = _root;

            for(int i = 0; i < word.Length; i++)
            {
                char c = word[i];

                // Add char if missing
                // This c - 'a' syntax is syntactic sugar for
                // changing both chars to their ASCII int values and
                // subtracting them. We use 'a' because we can only use
                // indexes 0 to 25.
                if(curr.Children[c - 'a'] == null)
                    curr.Children[c - 'a'] = new TrieNode(c);

                // Move down the tree to the next node. (Or the
                // node we just inserted.)
                curr = curr.Children[c - 'a'];
            }

            curr.IsWord = true;
        }

        public bool Search(string word)
        {
            TrieNode n = _getNode(word);
            return (n != null && n.IsWord);
        }

        public bool StartsWith(string prefix)
        {
            return _getNode(prefix) != null;
        }

        public bool StartsWith(char prefix)
        {
            if(_root.Children[prefix - 'a'] == null)
                return false;
            else
                return true;
        }

        // Helper method.
        // Checks, for some 'word' passed, if all those characters
        // exists as children for the _root node.
        // Returns the leaf node if true, otherwise returns null.
        private TrieNode _getNode(string word)
        {
            TrieNode curr = _root;

            for(int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if(curr.Children[c - 'a'] == null)
                    return null;
                
                curr = curr.Children[c - 'a'];
            }

            return curr;
        }
    }

    // NOTE: Only works for either exclusively lowercase or uppercase English letters.
    public class TrieNode
    {
        public char c;
        public bool IsWord;
        public TrieNode[] Children;

        public TrieNode(char c)
        {
            this.c = c;
            this.IsWord = false;
            Children = new TrieNode[26];
        }
    }
}