// 1971. Find if Path Exists in Graph
// Tags: disjoint set union, union find
//

impl Solution {
    pub fn valid_path(n: i32, edges: Vec<Vec<i32>>, source: i32, destination: i32) -> bool {
        
        // Edge cases + optimizations.
        if edges.is_empty() || edges.len() == 0 {
            return true;
        }
        else if edges[0].is_empty() || edges[0].len() == 0 {
            return true;
        }
        else if n == 1 {
            return true;
        }

        let mut paths = Dsu::new(n);

        // Create all unions so as to find all paths.
        for i in edges.iter() {
            paths.union(i[0], i[1]);
        }

        // Check if our source and destination are in the same graph.
        if paths.find(source) == paths.find(destination) {
            return true;
        }

        false
    }
}

struct Dsu {
    _root: Vec<i32>,
    _n: i32,
}

impl Dsu {

    fn new(n: i32) -> Self {
        let mut root = Vec::new();

        for i in 0..n {
            root.push(i);
        }

        return Dsu { _n: n, _root: root, };
    }

    fn find(&mut self, x: i32) -> i32 {
        let y = x as usize;
        if x == self._root[y] {
            return x;
        }
        else {
            // Path compression.
            self._root[y] = self.find(self._root[y]);
            return self._root[y];
        }
    }

    fn union(&mut self, mut a: i32, mut b: i32) -> bool {

        a = self.find(a);
        b = self.find(b);

        if a != b {
            self._root[a as usize] = b;
            return true;
        }
        false
    }
}