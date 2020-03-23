using System;
using System.Collections.Generic;


namespace Algorithm.MicrosoftProblems
{
	public class HashTableWTime<K, T, V>
    {
		private Dictionary<K, SortedDictionary<T, V>> hashTable;
        public HashTableWTime()
        {
			hashTable = new Dictionary<K, SortedDictionary<T, V>>();
        }

		public void Add(K key, T time, V value)
		{
			if (!hashTable.ContainsKey(key))
			{
				hashTable.Add(key, new SortedDictionary<T, V>());
				hashTable[key].Add(time, value);
				return;
			}
			
			if (hashTable[key].ContainsKey(time))
			{
				// collision
				hashTable[key][time] = value;
			}
			else
			{
				hashTable[key].Add(time, value);
			}
		}

		public V Get(K key, T time)
		{
			if (!hashTable.ContainsKey(key))
				return default(V);
            if (!hashTable[key].ContainsKey(time))
				return default(V);

			return hashTable[key][time];
		}
    }
}
