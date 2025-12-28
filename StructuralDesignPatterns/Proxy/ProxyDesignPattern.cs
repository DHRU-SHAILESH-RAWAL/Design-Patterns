namespace StructuralDesignPatterns.Proxy
{
    /*
     ============================================================================
     PROXY DESIGN PATTERN
     ============================================================================
     Proxy is a Structural Design Pattern that provides a substitute (proxy)
     object to control access to another object called the Real Object.

     WHY PROXY IS USED:
     - To delay creation of expensive objects (Lazy Loading)
     - To control access (Security)
     - To add logging, caching, or monitoring
     - To keep client code loosely coupled

     HOW IT WORKS:
     Client → Proxy → Real Object

     IMPORTANT POINTS FOR INTERVIEW:
     - Proxy and Real Object implement the same interface
     - Client talks only to the interface
     - Proxy decides when to create and use the Real Object
     ============================================================================
    */

    // Subject Interface
    // This interface is implemented by both Proxy and Real Object
    // This allows Proxy to act as a replacement for the Real Object
    interface IDocument
    {
        // Common method exposed to client
        void Display();
    }

    // RealDocument is the Real Subject
    // This class contains the actual business logic
    // Assume loading a document from disk is an expensive operation
    public class RealDocument : IDocument
    {
        private readonly string _fileName;

        // Constructor initializes the document with file name
        public RealDocument(string fileName)
        {
            _fileName = fileName;
        }

        // Represents an expensive operation (Disk I/O)
        // In real-world applications, this could be loading a large file
        public void LoadFileFromDisk(string fileName)
        {
            Console.WriteLine("Loading the file " + fileName + " from disk");
        }

        // Displays the document to the client
        public void Display()
        {
            Console.WriteLine("The file is being displayed to the client");
        }
    }

    // ProxyDocument is the Proxy class
    // It controls access to RealDocument
    // It performs Lazy Loading by creating RealDocument only when required
    public class ProxyDocument : IDocument
    {
        // Reference to the Real Object
        private RealDocument _realDocument;

        // Stores file name until real object is created
        private readonly string _fileName;

        // Proxy constructor receives the file name
        // Note: RealDocument is NOT created here
        public ProxyDocument(string fileName)
        {
            _fileName = fileName;
        }

        // This method is called by the client
        public void Display()
        {
            // Lazy initialization:
            // Create RealDocument only on the first request
            if (_realDocument == null)
            {
                _realDocument = new RealDocument(_fileName);
            }

            // Delegate the call to the Real Object
            _realDocument.Display();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Client creates Proxy object instead of RealDocument
            // Client does not know whether it is using Proxy or Real Object
            IDocument document = new ProxyDocument("Dhru_Shailesh_Rawal_CV.pdf");

            // First call:
            // Proxy creates RealDocument and then displays it
            document.Display();

            // Second call:
            // Proxy reuses already created RealDocument
            document.Display();
        }
    }
}
