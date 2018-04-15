using System;

namespace Graph
{
    class ConsoleWriterVisitor<T> : IVisitor<IVertex<T>>
    {
        public void PreVisit(IVertex<T> value)
        {
            Console.WriteLine(value.Value.ToString());
        }

        public void PostVisit(IVertex<T> value)
        {
            
        }
    }
}
