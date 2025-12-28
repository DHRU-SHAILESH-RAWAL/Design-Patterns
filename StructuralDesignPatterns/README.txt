-----------------------------------------------------------
STRUCTURAL PATTERNS
-----------------------------------------------------------
DEFINITION: These patterns focus on how classes and objects 
combine to form larger structures. They ensure that if one 
part of a system changes, the entire structure doesn't break.

- ADAPTER: Joins two incompatible interfaces.
  * C# Tip: "The Translator." Useful for 3rd party API integration.

- DECORATOR: Adds behavior to an object without inheritance.
  * C# Tip: Think 'BufferedStream' wrapping a 'FileStream'.

- FACADE: A single class that represents an entire subsystem.
  * C# Tip: Simplifies a complex set of library calls into one method.

- PROXY: A placeholder object to control access (security/loading).
  * C# Tip: Essential for Lazy Loading in Entity Framework.

- COMPOSITE: Treats individual objects and collections uniformly.
  * C# Tip: Tree structures like File/Folder systems.

- BRIDGE: Decouples abstraction from implementation.
  * C# Tip: Separating a UI from the OS-specific graphic drivers.

- FLYWEIGHT: Minimizes memory usage by sharing data between similar objects.
  * C# Tip: Think of 'string.Intern()' or a game with 10,000 trees where 
    all share the same 'Texture' object but have different 'Positions'.
===========================================================