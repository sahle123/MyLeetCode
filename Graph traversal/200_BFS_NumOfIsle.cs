// 200. Number of Islands
// Tags: BFS

public class Solution
{
    private const char _searchedLand = 's';

    // Assumes that the jagged array is the same length for all elements.
    public int NumIslands(char[][] grid) 
    {
        int result = 0;

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                if(grid[i][j] == '1')
                {
                    result++;

                    Queue<Coordinate> coords = new();
                    coords.Enqueue(new Coordinate(j, i));

                    while(coords.Count > 0)
                        _4waySearch(ref coords, ref grid); 
                }
            }
        }
        return result;
    }

    private static void _4waySearch(ref Queue<Coordinate> queue, ref char[][] grid)
    {
        Coordinate coord = queue.Dequeue();

        //System.Console.WriteLine($"{coord.x.ToString()}, {coord.y.ToString()}");

        if(grid[coord.y][coord.x] == '1')
            grid[coord.y][coord.x] = _searchedLand;
        else
            return;

        // Search 1 up, down, left, right
        if ((coord.x - 1) >= 0)
            queue.Enqueue(new Coordinate((coord.x - 1), coord.y));
        if ((coord.x + 1) < grid[0].Length)
            queue.Enqueue(new Coordinate((coord.x + 1), coord.y));
        if ((coord.y - 1) >= 0)
            queue.Enqueue(new Coordinate(coord.x, (coord.y - 1)));
        if ((coord.y + 1) < grid.Length)
            queue.Enqueue(new Coordinate(coord.x, (coord.y + 1)));
    }
}

public class Coordinate
{
    public int x { get; set; }
    public int y { get; set; }
    
    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}