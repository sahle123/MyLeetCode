// 39. Combination Sum
// Tags: backtracking, combinatorics
//

public class Solution 
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> result = new List<IList<int>>();

        // Edge cases.
        if(candidates == null)
            return result;
        else if (candidates.Length == 0)
            return result;

        Array.Sort(candidates);
        _backtrack(ref result, new List<int>(), candidates, target, 0);

        return result;
    }

    private void _backtrack(ref IList<IList<int>> result, List<int> temp, int[] candidates, int remainder, int index)
    {
        if (remainder < 0)
            return;
        else if (remainder == 0)
            result.Add(new List<int>(temp));
        else
        {
            for(int i = index; i < candidates.Length; i++)
            {
                temp.Add(candidates[i]);
                _backtrack(ref result, temp, candidates, (remainder - candidates[i]), i);
                temp.RemoveAt(temp.Count - 1);
            }
        }
    }
}