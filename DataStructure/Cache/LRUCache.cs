using System;
using System.Collections.Generic;

namespace DataStructure.Cache
{
    /*
     * How to implement LRU caching scheme? What data structures should be used?
     * We are given total possible page numbers that can be referred. We are also given cache (or memory) size (Number of page frames that cache can hold at a time). The LRU caching scheme is to remove the least recently used frame when the cache is full and a new page is referenced which is not there in cache. Please see the Galvin book for more details (see the LRU page replacement slide here).
     * 
     * We use two data structures to implement an LRU Cache.

1. Queue which is implemented using a doubly linked list. The maximum size of the queue will be equal to the total number of frames available (cache size).The most recently used pages will be near front end and least recently pages will be near rear end.

2. A Hash with page number as key and address of the corresponding queue node as value.
When a page is referenced, the required page may be in the memory. If it is in the memory, we need to detach the node of the list and bring it to the front of the queue.
If the required page is not in the memory, we bring that in memory. In simple words, we add a new node to the front of the queue and update the corresponding node address in the hash. If the queue is full, i.e. all the frames are full, we remove a node from the rear of queue, and add the new node to the front of queue.

Example – Consider the following reference string :

1, 2, 3, 4, 1, 2, 5, 1, 2, 3, 4, 5
Find the number of page faults using least recently used (LRU) page replacement algorithm with 3 page frames.
Explanation –

Given 3 page frames, so we take size of Queue is 3 initially. Queue is empty.
________________
|    |    |    |
----------------

Input: 1
    ________________
    | 1  |    |    |
   /-----\----------
  /       \
Front     Rear
pointer   pointer

Input: 2 (Every new input will be front as defined by LRU)
    ________________
    | 2  | 1  |    |
   /--------\-------
  /          \
Front        Rear
pointer      pointer

Input 3:
    ________________
    | 3  | 2  | 1  |
   /-------------\--
  /               \
Front             Rear
pointer           pointer

Input 4: (Since all frames are full, we remove a node from the rear of the queue and add the new node to the front of the queue.)
    ________________
    | 4  | 3  | 2  |
   /-------------\--
  /               \
Front             Rear
pointer           pointer

Input 1: (Since all frames are full, we remove a node from the rear of the queue and add the new node to the front of the queue.)
    ________________
    | 1  | 4  | 3  |
   /-------------\--
  /               \
Front             Rear
pointer           pointer

Input 2: (Since all frames are full, we remove a node from the rear of the queue and add the new node to the front of the queue.)
    ________________
    | 2  | 1  | 4  |
   /-------------\--
  /               \
Front             Rear
pointer           pointer

Input 5: (Since all frames are full, we remove a node from the rear of the queue and add the new node to the front of the queue.)
    ________________
    | 5  | 2  | 1  |
   /-------------\--
  /               \
Front             Rear
pointer           pointer

Input 1: (Since present in memory, so bring it to the front of the queue. This is called hit.)
    ________________
    | 1  | 5  | 2  |
   /-------------\--
  /               \
Front             Rear
pointer           pointer

Input 2: (Since present in memory, so bring it to the front of the queue. This is called hit.)
    ________________
    | 2  | 1  | 5  |
   /-------------\--
  /               \
Front             Rear
pointer           pointer

Input 3: (Since all frames are full, we remove a node from the rear of the queue and add the new node to the front of the queue.)
    ________________
    | 3  | 2  | 1  |
   /-------------\--
  /               \
Front             Rear
pointer           pointer

Input 4: (Since all frames are full, we remove a node from the rear of the queue and add the new node to the front of the queue.)
    ________________
    | 4  | 3  | 2  |
   /-------------\--
  /               \
Front             Rear
pointer           pointer

Input 5: (Since all frames are full, we remove a node from the rear of the queue and add the new node to the front of the queue.)
    ________________
    | 5  | 4  | 3  |
   /-------------\--
  /               \
Front             Rear
pointer           pointer

So, we have only 2 hits and 10 page faults using LRU page replacement algorithm.
        */
    public class LRUCache
    {
        private class Node
        {
            public int key;
            public int value;
            public Node (int k, int v)
            {
                key = k;
                value = v;
            }
        }

        private LinkedList<Node> queue;
        private Dictionary<int, LinkedListNode<Node>> dictionary;
        private readonly int size;
        public LRUCache(int n)
        {
            size = n;
            queue = new LinkedList<Node>();
            dictionary = new Dictionary<int, LinkedListNode<Node>>();
        }

        public void Refer(int x)
        {
            LinkedListNode<Node> node = null;
            if(dictionary.ContainsKey(x))
            {
                node = dictionary[x];
                queue.Remove(node);
            }
            else
            {
                var n = new Node(x, 0);
                node = new LinkedListNode<Node>(n);
                dictionary[x] = node;
            }

            if (queue.Count >= size)
            {
                dictionary.Remove(queue.Last.Value.key);
                queue.RemoveLast();
            }
            if(node != null)
                queue.AddFirst(node);
        }

        public int Get(int key)
        {
            if (!dictionary.ContainsKey(key))
                return -1;

            LinkedListNode<Node> node = dictionary[key];
            queue.Remove(node);

            if (queue.Count >= size)
            {
                dictionary.Remove(queue.Last.Value.key);
                queue.RemoveLast();
            }

            queue.AddFirst(node);
            return node.Value.value;
        }

        public void Put(int key, int value)
        {
            if (!dictionary.ContainsKey(key))
            {
                var n = new Node(key, value);
                var node = new LinkedListNode<Node>(n);
                dictionary[key] = node;


                if (queue.Count >= size)
                {
                    dictionary.Remove(queue.Last.Value.key);
                    queue.RemoveLast();
                }

                queue.AddFirst(node);
            }
            else
            {
                LinkedListNode<Node> node = dictionary[key];
                node.Value.value = value;
                queue.Remove(node);
                queue.AddFirst(node);
            }
        }
    }
}
