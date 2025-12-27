/*
=====================================================
 COMPOSITE DESIGN PATTERN – OVERVIEW (QUICK REVISION)
=====================================================

INTENT:
-------
Composite Pattern allows you to treat individual objects
(Leaf) and groups of objects (Composite) uniformly
using a common interface.

In simple words:
→ A single object and a collection of objects
  should be used in the same way.

-----------------------------------------------------

PROBLEM IT SOLVES:
------------------
When working with tree-like structures (hierarchies),
client code often needs to check:
    - Is this a single object?
    - Or is it a group of objects?

This leads to:
    ❌ if-else conditions
    ❌ tight coupling
    ❌ violation of Open/Closed Principle

Composite pattern removes these checks by introducing
a common abstraction.

-----------------------------------------------------

SOLUTION:
---------
1. Create a common interface (Component)
2. Leaf implements the interface (no children)
3. Composite implements the interface (has children)
4. Client uses only the interface

-----------------------------------------------------

STRUCTURE:
----------
Component (IFileSystem)
   ├── Leaf (File)
   └── Composite (Folder)
           ├── File
           └── Folder

-----------------------------------------------------

REAL-WORLD EXAMPLES:
--------------------
• File System → File & Folder
• UI Controls → Button & Panel
• Organization → Employee & Manager
• Menu → MenuItem & Menu

-----------------------------------------------------

BENEFITS:
---------
✔ Uniform treatment of objects
✔ Simplified client code
✔ Easy to extend hierarchy
✔ Follows SOLID principles (OCP, LSP, DIP)

-----------------------------------------------------

TRADE-OFF:
----------
❌ Can make design too generic
❌ Hard to restrict child types

-----------------------------------------------------

THIS EXAMPLE:
-------------
IFileSystem → Component
File        → Leaf (individual file)
Folder      → Composite (folder containing files/folders)
Program     → Client

=====================================================
*/

namespace StructuralDesignPatterns.Composite
{
    /// <summary>
    /// COMPONENT
    /// Common interface for both Leaf (File) and Composite (Folder)
    /// Enables uniform treatment by client code
    /// </summary>
    public interface IFileSystem
    {
        // Common operation for all file system elements
        void GetFileName(int depth);
    }

    /// <summary>
    /// LEAF
    /// Represents an individual file
    /// Cannot contain any children
    /// </summary>
    public class File : IFileSystem
    {
        private readonly string _name;

        // Leaf holds only its own data
        public File(string name)
        {
            _name = name;
        }

        // Leaf directly performs the operation
        public void GetFileName(int depth)
        {
            // Depth controls indentation to show hierarchy
            Console.WriteLine(new string('-', depth) + _name);
        }
    }

    /// <summary>
    /// COMPOSITE
    /// Represents a folder which can contain files or other folders
    /// </summary>
    public class Folder : IFileSystem
    {
        private readonly string _name;

        // Composite stores children as Component interface
        private readonly List<IFileSystem> _children = new();

        public Folder(string name)
        {
            _name = name;
        }

        // Add child (File or Folder)
        public void Add(IFileSystem item)
        {
            _children.Add(item);
        }

        // Remove child
        public void Remove(IFileSystem item)
        {
            _children.Remove(item);
        }

        // Composite performs its own logic
        // and delegates the same operation to its children
        public void GetFileName(int depth)
        {
            // Display current folder name
            Console.WriteLine(new string('-', depth) + _name);

            // Recursively call operation on children
            foreach (var file in _children)
            {
                file.GetFileName(depth + 2);
            }
        }

        /// <summary>
        /// CLIENT CODE
        /// Builds tree structure and uses it uniformly
        /// </summary>
        public class Program
        {
            static void Main(string[] args)
            {
                // Create leaf objects
                IFileSystem file1 = new File("File1.txt");
                IFileSystem file2 = new File("File2.txt");

                // Create composite objects
                Folder root = new Folder("Root");
                Folder subFolder = new Folder("SubFolder");

                // Build hierarchy
                root.Add(file1);
                root.Add(subFolder);
                root.Add(file2);

                // Client treats File and Folder the same
                root.GetFileName(1);
            }
        }
    }
}

