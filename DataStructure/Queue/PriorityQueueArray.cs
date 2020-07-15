using System;
using System.Collections.Generic;

namespace DataStructure.Queue
{
    public class PriorityQueueArray<T>
    {
        private T[] data;

        private Comparison<T> Compare;

        public int Count;
        public bool Empty => Count == 0;

        public PriorityQueueArray(int count, Comparison<T> comp)
        {
            data = new T[count + 1]; // 1 based indexing
            data[0] = default;
            this.Compare = comp;
        }

        public PriorityQueueArray(int count, IComparer<T> comp) : this(count, comp.Compare) {}
        public PriorityQueueArray(int count) : this(count, Comparer<T>.Default) {}

        private int Left(int i) => 2 * i;
        private int Right(int i) => 2 * i + 1;
        private int Parent(int i) => i / 2;

        private void Swap(int i, int j)
        {
            T temp = data[i];
            data[i] = data[j];
            data[j] = temp;
        }

        private bool Less(int i, int j) => Compare(data[i], data[j]) <= 0;
       

        public void Enqueue(T d)
        {
            if (Count >= data.Length - 1)
                return;
            // Push back
            data[++Count] = d;
            Swim(Count);
        }

        public T Peek()
        {
            if (Count < 1)
                return data[0];
            return data[1];
        }

        public T Dequeue()
        {
            if (Count < 1)
                return data[0];
            T top = data[1];
            Swap(1, Count);
            --Count;
            Sink(1);
            return top;
        }

        // Search for right place bottom up
        private void Swim(int i)
        {
            while (i > 1)
            {
                int parent = Parent(i);

                if (Less(parent, i))
                    break;

                Swap(parent, i);

                i = parent;
            }
        }

        // Search for right place top down
        private void Sink(int i)
        {
            if (i > Count)
                return;

            while (true)
            {
                int j = Left(i);

                if (j > Count)
                    break;

                // If left is less that right, take right
                if (j < Count && Less(j + 1, j))
                    j++;

                // If current value is less target - stop
                if (!Less(j, i))
                    break;

                Swap(i, j);

                // Go down
                i = j;
            }  
        }

        // Search for right place top down
        private void SinkRecursive(int i)
        {
            int current = i;
            int left = Left(i);
            int right = Right(i);

            if (left < Count && Compare(data[left], data[current]) < 0)
                current = left;

            if (right < Count && Compare(data[right], data[current]) < 0)
                current = right;

            if (current != i)
            {
                Swap(i, current);
                SinkRecursive(current);
            }
        }
    }

}
