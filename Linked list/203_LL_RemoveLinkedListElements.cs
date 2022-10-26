// 203. Removed Linked List Elements
// Tags: Linked lists
// Space: O(1)
// Time: O(n)

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
    public ListNode RemoveElements(ListNode head, int val) 
    {
        if(head == null)
            return null;
        
        ListNode curr = head;
        ListNode prev = head;
        
        while(curr != null)
        {
            // Remove node logic.
            if(curr.val == val)
            {
                if(curr.next != null)
                    prev.next = curr.next;
                
                // Case: end of the linked list
                else
                    prev.next = null;
                
            }
            // Else, keep traversing.
            else
                prev = curr;
            
            curr = curr.next;
        }
        
        // Edge case: See if we have a single node left and it is the same value
        // as the value we are to delete.
        if(head.val == val)
        {
            if(head.next == null)
                head = null;
            else
                head = head.next;
        } 
        
        return head;
    }
}