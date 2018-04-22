using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.List
{
	public interface ILinkedListNode<T>
	{
		T Value { get; set; }
		ILinkedListNode<T> NextNode { get; set; }
	}

	public class LinkedListNode<T> : ILinkedListNode<T>
	{
		public T Value { get; set; }
		public ILinkedListNode<T> NextNode { get; set; }
		public LinkedListNode(T Value)
		{
			this.Value = Value;
		}
	}


	public interface ILinkedList<T> : IEnumerable<ILinkedListNode<T>>
	{
		ILinkedListNode<T> Head { get; }
		ILinkedListNode<T> Get(int n);
		ILinkedListNode<T> Find(T Value);
		ILinkedListNode<T> Add(T Value);
		ILinkedListNode<T> Remove(T Value);
	}

	public class LinkedList<T> : ILinkedList<T>
	{
		private ILinkedListNode<T> _head;
		public ILinkedListNode<T> Head { get { return _head; } }

		public LinkedList() : this(null) { }

		public LinkedList(ILinkedListNode<T> Head)
		{
			_head = Head;
		}

		public ILinkedListNode<T> Get(int n)
		{
			return null;
		}
		public ILinkedListNode<T> Find(T Value)
		{
			return null;
		}
		public ILinkedListNode<T> Add(T Value)
		{
			if (_head == null)
			{
				_head = new LinkedListNode<T>(Value);
				return _head;
			}
			ILinkedListNode<T> head = _head;
			while (head.NextNode != null)
			{
				head = head.NextNode;
			}
			head.NextNode = new LinkedListNode<T>(Value);
			return head;
		}

		public ILinkedListNode<T> Remove(T Value)
		{
			return null;
		}

		public ILinkedList<T> Reverse()
		{
			ILinkedListNode<T> cur = _head;
			ILinkedListNode<T> prev = null;
			while (cur != null)
			{
				ILinkedListNode<T> next = cur.NextNode;

				cur.NextNode = prev;
				prev = cur;
				cur = next;
			}
			_head = prev;
			return new LinkedList<T>(_head);
		}

		public ILinkedList<T> RecursiveReverse()
		{
			return new LinkedList<T>(RecursiveReverse(_head));
		}

		public ILinkedListNode<T> RecursiveReverse(ILinkedListNode<T> node)
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

		public IEnumerator<ILinkedListNode<T>> GetEnumerator()
		{
			return new LinkedListEnumerator<T>(_head);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}

	public class LinkedListEnumerator<T> : IEnumerator<ILinkedListNode<T>>
	{
		private ILinkedListNode<T> _head;
		private ILinkedListNode<T> _cursor;

		public LinkedListEnumerator(ILinkedListNode<T> Cursor)
		{
			_cursor = _head = Cursor;
		}

		public bool MoveNext()
		{
			_cursor = _cursor.NextNode;
			return true;
		}

		object IEnumerator.Current => Current;
		public ILinkedListNode<T> Current
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
