// Factory Method Pattern Example
// ------------------------------
// The Factory Method pattern defines an interface for creating objects, but lets subclasses decide which class to instantiate.
// It allows a class to defer instantiation to subclasses, promoting loose coupling and adherence to the Open/Closed Principle.
//
// Key Components:
// - Product: The interface or abstract class for objects the factory creates (here, IPaymentservice).
// - ConcreteProduct: Concrete implementations of the Product (CardPaymentService, UPIPaymentservice, GiftCardPaymentService).
// - Creator: Declares the factory method (PaymentServiceFactory).
// - ConcreteCreator: Implements the factory method to return an instance of a ConcreteProduct (ConcreePaymentService).
//
// Use Case: When a class can't anticipate the type of objects it needs to create, or wants its subclasses to specify the objects.
//
// Interview Quick Notes:
// - Factory Method promotes loose coupling by eliminating the need to bind application-specific classes into code.
// - It follows the Open/Closed Principle: add new products without changing existing code.
// - Common in frameworks and libraries for extensibility (e.g., dependency injection, logging, UI components).

using System;

namespace CreationalDesignPatterns.Factory
{
    /// <summary>
    /// Product interface. All payment services must implement this.
    /// </summary>
    public interface IPaymentservice
    {
        /// <summary>
        /// Processes a payment of the specified amount.
        /// </summary>
        /// <param name="amount">The payment amount.</param>
        void ProcessPayment(double amount);
    }

    /// <summary>
    /// ConcreteProduct: Implements card payment processing.
    /// </summary>
    public class CardPaymentService : IPaymentservice
    {
        public void ProcessPayment(double amount)
        {
            // Interview Tip: Each product implements the same interface.
            Console.WriteLine("Process Card Payment for {0}", amount);
        }
    }

    /// <summary>
    /// ConcreteProduct: Implements UPI payment processing.
    /// </summary>
    public class UPIPaymentservice : IPaymentservice
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine("Process UPI Payment for {0}", amount);
        }
    }

    /// <summary>
    /// ConcreteProduct: Implements gift card payment processing.
    /// </summary>
    public class GiftCardPaymentService : IPaymentservice
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine("Process Gift Card Payment for {0}", amount);
        }
    }

    /// <summary>
    /// Creator: Declares the factory method.
    /// </summary>
    public abstract class PaymentServiceFactory
    {
        /// <summary>
        /// Factory method to create payment service based on type.
        /// </summary>
        /// <param name="paymentType">Type of payment (e.g., "Card", "UPI", "GiftCard").</param>
        /// <returns>Instance of IPaymentservice.</returns>
        public abstract IPaymentservice CreatePaymentService(string paymentType);
    }

    /// <summary>
    /// ConcreteCreator: Implements the factory method to instantiate the correct payment service.
    /// </summary>
    public class ConcreePaymentService : PaymentServiceFactory
    {
        public override IPaymentservice CreatePaymentService(string paymentType)
        {
            // Interview Tip: Factory logic is centralized here.
            switch (paymentType)
            {
                case "Card":
                    return new CardPaymentService();
                case "UPI":
                    return new UPIPaymentservice();
                case "GiftCard":
                    return new GiftCardPaymentService();
                default:
                    throw new ArgumentException("Invalid payment type");
            }
        }
    }

    // Interview Tip:
    // - Factory Method is a creational pattern, not to be confused with Abstract Factory (which creates families of related objects).
    // - Use when you need to delegate the instantiation logic to subclasses or externalize object creation.
}
