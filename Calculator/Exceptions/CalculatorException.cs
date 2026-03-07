namespace Calculator.Exceptions
{
    public abstract class CalculatorException : Exception
    {
        public CalculatorException() { }
        public CalculatorException(string message) : base(message) { }
    }
}
