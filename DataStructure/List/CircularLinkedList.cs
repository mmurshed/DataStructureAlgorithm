using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.List
{
	public class CircularLinkedList<T> : ILinkedList<T>
	{
		public INode<T> Head { get; private set; }

		public CircularLinkedList() {
			Head = null;
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
				while (head.NextNode != Head)
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

            var head = Head;
            while (head.NextNode != Head && n >= 0)
            {
                head = head.NextNode;
				--n;
            }
            return head;
		}
        
		public INode<T> Find(T Value)
		{
			if (Head == null)
                return null;
        
			var head = Head;
            while (head.NextNode != Head && !head.Value.Equals(Value))
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
				Head.NextNode = Head;
				return Head;
			}

			var head = Head;
			while (head.NextNode != Head)
			{
				head = head.NextNode;
			}
			head.NextNode = new Node<T>(Value) { NextNode = Head };

			return head;
		}

		public void Remove(T Value)
		{
			if (Head == null)
                return;

			var head = Head;
			INode<T> prev = null;
			while (head.NextNode != Head && !head.Value.Equals(Value))
			{
				prev = head;
				head = head.NextNode;
			}

			if(head.Value.Equals(Value) && prev != null)
				prev.NextNode = prev.NextNode.NextNode;
		}

	}
}
