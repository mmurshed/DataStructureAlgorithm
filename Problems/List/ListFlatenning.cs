using System;
namespace Algorithm.List
{
	public class MNode
	{
        public int value;
		public MNode next;
		public MNode previous;
		public MNode child;
    }

	// https://www.geeksforgeeks.org/flatten-a-linked-list-with-next-and-child-pointers/
    public class ListFlatenning
    {
		public Tuple<MNode, MNode> Flatten(MNode head, MNode tail)
		{
            MNode start = head;
			while(start != null)
			{
				if(start.child != null)
				{
					tail.next = start.child;
					start.child.previous = tail;

					MNode newtail = start.child;
					while(newtail.next != null)
					{
						newtail = newtail.next;
					}
					tail = newtail;
				}
				start = start.next;
			}

			return new Tuple<MNode, MNode>(head, tail);
		}

		public Tuple<MNode, MNode> Unflatten(MNode head, MNode tail)
		{
			MNode end = tail;
			while(end != null)
			{
				if(end.child != null)
				{
					tail = end.child.previous;
					if(end.child.previous != null)
					    end.child.previous.next = null;
					end.child.previous = null;
				}
				end = end.previous;
			}
			return new Tuple<MNode, MNode> (head, tail);
		}
    }
}
