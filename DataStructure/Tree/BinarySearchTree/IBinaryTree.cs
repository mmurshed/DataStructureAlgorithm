using System;

namespace DataStructure.Tree
{
    public interface IBinaryTree<K, V>
        where K: IComparable<K>
    {
        V Get(K Key);
        bool Update(K Key, V Value);
        bool Add(K Key, V Value);
        bool Remove(K Key);
    }
}
