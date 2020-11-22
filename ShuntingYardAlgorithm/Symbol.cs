namespace ShuntingYardAlgorithm
{
    public class Symbol
    {
        public Symbol(string value) => _value = value;

        private string _value;
        public override string ToString() => _value;
    }
}