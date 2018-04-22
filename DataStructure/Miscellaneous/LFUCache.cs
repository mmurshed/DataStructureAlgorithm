using System;
using System.Collections.Generic;

namespace Miscellaneous
{
    /*
     * Least Frequently Used
     * 
     * https://github.com/papers-we-love/papers-we-love/blob/master/caching/a-constant-algorithm-for-implementing-the-lfu-cache-eviction-scheme.pdf
     * https://deepakvadgama.com/blog/lfu-cache-in-O(1)/
     * 
     * LFU Cache Algorithm
     * 
     * LFU is a cache eviction algorithm called least frequently used cache. In 
     * LFU we check the old page as well as the frequency of that page and if 
     * frequency of the page is lager than the old page we cant remove it and 
     * if we all old pages are having same frequency then take last i.e FIFO 
     * method for that and remove page.
     * 
     * Data structure
     * 
     * It requires three data structures.
     * 
     * 1. One is a hash table which is used to cache the key/values so that 
     * given a key we can retrieve the cache entry at O(1).
     * 
     * 2. Second one is a double linked list for each frequency of access. The
     * max frequency is capped at the cache size to avoid creating more and 
     * more frequency list entries. If we have a cache of max size 4 then we 
     * will end up with 4 different frequencies. Each frequency will have a 
     * double linked list to keep track of the cache entries belonging to that 
     * particular frequency.
     * 
     * 3. The third data structure would be to somehow link these frequencies 
     * lists. It can be either an array or another linked list so that on 
     * accessing a cache entry it can be easily promoted to the next frequency 
     * list in time O(1). 
    */
    public class LFUCache
    {
        public class LFUNode
        {
            public int Key;
            public int Value;
            public LFUNode(int key, int value)
            {
                Key = key;
                Value = value;
            }
        }
        private Dictionary<int, LinkedListNode<LFUNode>> Values; // Key = item key, Value = Linked list node of item value
        private Dictionary<int, int> Counts; // Key = item key, Value = Frequency count
        private SortedDictionary<int, LinkedList<LFUNode>> Frequencies; // Key = Frequency count, Value = Frequency list

        private readonly int size;
        public LFUCache(int n)
        {
            size = n;
            Frequencies = new SortedDictionary<int, LinkedList<LFUNode>>();
            Values = new Dictionary<int, LinkedListNode<LFUNode>>();
            Counts = new Dictionary<int, int>();
        }

        private LFUNode GetNode(int key)
        {
            if (!Values.ContainsKey(key))
                return null;

            // Get the linked list node
            var node = Values[key];

            // Mover item from one frequency list to another
            int frequency = Counts[key];

            // Get the frequency list
            var freqList = Frequencies[frequency];
            // Remove from it
            freqList.Remove(node);
            // Remove the list if the list is empty
            if (freqList.Count == 0)
            {
                Frequencies.Remove(frequency);
            }

            int newFrequency = frequency + 1;
            // Create new node for the new frequency value, if it does not exist
            if (!Frequencies.ContainsKey(newFrequency))
                Frequencies.Add(newFrequency, new LinkedList<LFUNode>());
            // Insert the node to the new frequency list
            Frequencies[newFrequency].AddLast(node);
            // Update the frequency
            Counts[key] = newFrequency;

            return node.Value;
        }

        public int Get(int key)
        {
            if (!Values.ContainsKey(key))
                return -1;

            var node = GetNode(key);

            return node.Value;
        }

        public void Put(int key, int value)
        {
            if(!Values.ContainsKey(key))
            {
                // Evict
                if (Values.Count == size)
                {
                    Evict();
                }

                Add(key, value);
            }
            else
            {
                Update(key, value);
            }
        }

        private void Add(int key, int value)
        {
            if (Values.Count == size)
                return; // size zero or eviction didn't succeed

            var newkv = new LFUNode(key, value);
            var node = new LinkedListNode<LFUNode>(newkv);

            var newFreq = 1;
            Values.Add(key, node);
            Counts.Add(key, newFreq);
            if (!Frequencies.ContainsKey(newFreq))
                Frequencies.Add(newFreq, new LinkedList<LFUNode>());
            // Insert the node to the new frequency list
            Frequencies[newFreq].AddLast(node);            
        }

        private void Evict()
        {
            var en = Frequencies.GetEnumerator();
            if (!en.MoveNext())
                return;

            var kv = en.Current;
            int lowestCount = kv.Key;

            var nodeToDelete = kv.Value.First;
            kv.Value.RemoveFirst();

            if (kv.Value.Count == 0)
            {
                Frequencies.Remove(lowestCount);
            }
            Values.Remove(nodeToDelete.Value.Key);
            Counts.Remove((nodeToDelete.Value.Key));            
        }

        private void Update(int key, int value)
        {
            var node = GetNode(key);
            if (node != null)
                node.Value = value;
        }
    }
}
