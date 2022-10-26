// 206. Reverse Linked List
// Tags: linked lists, fundamentals, stack, pointers.
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
    // Iterative solution.
    public ListNode ReverseList(ListNode head)
    {
        // Edge case.
        if (head == null)
            return null;

        ListNode prev = null;

        while (head != null)
        {
            ListNoded next = head.next;

            head.next = prev;
            prev = head;
            head = next;

            /* first time
             * next = 2->3->4->5
             * head.next = null
             * prev = 1
             * head = 2->3->4->5
             */
            /* second time
             * next = 3->4->5
             * head.next = 1
             * prev = 2->1
             * head = 3->4->5
             */
            /* next time
             * next = 4->5
             * head.next = 2->1
             * prev = 3->2->1
             * head = 4->5
             */
            /* next time
             * next = 5
             * head.next = 3->2->1
             * prev = 4->3->2->1
             * head = 5
             */
            /* the last time
             * next = null
             * head.next = 4->3->2->1
             * prev = 5->4->3->2->1
             * head = null
             */
        }

        return prev;
    }

    // Another type of solution using a Stack.
    public ListNode ReverseListWithStack(ListNode head)
    {
        if(head == null)
            return null;
        
        // Saving our new root node to return.
        ListNode result = new();

        // Our index we will use to go through the LL.
        ListNode index = result;

        Stack<int> stack = new();

        // Populate stack with all values in order.
        while(head != null)
        {
            stack.Push(head.val);
            head = head.next;
        }

        while(stack.Count > 0)
        {
            ListNode node = new(stack.Pop());

            // Store pointer to new node and traverse.
            index.next = node;
            index = index.next;
        }
        return result.next;
    }
}