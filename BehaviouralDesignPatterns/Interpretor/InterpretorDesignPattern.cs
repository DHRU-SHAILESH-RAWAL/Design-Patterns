/*
===========================================================
INTERPRETER DESIGN PATTERN (Behavioral Pattern)
===========================================================

PURPOSE:
- Used to define a grammar and interpret expressions
- Each grammar rule is represented as a class
- Commonly used in expression evaluation, rule engines, SQL parsing

KEY IDEA:
- Build an expression tree
- Call Interpret() to evaluate the result

WHEN TO USE:
- Grammar is simple
- Expressions are reused
- Rules may change or extend

INTERVIEW ONE-LINER:
"Interpreter pattern defines a grammar and interprets expressions
by representing each rule as a class."
===========================================================
*/

namespace InterpreterPatternDemo
{
    /*
    -----------------------------------------------------------
    ABSTRACT EXPRESSION
    -----------------------------------------------------------
    - Declares the Interpret method
    - All expressions (terminal & non-terminal) implement this
    */
    public interface IExpression
    {
        int Interpret();
    }

    /*
    -----------------------------------------------------------
    TERMINAL EXPRESSION
    -----------------------------------------------------------
    - Represents a number (leaf node in expression tree)
    - Does not depend on other expressions
    */
    public class NumberExpression : IExpression
    {
        private int _number;

        public NumberExpression(int number)
        {
            _number = number;
        }

        // Simply returns the stored number
        public int Interpret()
        {
            return _number;
        }
    }

    /*
    -----------------------------------------------------------
    NON-TERMINAL EXPRESSION (Addition)
    -----------------------------------------------------------
    - Combines two expressions
    - Calls Interpret() on child expressions
    */
    public class AddExpression : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public AddExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public int Interpret()
        {
            return _left.Interpret() + _right.Interpret();
        }
    }

    /*
    -----------------------------------------------------------
    NON-TERMINAL EXPRESSION (Subtraction)
    -----------------------------------------------------------
    - Combines two expressions
    - Used to subtract one expression from another
    */
    public class SubtractExpression : IExpression
    {
        private IExpression _left;
        private IExpression _right;

        public SubtractExpression(IExpression left, IExpression right)
        {
            _left = left;
            _right = right;
        }

        public int Interpret()
        {
            return _left.Interpret() - _right.Interpret();
        }
    }

    /*
    -----------------------------------------------------------
    CLIENT CODE
    -----------------------------------------------------------
    - Builds the expression tree
    - Calls Interpret() to evaluate result
    */
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Expression Tree created here:

                    (-)
                   /   \
                (+)     3
               /   \
              5     10

            Expression: (5 + 10) - 3
            */

            IExpression expression =
                new SubtractExpression(
                    new AddExpression(
                        new NumberExpression(5),
                        new NumberExpression(10)
                    ),
                    new NumberExpression(3)
                );

            // Final evaluation
            int result = expression.Interpret();

            Console.WriteLine("Result: " + result); // Output: 12
        }
    }
}
