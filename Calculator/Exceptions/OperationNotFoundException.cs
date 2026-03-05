namespace Calculator.Exceptions
{
    public class OperationNotFoundException : CalculatorException
    {
        public OperationNotFoundException() { }
        public OperationNotFoundException(string message) : base(message) { }
    }
}
