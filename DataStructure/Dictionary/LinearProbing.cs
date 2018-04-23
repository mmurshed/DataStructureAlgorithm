using System;
namespace DataStructure.Dictionary
{
    public class LinearProbing<T> : IProbingAlgorithm<T>
    {
        public int GetLocation(T key, int size)
        {
            return key.GetHashCode() % size;
        }

        public int GetNextLocation(T key, int size, int location, int iteration)
        {
            int nextLocation = location + iteration + 1;
            if (nextLocation >= size)
                nextLocation -= size; // Wrap around
            return nextLocation;
        }
    }
}
