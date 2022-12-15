// 872. Leaf-Similar Trees.
// Tags: tree, DFS
//

// Definition for a binary tree node.
// #[derive(Debug, PartialEq, Eq)]
// pub struct TreeNode {
//   pub val: i32,
//   pub left: Option<Rc<RefCell<TreeNode>>>,
//   pub right: Option<Rc<RefCell<TreeNode>>>,
// }
// 
// impl TreeNode {
//   #[inline]
//   pub fn new(val: i32) -> Self {
//     TreeNode {
//       val,
//       left: None,
//       right: None
//     }
//   }
// }
use std::rc::Rc;
use std::cell::RefCell;

type OptNode = Option<Rc<RefCell<TreeNode>>>;

impl Solution {
    pub fn leaf_similar(root1: OptNode, root2: OptNode) -> bool {

        // Edge cases.
        if let None = root1 {
            return false;
        }
        if let None = root2 {
            return false;
        }

        let (mut leaves1, mut leaves2) = (Vec::new(), Vec::new());
        Solution::dfs(&root1, &mut leaves1);
        Solution::dfs(&root2, &mut leaves2);

        leaves1 == leaves2
    }

    fn dfs(node: &OptNode, leaves: &mut Vec<i32>) {
        if let Some(curr) = node {
            let curr = curr.borrow();

            // Leaf case.
            if curr.left.is_none() && curr.right.is_none() {
                leaves.push(curr.val);
                return;
            }

            Solution::dfs(&curr.left, leaves);
            Solution::dfs(&curr.right, leaves);
        }
    }
}