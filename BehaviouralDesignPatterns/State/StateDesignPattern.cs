/*
=====================================================
STATE DESIGN PATTERN (Behavioral Pattern)
=====================================================
• Allows an object to change its behavior when its internal state changes.
• Behavior change happens automatically based on the current state.
• Eliminates large if-else or switch-case statements.
• Each state is represented as a separate class.

-----------------------------------------------------
STATE vs STRATEGY (INTERVIEW POINT)
-----------------------------------------------------
STATE PATTERN:
• Behavior depends on the object's INTERNAL STATE.
• State can change itself at runtime.
• Client does NOT decide behavior directly.
• Example: LoggedIn / LoggedOut / Locked

STRATEGY PATTERN:
• Behavior depends on chosen ALGORITHM.
• Strategy is selected explicitly by the client.
• Strategy does NOT change itself.
• Example: Payment via Card / UPI / Cash
=====================================================
*/

namespace BehaviouralDesignPatterns.State
{
    // STATE INTERFACE
    // Defines behavior that changes based on the object's state
    public interface IState
    {
        void PerformAction(); // State-specific action
    }

    // CONCRETE STATE: LOGIN
    // Represents Logged-In state
    public class LogIn : IState
    {
        // Executes behavior when system is in Logged-In state
        public void PerformAction()
        {
            Console.WriteLine("User logged in the system");
        }
    }

    // CONCRETE STATE: LOGOUT
    // Represents Logged-Out state
    public class LogOut : IState
    {
        // Executes behavior when system is in Logged-Out state
        public void PerformAction()
        {
            Console.WriteLine("User logged out of the system");
        }
    }

    // CONTEXT CLASS
    // Holds the current state and delegates behavior to it
    public class StateContext
    {
        // Current state (Login or Logout)
        private IState _state;

        // Allows state change at runtime
        // (In State pattern, state change may also happen internally)
        public void SetState(IState state)
        {
            _state = state;
        }

        // Delegates the action to the current state
        // No if-else or switch required
        public void ProcessAction()
        {
            _state.PerformAction();
        }
    }

    // CLIENT CODE
    // Demonstrates runtime behavior change
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create context
            StateContext stateContext = new StateContext();

            // Client sets initial state (Login)
            stateContext.SetState(new LogIn());
            stateContext.ProcessAction();

            // State changes to Logout
            // In State pattern, this could also happen internally
            stateContext.SetState(new LogOut());
            stateContext.ProcessAction();
        }
    }
}
