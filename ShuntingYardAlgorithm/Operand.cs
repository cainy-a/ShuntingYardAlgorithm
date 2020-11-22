namespace ShuntingYardAlgorithm
{
    public class Operand : Symbol
    {
        public int ToInt() => int.Parse(ToString());
        public float ToFloat() => float.Parse(ToString());

        public Operand(int value) : base(value.ToString())
        {
        }

        public Operand(float value) : base(value.ToString())
        {
        }
    }
}