using System.Collections;
using System.Collections.Generic;

namespace DataStructure.List
{
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

		object IEnumerator.Current => _cursor;

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
