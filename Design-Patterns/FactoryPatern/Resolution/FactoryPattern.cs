namespace Design_Patterns.FactoryPatern.Resolution
{
    /// <summary>
    /// Demonstrates the Factory Design Pattern.
    /// The Factory Pattern defines an interface for creating an object, but lets subclasses decide which class to instantiate.
    /// This pattern is used to create objects without exposing the instantiation logic to the client and refers to the newly created object using a common interface.
    /// </summary>
    class FactoryPattern
    {
        // Product interface: defines the contract for notification types.
        interface INotification
        {
            // Method to send a notification message.
            void Notify(string message);
        }

        // Concrete Product: Implements INotification for Email notifications.
        class EmailNotification : INotification
        {
            public void Notify(string message)
            {
                // Simulate sending an email notification.
                Console.WriteLine($"Email Notification: {message}");
            }
        }

        // Concrete Product: Implements INotification for SMS notifications.
        class SMSNotification : INotification
        {
            public void Notify(string message)
            {
                // Simulate sending an SMS notification.
                Console.WriteLine($"SMS Notification: {message}");
            }
        }

        // Concrete Product: Implements INotification for Push notifications.
        class PushNotification : INotification
        {
            public void Notify(string message)
            {
                // Simulate sending a push notification.
                Console.WriteLine($"Push Notification: {message}");
            }
        }

        /// <summary>
        /// Concrete Factory: Responsible for creating instances of INotification based on the provided type.
        /// Encapsulates the object creation logic and returns the appropriate notification object.
        /// </summary>
        class NotificationfactoryService
        {
            /// <summary>
            /// Factory Method: Creates and returns an INotification object based on the input type.
            /// </summary>
            /// <param name="type">Type of notification ("email", "SMS", "push")</param>
            /// <returns>Instance of a class implementing INotification</returns>
            public static INotification CreateNotification(string type)
            {
                switch (type)
                {
                    case "email":
                        return new EmailNotification();
                    case "SMS":
                        return new SMSNotification();
                    case "push":
                        return new PushNotification();
                    default:
                        // Default to EmailNotification if type is not recognized.
                        return new EmailNotification();
                }
            }
        }

        /// <summary>
        /// Client code: Uses the factory to obtain an INotification instance and sends a notification.
        /// The client is decoupled from the concrete classes and only interacts with the INotification interface.
        /// </summary>
        class Notification
        {
            public static void main()
            {
                // Request an email notification from the factory.
                INotification notification = NotificationfactoryService.CreateNotification("email");
                // Send the notification.
                notification.Notify("This is an email notification.");
            }
        }
    }
}
