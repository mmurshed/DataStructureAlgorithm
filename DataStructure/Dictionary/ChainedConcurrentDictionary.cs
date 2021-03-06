﻿using System;
using System.Collections.Generic;

namespace DataStructure.Dictionary
{
    // Close address hash table
    public class ChainedConcurrentDictionary<K, V> : IConcurrentDictionary<K, V>
    {
        private LinkedList<KeyValuePair<K, V>>[] dictionary;

		private object lockObj = new object(); 

		public ChainedConcurrentDictionary(int n)
        {
            dictionary = new LinkedList<KeyValuePair<K, V>>[n];
        }

        private int GetLocation(K key)
        {
            return key.GetHashCode() % dictionary.Length;
        }

        private LinkedListNode<KeyValuePair<K, V>> GetNode(K key)
        {
			lock (lockObj)
			{           
				int loc = GetLocation(key);
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
            var node = GetNode(key);
			lock (lockObj)
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

			lock (lockObj)
			{
				if (dictionary[loc] == null)
				{
					dictionary[loc] = new LinkedList<KeyValuePair<K, V>>();
				}

				// Verify if it alreday exists
				var node = GetNode(key);
				if (node != null)
					return;

				dictionary[loc].AddLast(new KeyValuePair<K, V>(key, value));
			}
        }

        public void Remove(K key)
        {
			lock (lockObj)
			{
				var node = GetNode(key);
				if (node == null)
					return;
				int loc = GetLocation(key);
				if (dictionary[loc] != null)
					dictionary[loc].Remove(node);
			}
        }

        public void Update(K key, V value)
        {
			lock (lockObj)
			{
				var node = GetNode(key);
				if (node == null)
					return;
				node.Value.Value = value;
			}
        }
    }
}
