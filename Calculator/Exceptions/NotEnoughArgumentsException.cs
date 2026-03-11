namespace Calculator.Exceptions
{
    public class NotEnoughArgumentsException : CalculatorException
    {
        public NotEnoughArgumentsException() { }
        public NotEnoughArgumentsException(string message) : base($"Not enough arguments exception. {message}") { }
        public NotEnoughArgumentsException(int expectedArgumentsCount, int actualArgumentsCount) : base($"Not enough arguments exception. Expected '{expectedArgumentsCount}' arguments but '{actualArgumentsCount}' received") { }
    }
}
