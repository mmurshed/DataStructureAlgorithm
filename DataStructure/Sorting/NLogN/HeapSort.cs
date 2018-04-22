using System;
namespace Sorting
{
    public class HeapSort<T> : SortBase<T>
        where T: IComparable<T>
    {
        public override void Sort(T[] data)
        {
            //var pq = new PriorityQueue.PriorityQueue<T>(new PriorityQueue.MinComparer<T>());
            //for (int i = 0; i < data.Length; i++)
            //{
            //    pq.Enqueue(data[i]);
            //}

            //for (int i = 0; i < data.Length; i++)
            //{
            //    data[i] = pq.Dequeue();
            //}
        }
    }
}
