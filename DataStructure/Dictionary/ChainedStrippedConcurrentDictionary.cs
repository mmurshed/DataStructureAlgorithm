using System;
using System.Collections.Generic;

namespace DataStructure.Dictionary
{
    // Close address hash table
    public class ChainedStrippedConcurrentDictionary<K, V> : IConcurrentDictionary<K, V>
    {
        private LinkedList<KeyValuePair<K, V>>[] dictionary;

		private object[] lockObjs; 

		public ChainedStrippedConcurrentDictionary(int n)
        {
            dictionary = new LinkedList<KeyValuePair<K, V>>[n];
			lockObjs = new object[n];
        }

        private int GetLocation(K key)
        {
            return key.GetHashCode() % dictionary.Length;
        }

        private LinkedListNode<KeyValuePair<K, V>> GetNode(K key)
        {
			int loc = GetLocation(key);
			lock (lockObjs[loc])
			{
                var list = dictionary[loc];
				var node = list?.First;

				while (node != null)
				{
					if (node.Value.Key.Equals(key))
					{
						return node;
					}
					node = node.Next;
				}
			}
            return null;
        }

        public V Get(K key)
        {
			int loc = GetLocation(key);
            var node = GetNode(key);
			lock (lockObjs[loc])
			{
				if (node != null)
					return node.Value.Value;
			}
            // Not found
            return default(V);
        }

        public void Add(K key, V value)
        {
            int loc = GetLocation(key);
            
			lock (lockObjs[loc])
			{
				if (dictionary[loc] == null)
				{
					dictionary[loc] = new LinkedList<KeyValuePair<K, V>>();
				}
			}
			// Verify if it alreday exists
            var node = GetNode(key);
            if (node != null)
                return;
			lock (lockObjs[loc])
			{
				dictionary[loc].AddLast(new KeyValuePair<K, V>(key, value));
			}
        }

        public void Remove(K key)
        {
			int loc = GetLocation(key);
			var node = GetNode(key);
            if (node == null)
                return;
			lock (lockObjs[loc])
			{
				if (dictionary[loc] != null)
					dictionary[loc].Remove(node);
			}
        }

        public void Update(K key, V value)
        {
			int loc = GetLocation(key);
			var node = GetNode(key);
			if (node == null)
				return;
			lock (lockObjs[loc])
            {
                node.Value.Value = value;
			}
        }
    }
}
