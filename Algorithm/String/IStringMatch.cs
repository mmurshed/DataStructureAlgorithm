using System;
using System.Collections.Generic;

namespace Algorithm.String
{
    public interface IStringMatch
    {
        IEnumerable<int> Search(char[] text, char[] pattern);
    }
}
