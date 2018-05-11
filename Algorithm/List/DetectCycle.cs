using System;
namespace Algorithm.List
{
	//https://www.geeksforgeeks.org/detect-and-remove-loop-in-a-linked-list/
	public class Node
	{
		public int value;
		public Node next;
	}

    public class DetectCycle
    {
		public bool ContainsCycle(Node head)
		{
			var slow = head;
			var fast = head;

			while(slow != null || fast != null)
			{
				slow = slow.next;
				fast = fast.next?.next;
				if (slow.value == fast.value)
					return true;
			}
			return false;
		}
    }
}
