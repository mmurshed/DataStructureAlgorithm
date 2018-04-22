using System;
namespace DataStructure.Dictionary
{
    public interface IKeyValuePair<K, V>
    {
        K Key { get; set; }
        V Value { get; set; }
    }
}
