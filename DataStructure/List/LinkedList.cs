using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.List
{
	public interface INode<T>
	{
		T Value { get; set; }
		INode<T> NextNode { get; set; }
	}

	public class Node<T> : INode<T>
	{
		public T Value { get; set; }
		public INode<T> NextNode { get; set; }
		public Node(T Value)
		{
			this.Value = Value;
		}
	}

	public interface ILinkedList<T> : IEnumerable<INode<T>>
	{
		INode<T> Head { get; }
		INode<T> Get(int n);
		INode<T> Find(T Value);
		INode<T> Add(T Value);
		INode<T> Remove(T Value);
	}

	public class LinkedList<T> : ILinkedList<T>
	{
		public INode<T> Head { get; private set; }

		public LinkedList() : this(null) { }

		public LinkedList(INode<T> head)
		{
			Head = head;
		}

		public void Clear()
		{
			Head = null;       
		}

		public int Length
		{
			get
			{
				if (Head == null)
					return 0;

				int length = 0;

				var head = Head;
				while (head != null)
				{
					head = head.NextNode;
					length++;
				}
				return length;
			}
		}

		public INode<T> Get(int n)
		{
			if (Head == null)
                return null;

            INode<T> head = Head;
            while (head != null && n >= 0)
            {
                head = head.NextNode;
				--n;
            }
            return head;
		}

		public INode<T> GetFromLast(int n)
        {
            if (Head == null)
                return null;
            // Find the mth element first
			var desired = Head;
			var head = Head;
            while (head != null && n >= 0)
            {
                head = head.NextNode;
                --n;
            }

			if (head == null)
				return null;

            // Advance both point until we reach the end
			while (head != null)
			{
				head = head.NextNode;
				desired = head.NextNode;
			}

			return desired;
        }
        
		private INode<T> FindPrevious(T Value)
        {
			// Empty list
			if (Head == null)
				return null;

            // Found the value at head
			if (Head.Value.Equals(Value))
				return null;

            // Find the element in the Next Node
            INode<T> head = Head;
			while (head.NextNode != null && !head.NextNode.Value.Equals(Value))
            {
                head = head.NextNode;
            }
            // If the next node is empty, we didn't find it
			if (head.NextNode == null)
				return null;
			// Found the node in NextNode, return the head which points to the previous node
			return head;
        }

		public INode<T> Find(T Value)
		{
			if (Head == null)
                return null;
        
			INode<T> head = Head;
            while (head != null && !head.Value.Equals(Value))
            {
                head = head.NextNode;
            }
            return head;
        }

		public INode<T> Add(T Value)
		{
			if (Head == null)
			{
				Head = new Node<T>(Value);
				return Head;
			}
			INode<T> head = Head;
			while (head.NextNode != null)
			{
				head = head.NextNode;
			}
			head.NextNode = new Node<T>(Value);
			return head;
		}

		public INode<T> Remove(T Value)
		{
			if (Head == null)
                return null;

			if (Head.Value.Equals(Value))
			{
				var oldHead = Head;
				Head = Head.NextNode;
				return oldHead;
			}

			var previousNode = FindPrevious(Value);
			if (previousNode == null)
				return null;
			var nodeToRemove = previousNode.NextNode;
			previousNode.NextNode = previousNode.NextNode.NextNode;
			return nodeToRemove;
		}

		public ILinkedList<T> Reverse()
		{
			INode<T> cur = Head;
			INode<T> prev = null;
			while (cur != null)
			{
				INode<T> next = cur.NextNode;

				cur.NextNode = prev;
				prev = cur;
				cur = next;
			}
			Head = prev;
			return new LinkedList<T>(Head);
		}

		public ILinkedList<T> RecursiveReverse()
		{
			return new LinkedList<T>(RecursiveReverse(Head));
		}

		public INode<T> RecursiveReverse(INode<T> node)
		{
			if (node == null)
				return null;
			if (node.NextNode == null)
				return node;
			var newHead = RecursiveReverse(node.NextNode);
			node.NextNode.NextNode = node;
			node.NextNode = null;
			return newHead;
		}

		public IEnumerator<INode<T>> GetEnumerator()
		{
			return new LinkedListEnumerator<T>(Head);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}

	public class LinkedListEnumerator<T> : IEnumerator<INode<T>>
	{
		private INode<T> _head;
		private INode<T> _cursor;

		public LinkedListEnumerator(INode<T> Cursor)
		{
			_cursor = _head = Cursor;
		}

		public bool MoveNext()
		{
			_cursor = _cursor.NextNode;
			return true;
		}

		object IEnumerator.Current => Current;
		public INode<T> Current
		{
			get
			{
				return _cursor;
			}
		}

		public void Reset()
		{
			_cursor = _head;
		}

		public void Dispose()
		{
			_cursor = null;
			_head = null;
		}
	}
}
