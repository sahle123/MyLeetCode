// 938. Range Sum of BST
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

// Credit or this code goes to: 
// https://leetcode.com/problems/range-sum-of-bst/solutions/2885511/rust-elixir-skip-useless-subtrees/
use std::rc::Rc;
use std::cell::RefCell;

type OptNode = Option<Rc<RefCell<TreeNode>>>;

impl Solution {
    pub fn range_sum_bst(root: OptNode, low: i32, high: i32) -> i32 {
        Self::recurse(&root, low, high)
    }

    fn recurse(node: &OptNode, low: i32, high: i32) -> i32 {
        match node.as_ref() {
            None => 0,
            Some(n) => {
                let b = n.borrow();
                let mut ans = 0;

                if b.val >= low && b.val <= high {
                    ans += b.val;
                }
                if b.val < high {
                    ans += Self::recurse(&b.right, low, high);
                }
                if b.val > low {
                    ans += Self::recurse(&b.left, low, high);
                }

                ans
            }
        }
    }
}