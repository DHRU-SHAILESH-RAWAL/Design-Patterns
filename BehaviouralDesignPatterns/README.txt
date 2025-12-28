-----------------------------------------------------------
BEHAVIORAL PATTERNS
-----------------------------------------------------------
DEFINITION: These patterns focus on communication between 
objects, how they interact, and how they distribute 
responsibilities.

- STRATEGY: Encapsulates interchangeable algorithms.
  * C# Tip: The foundation of Dependency Injection (switching logic).

- OBSERVER: A way of notifying multiple objects of any events.
  * C# Tip: C# 'events' and 'delegates' are the native version.

- COMMAND: Encapsulates a request as an object.
  * C# Tip: Used for implementing 'Undo' and 'Redo' functionality.

- STATE: Object changes behavior based on its internal state.
  * C# Tip: Avoids massive 'if/else' or 'switch' statements.

- ITERATOR: Accesses elements of a collection without exposing logic.
  * C# Tip: 'IEnumerable' and 'IEnumerator' in C#.

- TEMPLATE METHOD: Defines the skeleton of an algorithm in a base class.
  * C# Tip: Base class has the 'Steps', subclasses override 'Step1()'.
===========================================================