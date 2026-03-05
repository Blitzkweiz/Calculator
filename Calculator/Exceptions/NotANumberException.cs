namespace Calculator.Exceptions
{
    public class NotANumberException : CalculatorException
    {
        public NotANumberException() { }
        public NotANumberException(string message) : base(message) { }
        public NotANumberException(string operationName, string arguments) : base($"For operation '{operationName}' with arguments '{arguments}' result is not a number") { }
    }
}
