namespace Calculator.Exceptions
{
    public class InfinityException : CalculatorException
    {
        public InfinityException() { }
        public InfinityException(string message) : base($"Infinity exception. {message}") { }
        public InfinityException(string operationName, string arguments) : base($"Infinity exception. For operation '{operationName}' with arguments '{arguments}' result is infinity") { }
    }
}
