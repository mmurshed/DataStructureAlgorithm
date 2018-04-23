using System;
namespace DataStructure.Dictionary
{
    public interface IProbingAlgorithm<T>
    {
        int GetLocation(T key, int size);
        int GetNextLocation(T key, int size, int currentLocation, int iteration);
    }
}
