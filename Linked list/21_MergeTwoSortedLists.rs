// 21. Merge Two Sorted Lists
// Tags: linked lists, fundamentals
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
impl Solution {
    pub fn merge_two_lists(l1: Option<Box<ListNode>>, l2: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
        // Optimizations.
        if let None = l1 {
            return l2;
        }
        else if let None = l2 {
            return l1;
        }

        let mut result: Box<ListNode> = Box::new(ListNode::new(i32::MIN));
        let mut head_curr = &mut result;
        let mut l1_head = l1;
        let mut l2_head = l2;

        // Traverse linked lists until one of them is null
        while l1_head.is_some() && l2_head.is_some() {
            let mut l1_ptr = l1_head.take();
            let mut l2_ptr = l2_head.take();

            // Check if both pointers have a value.
            if let (Some(mut l1_curr), Some(mut l2_curr)) = (l1_ptr, l2_ptr) {

                if l2_curr.val <= l1_curr.val {
                    // change our current l2 head to the next node in its chain.
                    l2_head = l2_curr.next.take();
                    // Since l1_head lost ownership back in the l1_ptr assignment, we are returning
                    // it's value + ownership to l1_head which we need to continue the while loop.
                    l1_head = Some(l1_curr);
                    // Set the next value to the current l2 node.
                    head_curr = head_curr.next.get_or_insert(l2_curr);
                }
                // l1_curr.val < l2_curr.val
                else {
                    // Same logic as the previous if statement, but with the l2 and l1 assignments
                    // reversed.
                    l1_head = l1_curr.next.take();
                    l2_head = Some(l2_curr);
                    head_curr = head_curr.next.get_or_insert(l1_curr);
                }
            }
        }

        // Append either linked list to the end of our result if it has 
        // some remaining values.
        if l1_head.is_some() {
            head_curr.next = l1_head;
        }
        else if l2_head.is_some() {
            head_curr.next = l2_head;
        }

        // Remove the initialized node since it was not part 
        // of the original lists passed in.
        result.next
    }
}