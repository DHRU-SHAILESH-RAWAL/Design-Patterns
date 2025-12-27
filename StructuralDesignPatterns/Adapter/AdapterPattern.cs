// ======================================================
// ADAPTER DESIGN PATTERN – DETAILED EXPLANATION
// ======================================================
//
// Intent:
// -------
// The Adapter Pattern allows two incompatible interfaces to work together.
// It acts as a "wrapper" around an existing (legacy or third-party) class
// so that it can be used where a different interface is expected.
//
// Problem solved:
// ----------------
// - We already have a working class: OldPaymentProcessor
// - Its method signature does NOT match what the new system expects
// - We do NOT want to modify legacy / third-party code
//
// Solution:
// ----------
// - Define a target interface (IPaymentProcessor)
// - Create an Adapter (PaymentProcessorAdaptor)
// - Adapter translates the new interface call into the old method call
//
// Benefits:
// ---------
// ✔ Reuse existing code
// ✔ Follow Open/Closed Principle (OCP)
// ✔ Avoid breaking legacy systems
// ✔ Clean separation of concerns
//
// Real-world analogy:
// --------------------
// A power adapter allows a US plug to work in an Indian socket
// without changing either the plug or the socket.
//
// ======================================================

namespace StructuralDesignPatterns.Adapter
{
    // --------------------------------------------------
    // TARGET INTERFACE
    // --------------------------------------------------
    // This is the interface expected by the NEW system.
    // Any payment processor used by the application
    // MUST implement this interface.
    public interface IPaymentProcessor
    {
        // Processes a payment using the new expected signature
        // cardNumber : credit/debit card number
        // amount     : payment amount using decimal (preferred in finance)
        void NewPaymentProcessor(string cardNumber, decimal amount);
    }

    // --------------------------------------------------
    // ADAPTEE (LEGACY / EXISTING CLASS)
    // --------------------------------------------------
    // This is an existing or third-party class.
    // We CANNOT change its method signature.
    public class OldPaymentProcessor
    {
        // Legacy payment method
        // Uses double instead of decimal
        // Name and signature do not match the new interface
        public void MakePayment(string cardNumber, double amount)
        {
            Console.WriteLine("Old Payment Processor");
        }
    }

    // --------------------------------------------------
    // ADAPTER
    // --------------------------------------------------
    // This class adapts OldPaymentProcessor to IPaymentProcessor.
    // It implements the new interface and internally
    // delegates the call to the old processor.
    public class PaymentProcessorAdaptor : IPaymentProcessor
    {
        // Holds a reference to the legacy payment processor
        private readonly OldPaymentProcessor _oldPaymentProcessor;

        // Constructor injection
        // Injecting legacy dependency makes the adapter flexible and testable
        public PaymentProcessorAdaptor(OldPaymentProcessor oldPaymentProcessor)
        {
            _oldPaymentProcessor = oldPaymentProcessor;
        }

        // This method matches the NEW interface
        // Internally it:
        // 1. Converts decimal → double
        // 2. Calls the legacy MakePayment method
        public void NewPaymentProcessor(string cardNumber, decimal amount)
        {
            Console.WriteLine("Processing payment");

            // Convert decimal to double because legacy API expects double
            double amountInDouble = (double)amount;

            // Delegate the call to the old payment processor
            _oldPaymentProcessor.MakePayment(cardNumber, amountInDouble);

            Console.WriteLine(
                "Payment processed using old processor for card " +
                cardNumber +
                " of amount " +
                amountInDouble
            );
        }
    }

    // --------------------------------------------------
    // CLIENT CLASS
    // --------------------------------------------------
    // This represents the business layer (e.g., an e-commerce system).
    // It depends ONLY on the interface, not on concrete implementations.
    public class ECommercePlatform
    {
        // Depends on abstraction (interface) → Dependency Inversion Principle
        private readonly IPaymentProcessor _paymentProcessor;

        // Payment processor is injected at runtime
        public ECommercePlatform(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        // Checkout process
        // Client code is unaware of whether it is using
        // a new or legacy payment processor
        public void CheckOut(string cardnumber, decimal amount)
        {
            _paymentProcessor.NewPaymentProcessor(cardnumber, amount);
        }
    }

    // --------------------------------------------------
    // PROGRAM (APPLICATION ENTRY POINT)
    // --------------------------------------------------
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create legacy payment processor
            OldPaymentProcessor oldPaymentProcessor = new OldPaymentProcessor();

            // Wrap legacy processor with adapter
            IPaymentProcessor paymentProcessorAdaptor =
                new PaymentProcessorAdaptor(oldPaymentProcessor);

            // Inject adapter into client
            ECommercePlatform eCommercePlatform =
                new ECommercePlatform(paymentProcessorAdaptor);

            // Client calls the new interface
            eCommercePlatform.CheckOut("123456-ashgd-45876", 123);
        }
    }
}
