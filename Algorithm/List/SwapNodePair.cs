using System;
namespace Algorithm.List
{

    public class SwapNodePair
    {
		public class Node
        {
            public int value;
            public Node next;
            public Node(int v)
            {
                value = v;
            }
        }

		public Node SwapPairsR(Node head)
        {
            if (head == null || head.next == null)
                return head;

            Node result = head.next;
            head.next = SwapPairsR(head.next.next);
            result.next = head;

            return result;
        }

		public Node SwapPairs(Node head)
        {
            var cur = head;
            var prev = new Node(0);
            prev.next = head;
            
			while (cur != null && cur.next != null)
            {
                var next = cur.next;
                Swap(prev, cur, next);
                prev = prev.next.next;
                cur = cur.next;
            }
            return prev.next;
        }

        private void Swap(Node pre, Node a, Node b)
        {
            Node next = b.next;
            pre.next = b;
            b.next = a;
            a.next = next;
        }
	}
}
