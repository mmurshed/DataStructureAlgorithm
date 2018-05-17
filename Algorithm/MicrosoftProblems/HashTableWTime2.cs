using System;
using System.Collections.Generic;

namespace Algorithm.MicrosoftProblems
{
	public class HashTableWTime2<K, T, V>
		where T: IComparable<T>
		where V: IComparable<V>
    {
		private class Node
        {
            public T time;
            public V value;
            public Node left;
			public Node right;
            
            public Node(T t, V v)
            {
                value = v;
                time = t;
            }
        }

		private void Insert(Node root, Node child)
        {
			int compare = root.time.CompareTo(child.time);
			if (compare > 0)
            {
                if (root.left == null)
                {
                    root.left = child;
                }
                else
                {
                    Insert(root.left, child);
                }
            }
			else if (compare < 0)
            {
                if (root.right == null)
                {
                    root.right = child;
                }
                else
                {
                    Insert(root.right, child);
                }
            }
        }

		private V Find(Node root, T t, V closestMatch, T closestT)
        {
            if (root == null)
            {
                return closestMatch;
            }
			int compare = root.time.CompareTo(t);
			if (compare > 0)
            {
				return Find(root.left, t, closestMatch, t);
            }
			else if (compare < 0)
            {
				int compareClosest = closestT.CompareTo(root.time);
				if (compareClosest > 0)
                {
                    closestMatch = root.value;
                    closestT = root.time;
                }
				return Find(root.right, t, closestMatch, closestT);
            }
            else
            {
                return root.value;
            }

        }

		private Dictionary<K, Node> hashTable;
        
		public HashTableWTime2()
		{
			hashTable = new Dictionary<K, Node>();
        }

		public void Add(K key, T time, V value)
		{
			var n = new Node(time, value);
			if (!hashTable.ContainsKey(key))
			{
				hashTable.Add(key, n);
				return;
			}

			var root = hashTable[key];
			Insert(root, n);

		}

		public V Get(K key, T time)
		{
			if (!hashTable.ContainsKey(key))
				return default(V);
			var root = hashTable[key];
			return Find(root, time, root.value, root.time);
		}
    }
}
