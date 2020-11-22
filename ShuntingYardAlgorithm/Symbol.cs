namespace ShuntingYardAlgorithm
{
    /// <summary>
    /// Base class which Operator and Operand inherit
    /// </summary>
    public class Symbol
    {
        /// <summary>
        /// Base class which Operator and Operand inherit
        /// </summary>
        /// <param name="value">The value of the symbol</param>
        public Symbol(string value) => _value = value;

        private string _value;
        /// <summary>
        /// Gets the value of the symbol
        /// </summary>
        /// <returns>The value of the symbol</returns>
        public override string ToString() => _value;
    }
}