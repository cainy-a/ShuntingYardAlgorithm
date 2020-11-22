namespace ShuntingYardAlgorithm
{
    public class Operator : Symbol
    {
        public int Precedence;

        public bool IsRightAssociative;

        public Operators Op;

        public Operator(string value, Operators op, int precedence, bool isRightAssociative = false) : base(value)
        {
            Op = op;
            Precedence = precedence;
            IsRightAssociative = isRightAssociative;
        }
    }

    public enum Operators
    {
        Addition,
        Subtraction,
        Multiplication,
        Division,
        OpenBracket,
        CloseBracket,
        Power
    }
}