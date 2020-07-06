using System;
using System.Collections.Generic;
using System.Linq;

namespace Problems.Facebook
{
    public class RandomizedCollection
    {
        List<int> list; // Item
        Dictionary<int, HashSet<int>> dict; // Item -> Index
        Random rnd;

        /** Initialize your data structure here. */
        public RandomizedCollection()
        {
            list = new List<int>();
            dict = new Dictionary<int, HashSet<int>>();
            rnd = new Random();
        }

        /** Inserts a value to the collection. Returns true if the collection did not already contain the specified element. */
        public bool Insert(int val)
        {
            list.Add(val);

            bool newentry = false;

            if (!dict.ContainsKey(val))
            {
                dict.Add(val, new HashSet<int>());
                newentry = true;
            }

            dict[val].Add(list.Count - 1);

            return newentry;
        }

        private void Swap(int i, int j)
        {
            if (i == j)
                return;
            if (list[i] == list[j])
                return;
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        /** Removes a value from the collection. Returns true if the collection contained the specified element. */
        public bool Remove(int val)
        {
            if (!dict.ContainsKey(val))
                return false;

            int idx = dict[val].First();

            if (idx != list.Count - 1 && list[idx] != list[list.Count-1])
            {
                Swap(idx, list.Count - 1);
                dict[list[idx]].Remove(list.Count - 1);
                dict[list[idx]].Add(idx);
            }

            dict[val].Remove(idx);
            if (!dict[val].Any())
                dict.Remove(val);

            list.RemoveAt(list.Count - 1);
            return true;
        }

        /** Get a random element from the collection. */
        public int GetRandom()
        {
            return list[rnd.Next(list.Count)];
        }
    }

    /**
     * Your RandomizedCollection object will be instantiated and called as such:
     * RandomizedCollection obj = new RandomizedCollection();
     * bool param_1 = obj.Insert(val);
     * bool param_2 = obj.Remove(val);
     * int param_3 = obj.GetRandom();
     */
}
