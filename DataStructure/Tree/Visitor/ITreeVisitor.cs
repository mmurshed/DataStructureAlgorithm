﻿using System;

namespace DataStructure.Tree
{
    public interface ITreeVisitor<K, V>
        where K : IComparable<K>
    {
        void Visit(ITreeNode<K, V> node);
    }
}
