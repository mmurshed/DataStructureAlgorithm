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

        // Deprecated
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

        // Use this
        public ListNode ReverseKGroup3(ListNode head, int k)
        {
            if (k == 0)
                return head;
            int len = GetLength(head);
            if (k > len)
                return head;
            int count = k * (len / k);

            ListNode cur = head;
            ListNode prev = new ListNode(-1); // Dummy
            prev.next = head;

            while (count >= 0)
            {
                var res = ReverseKGroupOnce2(cur, k);

                var reversedHead = res.Item1;
                var next = res.Item2;

                prev.next = reversedHead;
                cur.next = next;

                prev = cur;
                cur = next;

                count--;
            }
            return prev.next;
        }
        private Tuple<ListNode, ListNode> ReverseKGroupOnce2(ListNode head, int k)
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
            return new Tuple<ListNode, ListNode>(prev, next);
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

        // Deprecated
        public ListNode ReverseKGroup2(ListNode head, int k)
        {
            if (k <= 1)
                return head;

            int length = GetLength(head);
            if (k > length)
                return head;
            
            int count = 0;
            int maxRev = k * (length / k);

            ListNode cur = head;
            ListNode prev = null;
            ListNode next = null;
            ListNode lastTail = null;
            ListNode curHead = head;
            ListNode newhead = null;

            bool process = false;

            while (true)
            {
                if ( process && count % k == 0 )
                {
                    if (newhead == null)
                        newhead = prev;

                    if(lastTail != null)
                        lastTail.next = prev;

                    lastTail = curHead;
                    curHead.next = cur;
                    curHead = cur;
                    prev = lastTail;
                    process = false;
                    continue;
                }

                if (count >= maxRev || cur == null)
                    break;
                
                next = cur.next;

                cur.next = prev;
                prev = cur;
                cur = next;

                count++;
                process = true;
            }
            if (newhead == null)
                newhead = prev;
            return newhead;
        }

        // Deprecated
        public ListNode ReverseKGroup4(ListNode head, int k)
        {
            if (k <= 1)
                return head;

            int length = GetLength(head);
            if (k > length)
                return head;

            int count = 0;
            int maxRev = k * (length / k);

            ListNode cur = head;
            ListNode prev = new ListNode(-1);
            prev.next = head;
            ListNode next = null;
            ListNode lastTail = null;
            ListNode curHead = head;

            bool process = false;

            while (true)
            {
                if (process && count % k == 0)
                {
                    if (lastTail != null)
                        lastTail.next = prev;

                    lastTail = curHead;
                    curHead.next = cur;
                    curHead = cur;
                    prev = lastTail;
                    process = false;
                    continue;
                }

                if (count >= maxRev || cur == null)
                    break;

                next = cur.next;

                cur.next = prev;
                prev = cur;
                cur = next;

                count++;
                process = true;
            }
            return prev.next;
        }

        public int GetLength(ListNode head)
        {
            int length = 0;
            ListNode cur = head;
            while(cur != null)
            {
                length++;
                cur = cur.next;
            }
            return length;
        }

    }
}
