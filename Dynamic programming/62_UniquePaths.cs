// 62. Unique Paths
// Tags: dynamic programming
//
// Note: This has 2 solutions.


// Tabulation, Pascal's triangle.
public class Solution
{
    public int UniquePaths(int m, int n)
    {
        // Edge cases.
        if(m == 1 || n == 1)
            return 1;
        else if(m == 2 || n == 2)
            return Math.Max(m, n);

        int[,] pascalSquare = new int[m, n];

        // Initialize our edges of the square to 1.
        for(int i = 0; i < m; i++)
        {
            pascalSquare[i, 0] = 1;
        }
        for(int i = 0; i < n; i++)
        {
            pascalSquare[0, i] = 1;
        }

        // Fill in the middle values with their proper ones.
        // i.e. the top and left values added.
        for(int i = 1; i < m; i++)
        {
            for(int j = 1; j < n; j++)
            {
                pascalSquare[i, j] = pascalSquare[i - 1, j] + pascalSquare[i, j - 1];
            }
        }

        // The bottom left corner indicates how many paths exists, going exclusively
        // right or down, for an m x n grid.
        return pascalSquare[m - 1, n -1];
    }
}

// Recursive, slow solution
public class SolutionOld
{
    public int UniquePaths(int m, int n) 
    {
        // Edge cases.
        if(m == 1 || n == 1)
            return 1;
        else if(m == 2 || n == 2)
            return Math.Max(m, n);

        int pathSum = 0;

        for(int i = m; i > 0; i--)
        {
            pathSum = pathSum + UniquePaths(i, n - 1);
        }

        return pathSum;
    }
}