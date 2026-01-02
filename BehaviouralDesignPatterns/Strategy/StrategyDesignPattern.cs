/*
===========================================================
STRATEGY DESIGN PATTERN (Behavioral Pattern)
===========================================================
Definition:
Strategy Pattern defines a family of algorithms, encapsulates
each one, and makes them interchangeable at runtime.

Key Idea:
- Client can change behavior without modifying existing code
- Uses composition instead of inheritance
- Eliminates large if-else or switch statements

Difference from State Pattern (Interview Important):
- Strategy Pattern: Client explicitly chooses and switches
  the algorithm (strategy) at runtime.
- State Pattern: Object changes its behavior automatically
  based on its internal state; client is usually unaware
  of state transitions.

Real-world example:
- Payment methods (UPI, Credit Card, Wallet, etc.)
===========================================================
*/

namespace BehaviouralDesignPatterns.Startegy
{
    // Strategy Interface
    // Declares a common operation for all supported algorithms
    public interface IPaymentProcessor
    {
        void Pay(double amount);
    }

    // Concrete Strategy 1
    // Implements payment using UPI
    public class UPIPayment : IPaymentProcessor
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Payment of amount " + amount + " done through UPI payments");
        }
    }

    // Concrete Strategy 2
    // Implements payment using Credit Card
    public class CreditCardPayment : IPaymentProcessor
    {
        public void Pay(double amount)
        {
            Console.WriteLine("Payment of amount " + amount + " done through Credit card");
        }
    }

    // Context Class
    // Maintains a reference to a strategy object
    // Does NOT know which payment method is being used
    public class PaymentStrategyContext
    {
        private IPaymentProcessor _paymentProcessor;

        // Allows changing the strategy at runtime
        public void SetPaymentStrategy(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        // Delegates payment processing to the selected strategy
        public void ProcessPayment(double amount)
        {
            _paymentProcessor.Pay(amount);
        }
    }

    // Client Code
    // Chooses and switches strategies dynamically
    public class Program
    {
        public static void Main(string[] args)
        {
            PaymentStrategyContext paymentStrategyContext = new PaymentStrategyContext();

            // Using UPI payment strategy
            paymentStrategyContext.SetPaymentStrategy(new UPIPayment());
            paymentStrategyContext.ProcessPayment(135000.232);

            // Switching to Credit Card payment strategy at runtime
            paymentStrategyContext.SetPaymentStrategy(new CreditCardPayment());
            paymentStrategyContext.ProcessPayment(1350000.232);
        }
    }
}
