namespace Calculator.Exceptions
{
    public class NotEnoughArgumentsException : CalculatorException
    {
        public NotEnoughArgumentsException() { }
        public NotEnoughArgumentsException(string message) : base(message) { }
        public NotEnoughArgumentsException(int expectedArgumentsCount, int actualArgumentsCount) : base($"Expected '{expectedArgumentsCount}' arguments but '{actualArgumentsCount}' received") { }
    }
}
