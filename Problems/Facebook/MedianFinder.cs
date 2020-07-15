using System;
using DataStructure.Queue;

namespace Problems.Facebook
{
    public class MedianFinder
    {
        PriorityQueueSimple2 minq;
        PriorityQueueSimple2 maxq;

        public MedianFinder()
        {
            minq = new PriorityQueueSimple2((x, y) => x.CompareTo(y));
            maxq = new PriorityQueueSimple2((x, y) => y.CompareTo(x));
        }

        public void AddNum(int num)
        {
            if (minq.Count == 0 || minq.Peek() < num)
                minq.Enqueue(num);
            else
                maxq.Enqueue(num);
            Balance();
        }

        public double FindMedian()
        {
            if (minq.Count > maxq.Count)
                return minq.Peek();
            else if (maxq.Count > minq.Count)
                return maxq.Peek();
            return (minq.Peek() + maxq.Peek()) / 2.0;
        }

        private void Balance()
        {
            while (minq.Count > maxq.Count + 1)
                maxq.Enqueue(minq.Dequeue());

            while (maxq.Count > minq.Count + 1)
                minq.Enqueue(maxq.Dequeue());
        }
    }
}
