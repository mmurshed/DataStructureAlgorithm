using System;
using System.Collections.Generic;

namespace DataStructure.Dictionary
{
    // Close address hash table
    public class OpenAddressDictionary<K, V> : IDictionary<K, V>
    {
        private KeyValuePair<K, V>[] dictionary;
        private IProbingAlgorithm<K> probingAlgorithm;

        public OpenAddressDictionary(int n, IProbingAlgorithm<K> probingAlgo)
        {
            dictionary = new KeyValuePair<K, V>[n];
            probingAlgorithm = probingAlgo;
        }

        private Tuple<KeyValuePair<K, V>, int> GetNode(K key)
        {
            int loc = probingAlgorithm.GetLocation(key, dictionary.Length);
            var node = dictionary[loc];

            int iteration = 0;
            while (node != null && !node.Key.Equals(key))
            {
                loc = probingAlgorithm.GetNextLocation(key, dictionary.Length, loc, iteration);
                node = dictionary[loc];
            }
            return new Tuple<KeyValuePair<K, V>, int> (node, loc);
        }

        public V Get(K key)
        {
            var node = GetNode(key);
            if(node.Item1 != null)
                return node.Item1.Value;
            return default(V);
        }

        public void Add(K key, V value)
        {
            var nodeLoc = GetNode(key);
            var node = nodeLoc.Item1;
            var loc = nodeLoc.Item2;

            if(node == null)
            {
                dictionary[loc] = new KeyValuePair<K, V>(key, value);
            }
        }

        public void Remove(K key)
        {
            var nodeLoc = GetNode(key);
            var node = nodeLoc.Item1;
            var loc = nodeLoc.Item2;
            if (node == null)
                return;
            dictionary[loc] = null;
        }

        public void Update(K key, V value)
        {
            var nodeLoc = GetNode(key);
            var node = nodeLoc.Item1;
            var loc = nodeLoc.Item2;

            if (node == null)
                return;
            node.Value = value;
        }
    }
}
