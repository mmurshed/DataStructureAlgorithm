using System;
namespace DataStructure.Dictionary
{
    public interface IDictionary<K, V>
    {
        V Get(K key);
        void Add(K key, V value);
        void Remove(K key);
        void Update(K key, V value);
    }
}
