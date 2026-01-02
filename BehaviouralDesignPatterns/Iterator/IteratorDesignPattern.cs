/*
===========================================================
ITERATOR DESIGN PATTERN (Behavioral Pattern)
===========================================================

DEFINITION:
Iterator Pattern provides a way to access elements of a
collection sequentially WITHOUT exposing its internal structure.

WHY WE NEED IT:
- To separate traversal logic from collection logic
- To avoid exposing internal data (List, Array, etc.)
- To provide a common way to iterate different collections

REAL .NET EXAMPLE:
IEnumerable and IEnumerator used by foreach
*/

namespace IteratorPatternDemo
{
    // -------------------------------------------------------
    // 1. ITERATOR INTERFACE
    // -------------------------------------------------------
    // This defines how iteration will happen
    // Client uses this interface, not concrete iterator
    public interface IIterator<T>
    {
        bool HasNext();   // Checks if next element exists
        T Next();         // Returns next element
    }

    // -------------------------------------------------------
    // 2. AGGREGATE (COLLECTION) INTERFACE
    // -------------------------------------------------------
    // This interface exposes only iterator creation
    // NOT internal collection structure
    public interface IAggregate<T>
    {
        IIterator<T> CreateIterator();
    }

    // -------------------------------------------------------
    // 3. CONCRETE ITERATOR
    // -------------------------------------------------------
    // This class handles the traversal logic
    // It knows HOW to move through the collection
    public class NameIterator : IIterator<string>
    {
        private readonly List<string> _names; // Internal collection
        private int _position = 0;             // Tracks current index

        public NameIterator(List<string> names)
        {
            _names = names;
        }

        // Checks if more elements are available
        public bool HasNext()
        {
            return _position < _names.Count;
        }

        // Returns current element and moves pointer forward
        public string Next()
        {
            return _names[_position++];
        }
    }

    // -------------------------------------------------------
    // 4. CONCRETE COLLECTION
    // -------------------------------------------------------
    // This class stores data
    // It does NOT expose List directly
    public class NameCollection : IAggregate<string>
    {
        // Internal data structure (hidden from client)
        private readonly List<string> _names = new()
        {
            "Dhru",
            "Amit",
            "Rahul"
        };

        // Factory method to return iterator
        public IIterator<string> CreateIterator()
        {
            return new NameIterator(_names);
        }
    }

    // -------------------------------------------------------
    // 5. CLIENT CODE
    // -------------------------------------------------------
    // Client does NOT know whether collection is List, Array, etc.
    // Client only uses iterator
    class Program
    {
        static void Main(string[] args)
        {
            // Creating collection object
            IAggregate<string> collection = new NameCollection();

            // Getting iterator from collection
            IIterator<string> iterator = collection.CreateIterator();

            // Traversing using iterator
            while (iterator.HasNext())
            {
                Console.WriteLine(iterator.Next());
            }

            Console.ReadLine();
        }
    }
}

/*
===========================================================
INTERVIEW NOTES (IMPORTANT)
===========================================================

1. Client does NOT access List<string> directly
2. Traversal logic is separated from collection
3. You can add another iterator (ReverseIterator) without
   changing client code
4. foreach in C# internally uses Iterator pattern

ONE-LINE INTERVIEW ANSWER:
Iterator Pattern allows sequential access to a collection
without exposing its internal structure.

WHEN TO USE:
- When collection internals must be hidden
- When multiple traversal strategies are needed
- When you want clean, decoupled code
*/
