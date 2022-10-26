public class Solution 
{
    // Assumes that the jagged array is the same length for
    // all elements.
    public int[][] FloodFill(int[][] image, int sr, int sc, int color) 
    {
        int originalColor = image[sr][sc];
        
        System.Console.WriteLine("Starting...");
        
        Queue<Coordinate> coords = new();
        coords.Enqueue(new Coordinate(sc, sr));
        
        while(coords.Count > 0)
            _4waySearch(ref coords, ref image, originalColor, color);
        
        return image;
    }
    
    private static void _4waySearch(ref Queue<Coordinate> queue, ref int[][] image, int originalColor, int newColor)
    {
        Coordinate coord = queue.Dequeue();
        
        System.Console.WriteLine($"{coord.x.ToString()}, {coord.y.ToString()}");
        
        // Edge case to prevent infinite loops
        if(image[coord.y][coord.x] == newColor)
            return;
        
        // If color is same as the original, change to the new color
        if (image[coord.y][coord.x] == originalColor)
            image[coord.y][coord.x] = newColor;
        else
            return;
        
        // Search 1 up, down, left, right
        if ((coord.x - 1) >= 0)
            queue.Enqueue(new Coordinate((coord.x - 1), coord.y));
        
        if ((coord.x + 1) < image[0].Length)
            queue.Enqueue(new Coordinate((coord.x + 1), coord.y));
        
        if ((coord.y - 1) >= 0)
            queue.Enqueue(new Coordinate(coord.x, (coord.y - 1)));
        
        if ((coord.y + 1) < image.Length)
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