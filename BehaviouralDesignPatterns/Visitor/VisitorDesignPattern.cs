/*
===============================================================================
VISITOR DESIGN PATTERN (Behavioral Pattern)
===============================================================================

Definition:
Visitor Pattern allows adding new operations to an existing object structure
WITHOUT modifying the classes of the elements on which it operates.

Key Intent:
- Separate operations (Visitor) from object structure (Elements)
- Add new behaviors by creating new Visitors
- Avoid modifying existing element classes

Key Concepts:
- Uses DOUBLE DISPATCH:
  1) Element decides which visitor method to call (Accept)
  2) Visitor decides what operation to perform (Visit)

When to Use:
- When object structure is stable
- When operations change frequently
- When you want to avoid if-else / switch based on object types

Real-world analogy:
Doctor / Salesman visiting Kids in a School
Same kids, different operations based on visitor

===============================================================================
*/

using System;
using System.Collections.Generic;

namespace BehaviouralDesignPatterns.Visitor
{
    // VISITOR INTERFACE
    // Declares a Visit method that accepts an element
    // Concrete visitors will implement their own logic
    public interface IVisitor
    {
        void Visit(IElement element);
    }

    // ELEMENT INTERFACE
    // Declares Accept method which takes a visitor
    // This enables FIRST DISPATCH
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    // CONCRETE ELEMENT
    // Kid is an element that can be visited
    public class Kid : IElement
    {
        public string KidName { get; set; }

        public Kid(string name)
        {
            KidName = name;
        }

        // Accept method calls back the visitor
        // SECOND DISPATCH happens here
        public void Accept(IVisitor visitor)
        {
            // "this" represents the actual runtime object (Kid)
            visitor.Visit(this);
        }
    }

    // CONCRETE VISITOR - Doctor
    // Defines operation performed on Kid
    public class Doctor : IVisitor
    {
        public string DoctorName { get; set; }

        public Doctor(string name)
        {
            DoctorName = name;
        }

        // Visit logic specific to Doctor visiting Kid
        public void Visit(IElement element)
        {
            // Downcasting to access Kid-specific data
            Kid kid = (Kid)element;

            Console.WriteLine(
                "Doctor visited the school and checked kid " + kid.KidName
            );
        }
    }

    // CONCRETE VISITOR - SalesMan
    // Another operation on the same Kid object
    public class SalesMen : IVisitor
    {
        public string SalesManName { get; set; }

        public SalesMen(string name)
        {
            SalesManName = name;
        }

        // Visit logic specific to Salesman visiting Kid
        public void Visit(IElement element)
        {
            Kid kid = (Kid)element;

            Console.WriteLine(
                "Salesman visited the school and sold a bag to " + kid.KidName
            );
        }
    }

    // OBJECT STRUCTURE
    // Maintains a collection of elements
    public class School
    {
        // Collection of elements (Kids)
        private static readonly List<IElement> elements;

        // Static constructor initializes object structure
        static School()
        {
            elements = new List<IElement>
            {
                new Kid("Dhru"),
                new Kid("ABC"),
                new Kid("XYZ")
            };
        }

        // Accepts a visitor and applies it to all elements
        public void PerformOperation(IVisitor visitor)
        {
            foreach (var kid in elements)
            {
                // First dispatch → element decides
                kid.Accept(visitor);
            }
        }
    }

    // CLIENT CODE
    public class Program
    {
        public static void Main()
        {
            // Create Object Structure
            School school = new School();

            // Create Doctor Visitor
            IVisitor doctor = new Doctor("James");

            // Doctor visits all kids
            school.PerformOperation(doctor);

            Console.WriteLine();

            // Create Salesman Visitor
            IVisitor salesman = new SalesMen("John");

            // Salesman visits all kids
            school.PerformOperation(salesman);

            Console.Read();
        }
    }
}
