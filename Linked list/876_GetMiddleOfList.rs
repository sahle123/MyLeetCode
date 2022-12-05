// 876. Middle of the Linked List
// Tags: linked list
//

// Definition for singly-linked list.
// #[derive(PartialEq, Eq, Clone, Debug)]
// pub struct ListNode {
//   pub val: i32,
//   pub next: Option<Box<ListNode>>
// }
// 
// impl ListNode {
//   #[inline]
//   fn new(val: i32) -> Self {
//     ListNode {
//       next: None,
//       val
//     }
//   }
// }

// Recursive solution
impl Solution {
    pub fn middle_node(head: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
        let depth: usize = (Solution::get_linked_list_size(&head) / 2);

        return Solution::get_n_deep_node(head, depth);
    }

    // Note: Since there is no &self parameter, this method is static.
    pub fn get_linked_list_size(node: &Option<Box<ListNode>>) -> usize {
        match node {
            None => return 0,
            Some(n) => {
                return Solution::get_linked_list_size(&n.next) + 1;
            }
        }
    }

    // Returns an N-deep node in the linked list.
    pub fn get_n_deep_node(node: Option<Box<ListNode>>, depth: usize) -> Option<Box<ListNode>> {
        match node {
            None => {
                println!("Unexpected. We went beyond the linked lists depth: {}", depth);
                return None;
            },
            Some(n) => {
                if depth == 0 {
                    return Some(n);
                }
                return Solution::get_n_deep_node(n.next, (depth - 1));
            }
        }
    }
}