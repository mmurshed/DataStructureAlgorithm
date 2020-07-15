using System;
using DataStructure.Queue;

namespace Algorithm.GoogleProblems
{
    public class MergeKListsPQClass
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        private class QueueNode
        {
            public ListNode node;
            public int location;
            public QueueNode(ListNode n, int loc)
            {
                node = n;
                location = loc;
            }
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
                return null;

            ListNode head = null;
            ListNode cur = null;

            // min queue
            var priorityQueue = new PriorityQueuList<QueueNode>( (x, y) => x.node.val - y.node.val);

            for (int i = 0; i < lists.Length; i++)
            {
                if(lists[i] != null)
                    priorityQueue.Enqueue(new QueueNode(lists[i], i));
            }

            while (!priorityQueue.Empty)
            {
                var minNode = priorityQueue.Dequeue();
                var loc = minNode.location;
                var newNode = minNode.node;

                if (head == null)
                {
                    cur = newNode;
                    head = newNode;
                }
                else
                {
                    cur.next = newNode;
                    cur = cur.next;
                }

                lists[loc] = lists[loc].next;
                if(lists[loc] != null)
                    priorityQueue.Enqueue(new QueueNode(lists[loc], loc)); 
            }
            return head;
        }
    }
}
