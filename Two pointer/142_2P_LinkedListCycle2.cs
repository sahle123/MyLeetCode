// 142. Linked List Cycle II
// Tags: 2 pointer, Floyd's cycle detection algorithm, linked list
//
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
    public ListNode DetectCycle(ListNode head) 
    {
        // Edge case.
        if(head == null)
            return null;
        else if(head.next == null)
            return null;
        
        ListNode fastPtr = head;
        ListNode slowPtr = head;
        
        // Run till we find a match in both or a null.
        do
        {
            if(fastPtr.next == null)
                return null;
            else if(fastPtr.next.next == null)
                return null;
            
            fastPtr = fastPtr.next.next;
            slowPtr = slowPtr.next;
        } while(fastPtr != slowPtr);
        
        // If we found a match, set a pointer to head and walk one-by-one till they match again.
        // Return the match node.
        fastPtr = head;
        while(fastPtr != slowPtr)
        {
            fastPtr = fastPtr.next;
            slowPtr = slowPtr.next;
        }
        
        // Or we could've returned slowPtr.
        return fastPtr;
    }
}