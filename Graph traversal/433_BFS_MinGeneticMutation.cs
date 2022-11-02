// 433. Minimum Genetic Mutation
// Tags: BFS, hash map
//
// Time complexity: worst case scenario O(B) where B = size of bank
// Space complexity: O(B) where B = size of bank.
public class Solution 
{
    private static int _result;
    private static char[] _molecules = new char[] {'A', 'C', 'G', 'T'};
    
    public int MinMutation(string start, string end, string[] bank) 
    {
        // Edge cases.
        if(bank.Length == 0)
            return -1;
        if(start == end)
            return 0;
        
        _result = -1;
        
        // Converting bank to a hash map for faster lookup.
        // The boolean represents if this mutation has been
        // used or not yet in the lookup tests.
        Dictionary<string, bool> bankMap = new();
        foreach(string s in bank)
        {
            if(!bankMap.ContainsKey(s))
                bankMap.Add(s, false);
        }
        
        // Edge case, check if the mutation exists in the bank. 
        // If not, then the solution is impossible; -1.
        if(!bankMap.ContainsKey(end))
            return -1;
        
        // Queue setup.
        Queue<GeneDetails> intermediateGenes = new();
        intermediateGenes.Enqueue(new GeneDetails(start));
        
        // BFS till we find a valid combination
        while(intermediateGenes.Count > 0)
            _geneBFS(ref intermediateGenes, ref bankMap, end);
        
        return _result;
    }
    
    private static void _geneBFS(ref Queue<GeneDetails> genes, ref Dictionary<string, bool> bankMap, string endGene)
    {
        GeneDetails currentGene = genes.Dequeue();
        
        //System.Console.WriteLine($"Current gene: {currentGene.Sequence}, {currentGene.MutationCount}");
        
        // Match case!
        if(currentGene.Sequence == endGene)
        {
            _result = currentGene.MutationCount;
            genes.Clear(); // We don't need to search anymore, we are done.
        }
        
        // We take another step in our mutation count.
        currentGene.MutationCount++;
        
        // Check if we can find the next valid mutation to traverse and enqueue.
        foreach(char m in _molecules)
        {
            for(int i = 0; i < currentGene.Sequence.Length; i++)
            {
                char[] temp = currentGene.Sequence.ToCharArray();
                temp[i] = m;
                string tempStr = new string(temp);
                
                //System.Console.WriteLine($"tempStr: {tempStr}");
                
                // Check if this permutation exists in the bank.
                // If not, skip this genestring.
                if(bankMap.ContainsKey(tempStr))
                {
                    // Has this mutation been explored yet or not?
                    // If not, queue-up.
                    if(bankMap[tempStr] == false)
                    {
                        genes.Enqueue(new GeneDetails(tempStr, currentGene.MutationCount));
                        bankMap[tempStr] = true;
                    }
                }
            }
        }
    }
    
    // Class we use for our queue to keep track of gene details.
    public class GeneDetails
    {
        public string Sequence { get; set; }
        public int MutationCount { get; set;}
        
        public GeneDetails(string seq)
        {
            this.Sequence = seq;
            this.MutationCount = 0;
        }
        
        public GeneDetails(string seq, int mut)
        {
            this.Sequence = seq;
            this.MutationCount = mut;
        }
    }
}