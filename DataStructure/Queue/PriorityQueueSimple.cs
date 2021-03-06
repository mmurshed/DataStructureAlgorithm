﻿using System;
using System.Collections.Generic;

namespace DataStructure.Queue
{
    public class PriorityQueueSimple
    {
        private int[] d;
        public int count { get; private set;}
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

        public PriorityQueueSimple(int n, Comparison<int> comp = null)
        {
            d = new int[n + 1];
            d[0] = int.MinValue;
            count = 0;
            Compare = comp ?? Comparer<int>.Default.Compare;
        }


        public void Enqueue(int v)
        {
            if (count >= d.Length - 1)
                return;
            d[++count] = v;
            Swim(count);
        }

        public int Peek()
        {
            if (count < 1)
                return d[0];
            return d[0];
        }

        public int Dequeue()
        {
            int v = Peek();
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
