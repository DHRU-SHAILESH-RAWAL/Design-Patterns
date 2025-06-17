namespace Design_Patterns.FactoryPatern.Problem
{
    /// <summary>
    /// Below code does not follow factory pattern, it directly creates instances of notification classes.
    /// This approach violates the Open/Closed Principle, as adding a new notification type requires modifying
    /// the NotificationService class. To follow the Factory Design Pattern, object creation logic should be
    /// encapsulated in a separate factory class, allowing NotificationService to remain unchanged when new
    /// notification types are introduced.
    /// </summary>
    class FactoryPatternBroke
    {
        interface INotification
        {
            void Notify(string message);
        }

        class EmailNotification : INotification
        {
            public void Notify(string message)
            {
                Console.WriteLine($"Email Notification: {message}");
            }
        }

        class SMSNotification : INotification
        {
            public void Notify(string message)
            {
                Console.WriteLine($"SMS Notification: {message}");
            }
        }

        class PushNotification : INotification
        {
            public void Notify(string message)
            {
                Console.WriteLine($"Push Notification: {message}");
            }
        }

        class NotificationService
        {
            public static void main()
            {
                // This code directly creates instances of notification classes.
                // If a new notification type is added, this method must be modified,
                // which is not scalable and violates the Open/Closed Principle.
                // To fix this, use a Factory to encapsulate object creation.
                INotification emailNotification = new EmailNotification();
                emailNotification.Notify("This is an email notification.");
                INotification smsNotification = new SMSNotification();
                smsNotification.Notify("This is an SMS notification.");
                INotification pushNotification = new PushNotification();
                pushNotification.Notify("This is a push notification.");
            }
        }
    }
}
