// 1926. Nearest Exit from Entrance in Maze.
// Tags: BFS
//
// Note:
//  . = open space
//  + = wall
public class Solution 
{
    private const char _searchedSpace = 's';
    private readonly int[,] dirs = new int[,] { {-1,0}, {0,1}, {1,0}, {0,-1} };

    // Assuming jagged array is uniform across
    // all members.
    public int NearestExit(char[][] maze, int[] entrance) 
    {
        // Edge cases.
        if(maze == null || maze.Length == 0)
            return -1;
        else if(entrance == null || entrance.Length == 0)
            return -1;

        int m = maze.Length;
        int n = maze[0].Length;
        Queue<(int row, int col)> queue = new();

        queue.Enqueue((entrance[0], entrance[1]));

        int step = 0;
        while(queue.Count > 0)
        {
            int currentSize = queue.Count;
            for(int i = 0; i < currentSize; i++)
            {
                (int x, int y) curr = queue.Dequeue();

                // Check if we are at the edge.
                if(curr.x == 0 || curr.y == 0 || curr.x == (m - 1) || curr.y == (n - 1))
                {
                    // Make sure this edge is not an entrance.
                    // If so, we found our shortest exit.
                    if(curr.x != entrance[0] || curr.y != entrance[1])
                        return step;
                }

                // Queue up in 4 directions, if applicable for each direction.
                for(int d = 0; d < dirs.GetLength(0); d++)
                {
                    int nextRow = curr.x + dirs[d, 0];
                    int nextCol = curr.y + dirs[d, 1];

                    // Make sure we are not at an edge
                    if(nextRow >= 0 && nextCol >= 0 && nextRow < m && nextCol < n)
                    {
                        if(maze[nextRow][nextCol] == '.')
                        {
                            queue.Enqueue((nextRow, nextCol));
                            maze[nextRow][nextCol] = _searchedSpace;
                        }
                    }
                }
            }
            
            step++;
        }

        // Worst-case scenario, could not find a path.
        return -1;
    }
}