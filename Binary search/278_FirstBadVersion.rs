// 278. First Bad Version
// Tags: binary search
//

// The API isBadVersion is defined for you.
// isBadVersion(version:i32)-> bool;
// to call it use self.isBadVersion(version)

impl Solution {
    pub fn first_bad_version(&self, n: i32) -> i32 {

        // Edge case.
        if n == 1 {
            return 1;
        }

        let (mut low, mut high, mut mid) = (0, n, 0);

        while low < high {
            mid = low + ((high - low)/2);

            if self.isBadVersion(mid) {
                high = mid;
            }
            else {
                low = mid + 1;
            }
        }

        low
    }
}