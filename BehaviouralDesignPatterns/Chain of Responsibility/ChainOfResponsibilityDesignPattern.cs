/*
==============================================
Chain of Responsibility Design Pattern
==============================================

Definition:
The Chain of Responsibility pattern allows a request to be passed
along a chain of handlers. Each handler decides whether to:
- Handle the request, OR
- Pass it to the next handler in the chain.

Key Points (Interview Ready):
- Avoids tight coupling between sender and receiver
- Request moves step-by-step through handlers
- Follows Open/Closed Principle (easy to add new handlers)
- Common use cases: approval systems, logging, middleware pipelines

Real-world Example:
Loan approval process:
Clerk → Senior Clerk → Loan Manager
*/

using System;

namespace BehaviouralDesignPatterns.Chain_of_Responsibility
{
    // Abstract Handler
    // Defines the structure of all approvers
    public abstract class Approver
    {
        // Reference to the next handler in the chain
        protected Approver _nextApprover;

        // Method to set the next handler
        public void SendNext(Approver approver)
        {
            _nextApprover = approver;
        }

        // Each approver must decide how to process the request
        public abstract void ProcessRequest(double amount);
    }

    // Concrete Handler 1
    // Clerk can approve loan up to 10,000
    public class Clerk : Approver
    {
        public override void ProcessRequest(double amount)
        {
            // If amount is within Clerk's limit
            if (amount < 10000)
            {
                Console.WriteLine("Loan Approved by Clerk");
            }
            else
            {
                // Pass request to next approver
                _nextApprover?.ProcessRequest(amount);
            }
        }
    }

    // Concrete Handler 2
    // Senior Clerk can approve loan up to 30,000
    public class SeniorClerk : Approver
    {
        public override void ProcessRequest(double amount)
        {
            // If amount is within Senior Clerk's limit
            if (amount < 30000)
            {
                Console.WriteLine("Loan Approved by Senior Clerk");
            }
            else
            {
                // Pass request to next approver
                _nextApprover?.ProcessRequest(amount);
            }
        }
    }

    // Concrete Handler 3 (Last handler in chain)
    // Loan Manager has final authority
    public class LoanManager : Approver
    {
        public override void ProcessRequest(double amount)
        {
            // Loan Manager checks the request
            if (amount > 30000)
            {
                Console.WriteLine("Loan Approved by Loan Manager");
            }
            else
            {
                // No handler available after this
                Console.WriteLine("Sorry, we cannot process your loan for now");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create handlers
            Approver approver1 = new Clerk();
            Approver approver2 = new SeniorClerk();
            Approver approver3 = new LoanManager();

            // Build the chain
            approver1.SendNext(approver2);
            approver2.SendNext(approver3);

            // Send loan requests
            approver1.ProcessRequest(9000);   // Clerk approves
            approver1.ProcessRequest(20000);  // Senior Clerk approves
            approver1.ProcessRequest(50000);  // Laon Manager approves
        }
    }
}
