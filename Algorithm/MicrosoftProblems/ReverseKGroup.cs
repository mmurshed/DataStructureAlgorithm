using System;
using System.Collections.Generic;

namespace Algorithm.MicrosoftProblems
{
    // https://leetcode.com/problems/reverse-nodes-in-k-group/description/
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class ReverseKGroupClass
    {
        public ListNode CreateList(int[] items)
        {
            if (items == null || items.Length == 0)
                return null;
            ListNode head = new ListNode(items[0]);
            ListNode cur = head;
            for (int i = 1; i < items.Length; i++)
            {
                cur.next = new ListNode(items[i]);
                cur = cur.next;
            }

            return head;
        }

        public int[] GetArray(ListNode head)
        {
            ListNode cur = head;
            List<int> list = new List<int>();
            while(cur != null)
            {
                list.Add(cur.val);
                cur = cur.next;
            }
            return list.ToArray();
        }

        public ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k == 0)
                return head;
            ListNode cur = head;
            ListNode newhead = null;
            ListNode prev = null;

            while(cur != null)
            {
                var res = ReverseKGroupOnce(cur, k);

                var reversedHead = res.Item1;
                var next = res.Item2;
                int itemRemaining = res.Item3;

                if (itemRemaining > 0)
                {
                    res = ReverseKGroupOnce(reversedHead, k);
                    reversedHead = res.Item1;
                    if (newhead == null)
                        newhead = reversedHead;
                    break;
                }

                if (newhead == null)
                    newhead = reversedHead;

                if (prev != null)
                    prev.next = reversedHead;
                cur.next = next;
                prev = cur;
                cur = next;
            }
            return newhead;
        }

        private Tuple<ListNode, ListNode, int> ReverseKGroupOnce(ListNode head, int k)
        {
            ListNode prev = null;
            ListNode cur = head;
            ListNode next = null;

            while (cur != null && k > 0)
            {
                next = cur.next;
                cur.next = prev;
                prev = cur;
                cur = next;
                k--;
            }
            head = prev;
            return new Tuple<ListNode, ListNode, int>(prev, next, k);
        }
    }
}
