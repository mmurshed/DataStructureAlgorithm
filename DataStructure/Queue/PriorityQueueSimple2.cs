using System;
using System.Collections.Generic;

namespace DataStructure.Queue
{
    public class PriorityQueueSimple2
    {
        private List<int> d;
        public int Count => d.Count - 1;
        private readonly Comparison<int> Compare;

        private int Left(int i) => 2 * i;
        private int Parent(int i) => i / 2;

        private bool Less(int i, int j) => Compare(d[i], d[j]) <= 0;

        private void Swap(int i, int j)
        {
            int t = d[i];
            d[i] = d[j];
            d[j] = t;
        }

        public PriorityQueueSimple2(Comparison<int> comp = null)
        {
            d = new List<int> { int.MinValue };
            Compare = comp ?? Comparer<int>.Default.Compare;
        }

        public int Peek()
        {
            if (Count < 1)
                return d[0];
            return d[1];
        }


        public void Enqueue(int v)
        {
            d.Add(v);
            Swim(Count);
        }

        public int Dequeue()
        {
            if (Count < 1)
                return d[0];
            int v = d[1];
            Swap(1, Count);
            d.RemoveAt(Count);
            Sink(1);
            return v;
        }

        private void Swim(int i)
        {
            while (i > 1)
            {
                int p = Parent(i);
                if (Less(p, i))
                    break;
                Swap(i, p);
                i = p;
            }
        }

        private void Sink(int i)
        {
            if (i > Count)
                return;
            while (true)
            {
                int j = Left(i);

                if (j > Count)
                    break;

                // Select right if less
                if (j < Count && Less(j+1, j))
                    j++;

                // Stop if not less
                if (!Less(j, i))
                    break;

                Swap(i, j);
                i = j;
            }
        }

    }

}
