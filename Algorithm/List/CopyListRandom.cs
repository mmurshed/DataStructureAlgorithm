using System;
using System.Collections.Generic;

// https://www.geeksforgeeks.org/a-linked-list-with-next-and-arbit-pointer/
namespace Algorithm.List
{
	public class RandomNode
	{
		public int value;
		public RandomNode next;
		public RandomNode random;

		public RandomNode(int v)
		{
			value = v;
		}

	}

	// https://leetcode.com/problems/copy-list-with-random-pointer/description/
	// https://www.geeksforgeeks.org/a-linked-list-with-next-and-arbit-pointer/
    public class CopyListRandom
    {
		// O(n) mem and space
		public RandomNode DeepCopy(RandomNode head)
		{
			if (head == null)
				return null;
			RandomNode newhead = new RandomNode(head.value);

			var dictionary = new Dictionary<RandomNode, RandomNode>();
			dictionary.Add(head, newhead);

			var cur = head;
			var newcur = newhead;

            // copy
			while(cur.next != null)
			{
				newcur.next = new RandomNode(cur.next.value);

				newcur = newcur.next;
				cur = cur.next;
				dictionary.Add(cur, newcur);
			}

            // Restore
			cur = head;
			newcur = newhead;

            while (cur != null)
            {
				if(cur.random != null)
				    newcur.random = dictionary[cur.random];	
                newcur = newcur.next;
                cur = cur.next;
            }

			return newhead;
		}

		// O(n) mem and O(1) space
        public RandomNode DeepCopy2(RandomNode head)
        {
            if (head == null)
                return null;

            var cur = head;

            // copy and insert new node right after the old node
            // 1 -> 2 -> 3 becomes 1 -> 1 -> 2 -> 2 -> 3 -> 3
            while (cur.next != null)
            {
                var newnode = new RandomNode(cur.value);

				newnode.next = cur.next;
				cur.next = newnode;
				cur = newnode.next;
            }

            // Copy random link
            cur = head;

			while (cur.next != null)
            {
				cur.next.random = cur.random.next;
				cur = cur.next.next;
            }

			// Detach new list;
			// 1 -> 1 -> 2 -> 2 -> 3 -> 3 becomes two copies of 1 -> 2 -> 3
			cur = head;
			var newhead = cur.next;
			var newcur = newhead;

			while (cur.next != null)
            {
				cur.next = cur.next.next;
				newcur.next = newcur.next.next;
            }

            return newhead;
        }
    }
}
