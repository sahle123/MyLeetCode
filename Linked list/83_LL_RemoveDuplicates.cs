// 83. Remove Duplicates from Sorted List
// Tags: Linked list, Hash map
// Space: O(n), worst case
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
    public ListNode DeleteDuplicates(ListNode head) 
    {
        
        // Edge case.
        if(head == null)
            return null;
        
        // Keeps track of all entries. If an entry already exits,
        // then we need to remove it from the linked list.
        Dictionary<int, int> dict = new();
        
        ListNode curr = head;
        ListNode prev = head;
        
        while(curr != null)
        {
            // Remove logic.
            if(dict.ContainsKey(curr.val))
            {
                if(curr.next != null)
                    prev.next = curr.next;
                else
                    prev.next = null;
            }
            
            // Add value to dictionary
            else 
            {
                dict.Add(curr.val, 1);
                prev = curr;
            }
            curr = curr.next;
        }
        
        return head;
    }
}