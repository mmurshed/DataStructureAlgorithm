using System;
namespace MDictionary
{
    public interface IKeyValuePair<K, V>
    {
        K Key { get; set; }
        V Value { get; set; }
    }
}
