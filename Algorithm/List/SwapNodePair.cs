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
			Node ans = new Node(0);
			var pre = ans;
            ans.next = head;
            
			while (head != null && head.next != null)
            {
                Swap(pre, head, head.next);
                pre = pre.next.next;
                head = head.next;
            }
            return ans.next;
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
