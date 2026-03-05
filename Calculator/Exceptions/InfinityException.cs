namespace Calculator.Exceptions
{
    public class InfinityException : CalculatorException
    {
        public InfinityException() { }
        public InfinityException(string message) : base(message) { }
        public InfinityException(string operationName, string arguments) : base($"For operation '{operationName}' with arguments '{arguments}' result is infinity") { }
    }
}
