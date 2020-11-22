namespace ShuntingYardAlgorithm
{
    /// <summary>
    /// An operator or function in an equation
    /// </summary>
    public class Operator : Symbol
    {
        /// <summary>
        /// The precedence of the operator. Higher means sooner in order of operations
        /// </summary>
        public int Precedence;

        /// <summary>
        /// Whether the operator is right associative, i.e. powers (x^y)
        /// </summary>
        public bool IsRightAssociative;

        /// <summary>
        /// What type of operator it is
        /// </summary>
        public Operators Op;

        /// <summary>
        /// An operator or function in an equation
        /// </summary>
        /// <param name="value">The value of the operator</param>
        /// <param name="op">What type of operator it is</param>
        /// <param name="precedence">What it's precedence is</param>
        /// <param name="isRightAssociative">Whether it's right associative</param>
        public Operator(string value, Operators op, int precedence, bool isRightAssociative = false) : base(value)
        {
            Op = op;
            Precedence = precedence;
            IsRightAssociative = isRightAssociative;
        }
    }

    /// <summary>
    /// Supported Operator Types
    /// </summary>
    public enum Operators
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        OpenBracket,
        CloseBracket,
        Power,
        Function
    }
}