/*
===========================================================
TEMPLATE DESIGN PATTERN (Behavioral Pattern)
===========================================================

DEFINITION:
Template Pattern defines the SKELETON of an algorithm in a
base class and lets subclasses override specific steps
WITHOUT changing the overall algorithm structure.

KEY IDEA:
- Same process flow
- Different implementations of steps
- Parent class controls execution order

WHEN TO USE:
- Multiple classes follow the same workflow
- Some steps vary, but sequence must remain fixed
- To avoid duplicate code

TEMPLATE vs STRATEGY:
- Template uses INHERITANCE
- Strategy uses COMPOSITION
- Template fixes algorithm flow at compile time
- Strategy allows behavior change at runtime

===========================================================
*/

using System;                      // Provides Console and base system classes
using System.Collections.Generic;  // For collections (not used directly here)
using System.Linq;                 // For LINQ operations
using System.Text;                 // For string handling
using System.Threading.Tasks;      // For async programming

namespace BehaviouralDesignPatterns.Template
{
    // ABSTRACT BASE CLASS
    // Defines the template (fixed algorithm structure)
    public abstract class Dataprocessor
    {
        // TEMPLATE METHOD
        // This method defines the FIXED sequence of steps
        // Child classes should NOT override this method
        public void ProcessFile()
        {
            Read();    // Step 1: Read data (varies per implementation)
            Write();   // Step 2: Write data (varies per implementation)
            Save();    // Step 3: Save data (common step)
        }

        // ABSTRACT METHOD
        // Forces subclasses to implement their own Read logic
        protected abstract void Read();

        // ABSTRACT METHOD
        // Forces subclasses to implement their own Write logic
        protected abstract void Write();

        // VIRTUAL METHOD (HOOK METHOD)
        // Provides default behavior
        // Subclasses may override if they want custom saving logic
        protected virtual void Save()
        {
            Console.WriteLine("Save the files");
        }
    }

    // CONCRETE CLASS 1
    // Implements Excel-specific behavior
    public class ExcelProcessor : Dataprocessor
    {
        // Excel-specific read implementation
        protected override void Read()
        {
            Console.WriteLine("Read excel data");
        }

        // Excel-specific write implementation
        protected override void Write()
        {
            Console.WriteLine("Write to excel");
        }
    }

    // CONCRETE CLASS 2
    // Implements CSV-specific behavior
    public class CsvProcessor : Dataprocessor
    {
        // CSV-specific read implementation
        protected override void Read()
        {
            Console.WriteLine("Read csv data");
        }

        // CSV-specific write implementation
        protected override void Write()
        {
            Console.WriteLine("Write to csv");
        }
    }

    // CLIENT CODE
    // Uses the template without knowing internal implementation details
    public class Program
    {
        public static void Main(string[] args)
        {
            // Using ExcelProcessor
            Dataprocessor processor = new ExcelProcessor();
            processor.ProcessFile();   // Executes fixed template flow

            Console.WriteLine();

            // Switching to CsvProcessor
            // Same algorithm, different step implementations
            processor = new CsvProcessor();
            processor.ProcessFile();
        }
    }
}
