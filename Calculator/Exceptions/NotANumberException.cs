namespace Calculator.Exceptions
{
    public class NotANumberException : CalculatorException
    {
        public NotANumberException() { }
        public NotANumberException(string message) : base($"Not a number exception. {message}") { }
        public NotANumberException(string operationName, string arguments) : base($"Not a number exception. For operation '{operationName}' with arguments '{arguments}' result is not a number") { }
    }
}
