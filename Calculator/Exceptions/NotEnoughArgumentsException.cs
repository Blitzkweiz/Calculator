namespace Calculator.Exceptions
{
    public class NotEnoughArgumentsException : CalculatorException
    {
        public NotEnoughArgumentsException() { }
        public NotEnoughArgumentsException(string message) : base(message) { }
    }
}
