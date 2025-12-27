namespace StructuralDesignPatterns.Flyweight
{
    /*
     * ============================
     * FLYWEIGHT DESIGN PATTERN
     * ============================
     *
     * Intent:
     * Reduce memory usage by sharing common objects instead of creating
     * a large number of similar objects.
     *
     * Key Idea:
     * - Intrinsic State  -> Shared, stored inside flyweight object (symbol)
     * - Extrinsic State  -> Passed from outside at runtime (x, y position)
     *
     * In this example:
     * - Character symbol (A, B, etc.) is intrinsic and shared
     * - Position (x, y) is extrinsic and varies per usage
     */

    /// <summary>
    /// Flyweight interface
    /// Declares operation that accepts extrinsic state (position)
    /// </summary>
    public interface ICharacter
    {
        // x and y are extrinsic state passed by the client
        void CharacterPosition(int x, int y);
    }

    /// <summary>
    /// ConcreteFlyweight class
    /// Stores intrinsic (shared) state
    /// </summary>
    public class Character : ICharacter
    {
        // Intrinsic state: shared among multiple objects
        private readonly char _symbol;

        /// <summary>
        /// Constructor initializes intrinsic state
        /// This is created only once per unique symbol
        /// </summary>
        public Character(char symbol)
        {
            _symbol = symbol;
        }

        /// <summary>
        /// Method uses extrinsic state provided by the client
        /// Flyweight object itself does not store position
        /// </summary>
        public void CharacterPosition(int x, int y)
        {
            Console.WriteLine(
                "The position of the symbol " + _symbol + " is " + x + "," + y
            );
        }
    }

    /// <summary>
    /// Flyweight Factory
    /// Responsible for creating and managing flyweight objects
    /// Ensures that objects are shared and reused
    /// </summary>
    public class CharacterFactory
    {
        // Cache to store already created flyweight objects
        private readonly Dictionary<char, ICharacter> characters = new();

        /// <summary>
        /// Returns an existing flyweight if available
        /// Otherwise creates a new one and stores it
        /// </summary>
        public ICharacter GetCharacter(char symbol)
        {
            // Check if flyweight already exists
            if (!characters.ContainsKey(symbol))
            {
                // Create new flyweight only if not present
                characters[symbol] = new Character(symbol);
            }

            // Return shared instance
            return characters[symbol];
        }
    }

    /// <summary>
    /// Client code
    /// Demonstrates flyweight reuse
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // Factory manages flyweight creation
            CharacterFactory factory = new CharacterFactory();

            // 'A' is created only once
            ICharacter a1 = factory.GetCharacter('A');
            a1.CharacterPosition(10, 20);

            // Same 'A' object reused, different position
            ICharacter a2 = factory.GetCharacter('A');
            a2.CharacterPosition(20, 30);

            // New flyweight created for 'B'
            ICharacter b1 = factory.GetCharacter('B');
            b1.CharacterPosition(30, 40);
        }
    }
}
