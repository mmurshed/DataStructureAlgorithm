using System;
using System.Collections.Generic;

namespace DataStructurePractice.StringMatch
{
    public interface IStringMatch
    {
        IEnumerable<int> Search(char[] text, char[] pattern);
    }
}
