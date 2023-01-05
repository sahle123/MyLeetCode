// 452. Minimum Number of Arrows to Burst Balloons
// Tags: greedy, sorting, visual
// 

public class Solution 
{
    public int FindMinArrowShots(int[][] points) 
    {
        // Edge case.
        if(points == null 
            || points.Length == 0
            || points[0] == null
            || points[0].Length == 0)
        {
            return -1;
        }

        // So as along as all the constraints are fulfilled, we will always need 
        // to make at least 1 shot to burst all of the balloons.
        int result = 1;

        // Sort array from x_0 ascending.
        // i.e. sort by our first index in the sub-array.
        Array.Sort(points, (x0, x1) => { return x0[0] - x1[0]; });

        // foreach(var p in points)
        // {
        //     Console.WriteLine($"[{p[0]}, {p[1]}]");
        // }

        // Find range, continue or increment.
        int lowerBound = Int32.MinValue;
        int upperBound = Int32.MaxValue;
        foreach(var p in points)
        {
            // Still in range. Update bounds to smallest, available range.
            if(lowerBound <= p[1] && upperBound >= p[0])
            {
                lowerBound = Math.Max(lowerBound, p[0]);
                upperBound = Math.Min(upperBound, p[1]);
            }
            // Out of range. Need another shot and to reset the bounds.
            else
            {
                result += 1;
                lowerBound = p[0];
                upperBound = p[1];
            }
        }

        return result;
    }
}