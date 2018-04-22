using System;
using System.Collections.Generic;

namespace DataStructure.Tree
{
    public class PriorityQueue<T>
    {
        private T[] data;

        private IComparer<T> comparer;

        public int Count;
        public bool Empty => Count == 0;
        public PriorityQueue(int count, IComparer<T> comp)
        {
            data = new T[count + 1]; // 1 based indexing
            this.comparer = comp;
        }

        public PriorityQueue(int count) : this(count, Comparer<T>.Default)
        {
        }

        private int Left(int i) => 2 * i;
        private int Right(int i) => 2 * i + 1;
        private int Parent(int i) => i / 2;

        private void Swap(int i, int j)
        {
            T temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }
       

        public void Enqueue(T d)
        {
            // 1. Push back
            data[++Count] = d;
            int i = Count;
            // Search for right place bottom up
            while (i > 1)
            {
                int parent = Parent(i);
                if (comparer.Compare(data[parent], data[i]) <= 0)
                {
                    break;
                }
                Swap(parent, i);
                i = parent;
            }
        }

        public T Dequeue()
        {
            if (Count < 1)
                return default(T);
            T top = data[1];
            Swap(1, Count);
            --Count;
            Heapify(1);
            return top;
        }

        private void Heapify(int i)
        {
            if (i > Count)
                return;
            int cur = i;
            int l = Left(i);
            int r = Right(i);
            if (l <= Count && comparer.Compare(data[l], data[cur]) <= 0)
                cur = l;
            if (r <= Count && comparer.Compare(data[r], data[cur]) <= 0)
                cur = r;
            if (cur != i)
            {
                Swap(cur, i);
                Heapify(cur);
            }
        }
    }

}
