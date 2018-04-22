using System;

namespace DataStructure.Graph
{
    public class ConsoleWriterVisitor<T> : IVisitor<IVertex<T>>
    {
        public void PreVisit(IVertex<T> value)
        {
            Console.WriteLine(value.Value.ToString());
        }

        public void Visit(IVertex<T> value)
        {

        }

        public void PostVisit(IVertex<T> value)
        {
            
        }
    }
}
