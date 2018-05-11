using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.List.Doubly
{
	public interface IDoublyNode<T>
	{
		T Value { get; set; }
		IDoublyNode<T> PreviousNode { get; set; }
		IDoublyNode<T> NextNode { get; set; }
	}

	public class DoublyNode<T> : IDoublyNode<T>
	{
		public T Value { get; set; }
		public IDoublyNode<T> PreviousNode { get; set; }
		public IDoublyNode<T> NextNode { get; set; }
		public DoublyNode(T Value)
		{
			this.Value = Value;
		}
	}

	public interface IDoublyLinkedList<T> : IEnumerable<IDoublyNode<T>>
	{
		IDoublyNode<T> Head { get; }
		IDoublyNode<T> Tail { get; }
		IDoublyNode<T> Get(int n);
		IDoublyNode<T> Find(T Value);
		IDoublyNode<T> Add(T Value);
		IDoublyNode<T> Remove(T Value);
	}

	public class DoublyLinkedList<T> : IDoublyLinkedList<T>
	{
		public IDoublyNode<T> Head { get; private set; }
		public IDoublyNode<T> Tail { get; private set; }

		public DoublyLinkedList() { }

		public DoublyLinkedList(IDoublyNode<T> head, IDoublyNode<T> tail)
		{
			Head = head;
			Tail = tail;
		}

		public void Clear()
		{
			Head = null;
			Tail = null;
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

		public IDoublyNode<T> Get(int n)
		{
			if (Head == null)
                return null;

			var head = Head;
            while (head != null && n >= 0)
            {
                head = head.NextNode;
				--n;
            }
            return head;
		}

		public IDoublyNode<T> GetFromLast(int n)
        {
			if (Tail == null)
                return null;
			var tail = Tail;
			while (tail != null && n >= 0)
            {
				tail = tail.PreviousNode;
                --n;
            }
			return tail;
        }
        
		private IDoublyNode<T> FindPrevious(T Value)
        {
			// Empty list
			if (Head == null)
				return null;

            // Found the value at head
			if (Head.Value.Equals(Value))
				return null;

			// Find the element in the Next Node
			var head = Head;
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

		public IDoublyNode<T> Find(T Value)
		{
			if (Head == null)
                return null;

			var head = Head;
            while (head != null && !head.Value.Equals(Value))
            {
                head = head.NextNode;
            }
            return head;
        }

		public IDoublyNode<T> FindBack(T Value)
        {
			if (Tail == null)
                return null;

			var tail = Tail;
			while (tail != null && !tail.Value.Equals(Value))
            {
				tail = tail.PreviousNode;
            }
			return tail;
        }

		public IDoublyNode<T> Add(T Value)
		{
			if (Head == null)
			{
				Head = new DoublyNode<T>(Value);
				Tail = Head;
				return Head;
			}

			var head = Head;
			while (head.NextNode != null)
			{
				head = head.NextNode;
			}
			head.NextNode = new DoublyNode<T>(Value);
			Tail = head.NextNode;
			Tail.PreviousNode = head;
			return head;
		}

		public IDoublyNode<T> Remove(T Value)
		{
			if (Head == null)
                return null;

			if (Head.Value.Equals(Value))
			{
				var oldHead = Head;
				Head = Head.NextNode;
				Head.PreviousNode = null;
				return oldHead;
			}

			var previousNode = FindPrevious(Value);
			if (previousNode == null)
				return null;
			var nodeToRemove = previousNode.NextNode;
			previousNode.NextNode = previousNode.NextNode.NextNode;
			previousNode.NextNode.PreviousNode = previousNode;
			return nodeToRemove;
		}

		//public IDoublyNode<T> Reverse()
		//{
		//	var cur = Head;
		//	IDoublyNode<T> prev = null;
		//	while (cur != null)
		//	{
		//		var next = cur.NextNode;

		//		cur.NextNode = prev;
		//		prev = cur;
		//		cur = next;
		//	}
		//	Head = prev;
		//	return Head;
		//}

		//public IDoublyNode<T> RecursiveReverse()
		//{
		//	return RecursiveReverse(Head);
		//}

		//public IDoublyNode<T> RecursiveReverse(IDoublyNode<T> node)
		//{
		//	if (node == null)
		//		return null;
		//	if (node.NextNode == null)
		//		return node;
		//	var newHead = RecursiveReverse(node.NextNode);
		//	node.NextNode.NextNode = node;
		//	node.NextNode = null;
		//	return newHead;
		//}

		public IEnumerator<IDoublyNode<T>> GetEnumerator()
		{
			return new LinkedListEnumerator<T>(Head);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}

	public class LinkedListEnumerator<T> : IEnumerator<IDoublyNode<T>>
	{
		private IDoublyNode<T> _head;
		private IDoublyNode<T> _cursor;

		public LinkedListEnumerator(IDoublyNode<T> Cursor)
		{
			_cursor = _head = Cursor;
		}

		public bool MoveNext()
		{
			_cursor = _cursor.NextNode;
			return true;
		}

		object IEnumerator.Current => Current;
		public IDoublyNode<T> Current
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
