/*
BRIDGE PATTERN
--------------
Purpose:
- Decouple abstraction from implementation so both can vary independently.
- Prevents class explosion when there are multiple dimensions of change.

When to use:
- You foresee independent changes in abstraction and implementation.
- You want to avoid deep inheritance hierarchies.

Difference from Adapter:
- Bridge is a design-time pattern (planned upfront).
- Adapter is a retrofit pattern used to make existing incompatible code work.
- Bridge focuses on scalability; Adapter focuses on compatibility.
*/

namespace StructuralDesignPatterns.Bridge
{
    // ============================
    // IMPLEMENTATION HIERARCHY
    // ============================

    // This interface represents the "Implementation" side of the Bridge pattern.
    // It defines WHAT low-level operations are available.
    // Abstraction will call these methods, but it does not know
    // which concrete class implements them.
    public interface IImplementation
    {
        // A low-level operation that concrete implementations must provide
        string OperationImplementation();
    }

    // ConcreteImplementationA is one specific implementation
    // It could represent a platform, API, database, OS, etc.
    public class ConcreteImplementationA : IImplementation
    {
        // Actual implementation of the operation
        public string OperationImplementation()
        {
            return "Concrete Implementation A";
        }
    }

    // ConcreteImplementationB is another implementation
    // It provides a different behavior but follows the same interface
    public class ConcreteImplementationB : IImplementation
    {
        public string OperationImplementation()
        {
            return "Concrete Implementation B";
        }
    }

    // ============================
    // ABSTRACTION HIERARCHY
    // ============================

    // This class represents the "Abstraction" part of the Bridge pattern.
    // It defines high-level operations for the client.
    // It does NOT implement platform-specific logic.
    public class Abstraction
    {
        // Protected reference to the implementation
        // "protected" allows subclasses to access it
        protected IImplementation _implementation;

        // Constructor injection:
        // The abstraction receives the implementation at runtime
        // This is where the bridge is formed
        public Abstraction(IImplementation implementation)
        {
            this._implementation = implementation;
        }

        // High-level operation used by the client
        // It delegates the actual work to the implementation
        public virtual string Operation()
        {
            return "Abstraction: Base Operation with "
                   + _implementation.OperationImplementation();
        }
    }

    // ExtendedAbstraction extends the abstraction hierarchy
    // WITHOUT changing any implementation classes
    public class ExtendedAbstraction : Abstraction
    {
        // Calls base class constructor to set implementation
        public ExtendedAbstraction(IImplementation implementation)
            : base(implementation)
        {
        }

        // Overrides the high-level operation
        // Adds extra behavior on top of the base abstraction
        public override string Operation()
        {
            return "ExtendedAbstraction: Extended Operation with "
                   + base._implementation.OperationImplementation();
        }
    }

    // ============================
    // CLIENT
    // ============================

    // Client works ONLY with Abstraction
    // It does not depend on concrete implementations
    public class Client
    {
        public void ClientCode(Abstraction abstraction)
        {
            // Client simply calls abstraction methods
            // It does not know which implementation is used internally
            Console.WriteLine(abstraction.Operation());
        }
    }

    // ============================
    // PROGRAM (ENTRY POINT)
    // ============================

    public class Program
    {
        static void Main(string[] args)
        {
            // Create the client
            Client client = new Client();

            // Declare abstraction reference
            Abstraction abstraction;

            // Use Base Abstraction with Implementation A
            // Abstraction + ConcreteImplementationA
            abstraction = new Abstraction(new ConcreteImplementationA());
            client.ClientCode(abstraction);

            // Use Extended Abstraction with Implementation B
            // ExtendedAbstraction + ConcreteImplementationB
            abstraction = new ExtendedAbstraction(new ConcreteImplementationB());
            client.ClientCode(abstraction);
        }
    }
}
