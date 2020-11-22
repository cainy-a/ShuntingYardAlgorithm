namespace ShuntingYardAlgorithm
{
    /// <summary>
    /// Represents a number in an equation
    /// </summary>
    public class Operand : Symbol
    {
        /// <summary>
        /// Gets an int representing the Operand
        /// </summary>
        /// <returns>The operand as int</returns>
        public int ToInt() => int.Parse(ToString());

        /// <summary>
        /// Gets a float representing the Operand
        /// </summary>
        /// <returns>The operand as float</returns>
        public float ToFloat() => float.Parse(ToString());

        /// <summary>
        /// Whether the Operand is int or float
        /// </summary>
        public OperandType OperandType;

        /// <summary>
        /// Represents a number (as int) in an equation
        /// </summary>
        /// <param name="value">Int represented</param>
        public Operand(int value) : base(value.ToString()) => OperandType = OperandType.Int;

        /// <summary>
        /// Represents a number (as float) in an equation
        /// </summary>
        /// <param name="value">Float represented</param>
        public Operand(float value) : base(value.ToString()) => OperandType = OperandType.Float;
    }

    public enum OperandType
    {
        Int, Float
    }
}