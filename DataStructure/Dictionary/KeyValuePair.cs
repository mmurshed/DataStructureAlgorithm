using System;
namespace MDictionary
{
    public class KeyValuePair<K, V> : IKeyValuePair<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }

        public KeyValuePair(K key, V value)
        {
            Key = key;
            Value = value;
        }
    }
}
