using System;
using System.Collections.Generic;

namespace MDictionary
{
    // Close address hash table
    public class ChainedDictionary<K, V> : IDictionary<K, V>
    {
        private LinkedList<KeyValuePair<K, V>>[] dictionary;
        public ChainedDictionary(int n)
        {
            dictionary = new LinkedList<KeyValuePair<K, V>>[n];
        }

        private int GetLocation(K key)
        {
            return key.GetHashCode() % dictionary.Length;
        }

        public V Get(K key)
        {
            var list = dictionary[GetLocation(key)];
            foreach (var item in list)
            {
                if (item.Key.Equals(key))
                    return item.Value;
            }
            // Not found
            return default(V);
        }

        public void Add(K key, V value)
        {
            int loc = GetLocation(key);
            if(dictionary[loc] == null)
            {
                dictionary[loc] = new LinkedList<KeyValuePair<K, V>>();
            }

            // Verify if it alreday exists
            var list = dictionary[GetLocation(key)];
            foreach (var item in list)
            {
                if (item.Key.Equals(key))
                    return; // Found
            }

            list.AddLast(new KeyValuePair<K, V>(key, value));
        }

        public void Remove(K key)
        {
            int loc = GetLocation(key);
            if (dictionary[loc] == null)
                return;

            var list = dictionary[GetLocation(key)];
            var node = list.First;

            while(node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    list.Remove(node);
                    break;
                }
                node = node.Next;
            }
        }

        public void Update(K key, V value)
        {
            int loc = GetLocation(key);
            if (dictionary[loc] == null)
            {
                dictionary[loc] = new LinkedList<KeyValuePair<K, V>>();
            }

            var list = dictionary[GetLocation(key)];
            var node = list.First;

            while (node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    node.Value.Value = value;
                    break;
                }
                node = node.Next;
            }
        }
    }
}
