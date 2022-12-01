// 206. Reverse Linked List
// Tags: linked list, fundamentals
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

// This solution here is still quite crappy, but I made it all myself.
// Uses a stack data type.
impl Solution {
    pub fn reverse_list(head: Option<Box<ListNode>>) -> Option<Box<ListNode>> {
        // Edge case.
        if let None = head {
            return head;
        }

        let mut result = Box::new(ListNode::new(i32::MIN));
        let mut result_index = &mut result;
        let mut head_curr = head;

        let mut stack: Vec<i32> = Vec::new();

        // Build-up stack
        while head_curr.is_some() {
            
            // Push to stack and go to next node.
            if let Some(mut index) = head_curr.take() {
                stack.push(index.val);
                head_curr = index.next.take();
            }
        }

        // Pop-off stack and append it to result.
        while stack.len() > 0 {
            
            if let Some(v) = stack.pop() {
                result_index = result_index.next.get_or_insert(Box::new(ListNode::new(v)));
                //println!("{}", v);
            }

            // match stack.pop() {
            //     Some(v) => {
            //         result_index = result_index.next.get_or_insert(Box::new(ListNode::new(v)));
            //     },
            //     None => { return result.next; }
            // }
        }
        result.next
    }
}