// 876. Middle of the Linked List
// Tags: linked list
//
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
    public ListNode MiddleNode(ListNode head) 
    {
        int depth = (GetLinkedListSize(head) / 2) + 1;
        return GetNDeepNode(head, depth);
    }
    
    // Gets the size of the linked list.
    public static int GetLinkedListSize(ListNode node)
    {
       if(node.next == null)
           return 1;
        
        return GetLinkedListSize(node.next) + 1;
    }
    
    // Gets an N-deep node in the linked list.
    public static ListNode GetNDeepNode(ListNode node, int depth)
    {
        if(depth <= 1)
            return node;
        
        return GetNDeepNode(node.next, --depth);
    }
}