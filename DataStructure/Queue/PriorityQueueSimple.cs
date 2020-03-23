using System;
using System.Collections.Generic;

namespace DataStructure.Queue
{
    public class PriorityQueueSimple
    {
        private int[] d;
        public int count { get; private set;}

        private int Left(int i) => 2 * i;
        private int Parent(int i) => i / 2;

        private bool Less(int i, int j) => d[i] > d[j];

        private void Swap(int i, int j)
        {
            int t = d[i];
            d[i] = d[j];
            d[j] = t;
        }

        public PriorityQueueSimple(int n)
        {
            d = new int[n + 1];
            count = 0;
        }


        public void Enqueue(int v)
        {
            if (count >= d.Length - 1)
                return;
            d[++count] = v;
            Swim(count);
        }

        public int Dequeue()
        {
            if (count < 1)
                return -1;
            int v = d[1];
            Swap(1, count);
            --count;
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
            if (i > count)
                return;
            while (true)
            {
                int j = Left(i);

                if (j > count)
                    break;

                // Select right if less
                if (j < count && Less(j + 1, j))
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
