// 141. Linked List Cycle
// Tags: Two pointer, Floyd's cycle detection algorithm.
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution 
{
    public bool HasCycle(ListNode head) 
    {
        // Edge cases.
        if(head == null)
            return false;
        else if (head.next == null)
            return false;
        
        ListNode fastPtr = head;
        ListNode slowPtr = head;
        
        // Run till we find a match in both or a null
        // If we exit this while loop, then a loop in the
        // linked list was detected.
        do
        {
            if(fastPtr.next == null)
                return false;
            else if (fastPtr.next.next == null)
                return false;
            
            fastPtr = fastPtr.next.next;
            slowPtr = slowPtr.next;
        } while(fastPtr != slowPtr);
        
        return true;
    }
}