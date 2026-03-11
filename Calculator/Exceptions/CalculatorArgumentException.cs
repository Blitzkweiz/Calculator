namespace Calculator.Exceptions
{
    public class CalculatorArgumentException : CalculatorException
    {
        public CalculatorArgumentException() { }
        public CalculatorArgumentException(string argument) : base($"Calculator argument exception. Invalid argument: {argument}") { }
    }
}
