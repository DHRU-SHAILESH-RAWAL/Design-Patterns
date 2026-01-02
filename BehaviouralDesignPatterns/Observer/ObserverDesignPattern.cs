/*
===========================================================
OBSERVER DESIGN PATTERN (Behavioral Pattern)
===========================================================

Definition:
Observer pattern defines a one-to-many relationship where
multiple objects (observers) automatically get notified
when the state of one object (subject) changes.

Key Idea:
- Subject does NOT know concrete observer details
- Observers can be added/removed at runtime
- Used for event-driven systems

Real-life Example:
Stock price updates → Mobile App, Email App get notified
===========================================================
*/

using System;
using System.Collections.Generic;

namespace BehaviouralDesignPatterns.Observer
{
    // Observer interface
    // All observers must implement Update()
    public interface IObserver
    {
        void Update(double price); // Called when subject state changes
    }

    // Subject interface
    // Responsible for managing observers
    public interface IStock
    {
        void Register(IObserver observer);   // Add observer
        void UnRegister(IObserver observer); // Remove observer
        void Notify();                       // Notify all observers
    }

    // Concrete Subject
    // Maintains state and observer list
    public class Stock : IStock
    {
        // Stores all subscribed observers
        private List<IObserver> _observers = new List<IObserver>();

        // State of the subject
        private double _price = 0.0;

        // Updates stock price
        public void SetPrice(double price)
        {
            _price = price;  // Change state
            Notify();        // IMPORTANT: notify observers after state change
        }

        // Register observer
        public void Register(IObserver observer)
        {
            _observers.Add(observer);
        }

        // Unregister observer
        public void UnRegister(IObserver observer)
        {
            _observers.Remove(observer);
        }

        // Notify all observers
        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_price); // Push updated state
            }
        }
    }

    // Concrete Observer 1
    public class MobileApp : IObserver
    {
        // Called automatically by subject
        public void Update(double price)
        {
            Console.WriteLine("Mobile App Notified : Stock Price updated with $" + price);
        }
    }

    // Concrete Observer 2
    public class EmailApp : IObserver
    {
        // Called automatically by subject
        public void Update(double price)
        {
            Console.WriteLine("Email App Notified : Stock Price updated with $" + price);
        }
    }

    // Client code
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create subject
            Stock stock = new();

            // Create observers
            IObserver mobileApp = new MobileApp();
            IObserver emailApp = new EmailApp();

            // Subscribe observers
            stock.Register(mobileApp);
            stock.Register(emailApp);

            // Change state → observers get notified automatically
            stock.SetPrice(300.45);
            stock.SetPrice(310.25);
        }
    }
}
