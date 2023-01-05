// 452. Minimum Number of Arrows to Burst Balloons
// Tags: greedy, sorting, visual
// 

use std::cmp;
impl Solution {
    pub fn find_min_arrow_shots(mut points: Vec<Vec<i32>>) -> i32 {
        let mut result = 1;

        // Sort array from x_0 ascending.
        // i.e. sort by our first index in the sub-array.
        points.sort_by(|x0, x1| x0.cmp(x1));

        // Find range, continue or increment.
        let mut lower_bound: i32 = i32::MIN;
        let mut upper_bound: i32 = i32::MAX;

        for p in points.iter() {
            if lower_bound <= p[1] && upper_bound >= p[0] {
                lower_bound = cmp::max(lower_bound, p[0]);
                upper_bound = cmp::min(upper_bound, p[1]);
            }
            else {
                result += 1;
                lower_bound = p[0];
                upper_bound = p[1];
            }
        }

        result
    }
}