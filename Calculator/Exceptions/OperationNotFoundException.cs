namespace Calculator.Exceptions
{
    public class OperationNotFoundException : CalculatorException
    {
        public OperationNotFoundException() : base("Operation not found") { }
        public OperationNotFoundException(string operationName) : base($"Operation '{operationName}' not found") { }
    }
}
