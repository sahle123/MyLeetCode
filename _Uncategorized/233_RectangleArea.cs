// 223. Rectangle Area
// Tags: math
//

public class Solution 
{
    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2) 
    {
        // Calculate area of both rectangles.
        int combinedArea = Math.Abs((ax2 - ax1)*(ay2 - ay1)) + Math.Abs((bx2 - bx1)*(by2 - by1));

        // Find the overlapping area and subtract that from the combined area to get our final answer.

        // Find overlap for x.
        int min_x = Math.Max(Math.Min(ax1, ax2), Math.Min(bx1, bx2));
        int max_x = Math.Min(Math.Max(ax1, ax2), Math.Max(bx1, bx2));

        if(min_x >= max_x)
            return combinedArea;

        // Find overlap for y.
        int min_y = Math.Max(Math.Min(ay1, ay2), Math.Min(by1, by2));
        int max_y = Math.Min(Math.Max(ay1, ay2), Math.Max(by1, by2));
        
        if(min_y > max_y)
            return combinedArea;

        // Else remove the shared area once so it is not counted twice due to 
        // both rectangles overlapping the same area.
        return combinedArea - Math.Abs((max_x - min_x) * (max_y - min_y));
    }
}