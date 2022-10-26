// 21. Merged Two Sorted Lists
// Tags: linked lists, fundamentals
// Time: O(n + m)
// Space: O(n)
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution 
{
    public ListNode MergeTwoLists(ListNode l1, ListNode l2) 
    {
        // Optimizations.
        if(l1 == null)
            return l2;
        if(l2 == null)
            return l1;
        
        // This List's initialized node will be snipped at the end.
        ListNode head = new(int.MinValue); 
        ListNode result = head;
        
        // Traverse linked lists until both of them is null.
        while(l1 != null && l2 != null)
        {
            if(l2.val <= l1.val)
            {
                head.next = l2; // Storing address of l2.
                l2 = l2.next;   // Changing pointer of l2 to l2.next. i.e. next LL item.
            }
            else // l2.val > l1.val
            {
                head.next = l1;
                l1 = l1.next;
            }
            
            // Traverse list to next node.
            head = head.next;
        }
        
        // Wrap up on remaining linked list and add it to
        // the rest of the head list.
        while(l1 != null)
        {
            head.next = l1;
            l1 = l1.next;
            head = head.next;
        } 
        while(l2 != null)
        {
            head.next = l2;
            l2 = l2.next;
            head = head.next;
        }
        
        // Remove the initialized node since it was not part 
        // of the original lists passed in.
        return result.next;
    }
}