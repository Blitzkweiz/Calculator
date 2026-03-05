namespace Calculator.Exceptions
{
    public class OperationNotFoundException : CalculatorException
    {
        public OperationNotFoundException() { }
        public OperationNotFoundException(string operationName) : base($"Operation '{operationName}' not found") { }
    }
}
