using System;
using System.Collections.Generic;

namespace DataStructure.String
{
    public interface IStringMatch
    {
        IEnumerable<int> Search(char[] text, char[] pattern);
    }
}
