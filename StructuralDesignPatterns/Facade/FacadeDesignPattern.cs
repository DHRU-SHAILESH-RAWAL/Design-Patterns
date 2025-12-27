/*
===============================================================================
Facade Design Pattern – Brief Explanation
===============================================================================

The Facade Design Pattern is a *Structural Design Pattern* that provides a
simplified, unified interface to a set of complex subsystems.

👉 Instead of the client interacting with multiple services directly,
   it interacts with a single Facade class.

Key Points for Interview:
- Facade hides system complexity from the client
- Reduces tight coupling between client and subsystems
- Improves readability and maintainability
- Commonly used in service layers, APIs, and SDKs (often unknowingly)

In this example:
- PaymentService, InventoryService, ShipmentService, InvoiceService
  are independent subsystems.
- OrderFacade acts as a single entry point to coordinate these services.
- Client (Program) talks ONLY to OrderFacade.

===============================================================================
*/

namespace StructuralDesignPatterns.Facade
{
    /// <summary>
    /// Subsystem class responsible for handling payment-related logic.
    /// Client should NOT interact with this directly.
    /// </summary>
    public class PaymentsService
    {
        /// <summary>
        /// Processes the payment for the given amount.
        /// </summary>
        public void ProcessPayment(double amount)
        {
            Console.WriteLine("Payment Done");
        }
    }

    /// <summary>
    /// Subsystem class responsible for inventory-related operations.
    /// </summary>
    public class InventoryService
    {
        /// <summary>
        /// Checks whether the given product is available in stock.
        /// Returns true if available.
        /// </summary>
        public bool IsProductAvailable(string productname)
        {
            Console.WriteLine("Product " + productname + " is available");
            return true;
        }
    }

    /// <summary>
    /// Subsystem class responsible for shipping operations.
    /// </summary>
    public class ShipmentService
    {
        /// <summary>
        /// Ships the product to the customer.
        /// </summary>
        public void ShipProduct()
        {
            Console.WriteLine("Product Shipped...");
        }
    }

    /// <summary>
    /// Subsystem class responsible for invoice generation.
    /// </summary>
    public class InvoiceService
    {
        /// <summary>
        /// Generates the invoice for the order.
        /// </summary>
        public void GenerateInvoice()
        {
            Console.WriteLine("Invoice generated");
        }
    }

    /// <summary>
    /// Facade class that provides a simplified interface
    /// to all the underlying subsystems.
    /// 
    /// This is the core of the Facade Pattern.
    /// </summary>
    public class OrderFacade
    {
        // References to all subsystem services
        private readonly PaymentsService _paymentService;
        private readonly InventoryService _inventoryService;
        private readonly ShipmentService _shipmentService;
        private readonly InvoiceService _invoiceService;

        /// <summary>
        /// Constructor initializes all subsystem objects.
        /// Client does not need to worry about these dependencies.
        /// </summary>
        public OrderFacade()
        {
            _paymentService = new PaymentsService();
            _inventoryService = new InventoryService();
            _shipmentService = new ShipmentService();
            _invoiceService = new InvoiceService();
        }

        /// <summary>
        /// Simplified method that places an order.
        /// Internally coordinates multiple subsystem calls.
        /// </summary>
        public void PlaceOrder(string product, double amount)
        {
            // Step 1: Check product availability
            var isProductAvailable = _inventoryService.IsProductAvailable(product);

            if (isProductAvailable)
            {
                // Step 2: Process payment
                _paymentService.ProcessPayment(amount);

                // Step 3: Generate invoice
                _invoiceService.GenerateInvoice();

                // Step 4: Ship product
                _shipmentService.ShipProduct();
            }
        }
    }

    /// <summary>
    /// Client code.
    /// Client interacts ONLY with the Facade, not with subsystems.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Client creates the Facade
            OrderFacade order = new OrderFacade();

            // Client places order using a single simple method
            order.PlaceOrder("laptop", 55066.26);
        }
    }
}
