-----------------------------------------------------------
CREATIONAL PATTERNS
-----------------------------------------------------------
DEFINITION: These patterns deal with object creation mechanisms. 
The goal is to decouple the system from how its objects are 
created, composed, and represented.

- SINGLETON: Ensures a class has only one instance.
  * C# Tip: Use 'Lazy<T>' for thread-safe implementation.

- FACTORY METHOD: Subclasses decide which class to instantiate.
  * C# Tip: Great for decoupling logic from specific types.

- ABSTRACT FACTORY: Creates families of related objects.
  * C# Tip: Think "Theme Factory" (Dark vs Light UI elements).

- BUILDER: Steps-based construction of complex objects.
  * C# Tip: Used in 'Fluent Validations' or 'IHostBuilder'.

- PROTOTYPE: Creates new objects by cloning an existing one.
  * C# Tip: Uses 'ICloneable' or MemberwiseClone().
  ===========================================================