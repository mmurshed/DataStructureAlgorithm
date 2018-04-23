using System;
namespace DataStructure.Dictionary
{
    public class QuadraticProbing<T> : IProbingAlgorithm<T>
    {
        public int GetLocation(T key, int size)
        {
            return key.GetHashCode() % size;
        }

        public int GetNextLocation(T key, int size, int location, int iteration)
        {
            // n + i^2 
            // n + 1, n + 4,     n + 9
            // n + 1, n + 1 + 3, n + 1 + 3 + 5
            int nextLocation = location + 2 * iteration + 1;
            if (nextLocation >= size)
                nextLocation -= size; // Wrap around
            return nextLocation;
        }
    }
}
