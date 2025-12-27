/*
=========================================================
Decorator Design Pattern
=========================================================

Definition:
-----------
The Decorator Pattern allows behavior to be added to an
individual object dynamically without modifying its
existing class or using inheritance.

Category:
---------
Structural Design Pattern

Problem it Solves:
------------------
- Avoids subclass explosion caused by inheritance
- Adds optional features at runtime
- Keeps classes open for extension but closed for modification
  (Open/Closed Principle)

Core Idea:
----------
- Use composition instead of inheritance
- Wrap the original object inside decorator objects
- Each decorator adds new responsibility

Real-world Analogy:
-------------------
Coffee + Milk + Sugar
Each add-on decorates the original coffee

=========================================================
*/

namespace StructuralDesignPatterns.Decorator
{
    /*
     * ICoffee is the Component interface.
     * It defines the common operations that both
     * the concrete object and decorators must implement.
     */
    public interface ICoffee
    {
        string GetDescription(); // Returns coffee description
        void GetPrice();         // Prints coffee price
    }

    /*
     * SimpleCoffee is the ConcreteComponent.
     * This is the base object that can be decorated
     * with additional features like Milk or Sugar.
     */
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Simple Coffee ";
        }

        public void GetPrice()
        {
            Console.WriteLine("Simple Coffee Price $5");
        }
    }

    /*
     * CoffeeDecorator is the abstract Decorator.
     * It implements ICoffee and contains a reference
     * to an ICoffee object.
     * 
     * This allows decorators to wrap any ICoffee object.
     */
    public abstract class CoffeeDecorator : ICoffee
    {
        // Reference to the wrapped coffee object
        protected ICoffee _coffee;

        // Constructor injection of the component
        protected CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        // Delegates description to the wrapped object
        public virtual string GetDescription()
        {
            return _coffee.GetDescription();
        }

        // Delegates price calculation to the wrapped object
        public virtual void GetPrice()
        {
            _coffee.GetPrice();
        }
    }

    /*
     * CoffeeWithMilk is a ConcreteDecorator.
     * It adds Milk functionality without changing
     * the SimpleCoffee class.
     */
    public class CoffeeWithMilk : CoffeeDecorator
    {
        public CoffeeWithMilk(ICoffee coffee) : base(coffee)
        {
        }

        // Adds Milk to the existing description
        public override string GetDescription()
        {
            return base.GetDescription() + "Milk ";
        }

        // Can add extra price logic if needed
        public override void GetPrice()
        {
            base.GetPrice();
            Console.WriteLine("Milk Price $2");
        }
    }

    /*
     * CoffeeWithSugar is another ConcreteDecorator.
     * It adds Sugar functionality dynamically.
     */
    public class CoffeeWithSugar : CoffeeDecorator
    {
        public CoffeeWithSugar(ICoffee coffee) : base(coffee)
        {
        }

        // Adds Sugar to the existing description
        public override string GetDescription()
        {
            return base.GetDescription() + "Sugar ";
        }

        // Can add extra price logic if needed
        public override void GetPrice()
        {
            base.GetPrice();
            Console.WriteLine("Sugar Price $1");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            ICoffee coffee = new SimpleCoffee();
            coffee = new CoffeeWithMilk(coffee);
            coffee = new CoffeeWithSugar(coffee);

            Console.WriteLine(coffee.GetDescription());
            coffee.GetPrice();
        }
    }
}

