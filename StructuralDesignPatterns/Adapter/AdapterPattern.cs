// Adapter Pattern Example
// -----------------------
// The Adapter pattern allows incompatible interfaces to work together by acting as a bridge between them.
// In this example:
// - IPaymentProcessor defines the expected interface for payment processing.
// - OldPaymentProcessor has an existing, incompatible method signature(legacy).
// - PaymentProcessorAdaptor adapts OldPaymentProcessor to IPaymentProcessor, enabling legacy code reuse.
// This pattern is useful when integrating new systems with legacy or third-party code without modifying the original classes.

namespace StructuralDesignPatterns.Adapter
{
    public interface IPaymentProcessor
    {
        void NewPaymentProcessor(string cardNumber, decimal amount);
    }

    public class OldPaymentProcessor
    {
        public void MakePayment(string cardNumber, double amount)
        {
            Console.WriteLine("Old Payment Processor");
        }
    }

    public class PaymentProcessorAdaptor : IPaymentProcessor
    {
        private readonly OldPaymentProcessor _oldPaymentProcessor;

        public PaymentProcessorAdaptor(OldPaymentProcessor oldPaymentProcessor)
        {
            _oldPaymentProcessor = oldPaymentProcessor;
        }

        public void NewPaymentProcessor(string cardNumber, decimal amount)
        {
            Console.WriteLine("Processing payment");
            double amountInDouble = (double)amount;
            _oldPaymentProcessor.MakePayment(cardNumber, amountInDouble);
            Console.WriteLine("Payment processed using old processor for card "+cardNumber+" of amount "+amountInDouble);
        }
    }

    public class ECommercePlatform
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public ECommercePlatform(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }
        
        public void CheckOut(string cardnumber, decimal amount)
        {
            _paymentProcessor.NewPaymentProcessor(cardnumber, amount);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            OldPaymentProcessor oldPaymentProcessor = new OldPaymentProcessor();
            IPaymentProcessor paymentProcessorAdaptor = new PaymentProcessorAdaptor(oldPaymentProcessor);

            ECommercePlatform eCommercePlatform = new ECommercePlatform(paymentProcessorAdaptor);
            eCommercePlatform.CheckOut("123456-ashgd-45876", 123);
        }
    }
}
