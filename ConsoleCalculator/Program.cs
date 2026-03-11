using Calculator.Exceptions;

var calculator = new Calculator.Calculator();

var exitCommand = "exit";
var argumentsSeparators = new char[] { ' ', '\t' };

Console.WriteLine("Welcome to Calculator\n");
Console.WriteLine("Available operations:");
foreach (var operation in calculator.GetAvailableOperations())
{
    Console.WriteLine(operation);
}

Console.WriteLine($"To exit program write '{exitCommand}'");

while (true)
{
    try
    {
        Console.Write("op: ");
        var operationName = Console.ReadLine();

        if (string.IsNullOrEmpty(operationName))
        {
            throw new OperationNotFoundException();
        }
        if (operationName.Contains(exitCommand)) break;

        Console.Write("args: ");
        var argumentsLine = Console.ReadLine();

        if (string.IsNullOrEmpty(argumentsLine))
        {
            throw new NotEnoughArgumentsException("Empty arguments");
        }
        if (argumentsLine.Contains(exitCommand)) break;

        var argumentsStrings = argumentsLine.Split(argumentsSeparators, StringSplitOptions.RemoveEmptyEntries);

        double[] arguments = new double[argumentsStrings.Length];
        for (int i = 0; i < argumentsStrings.Length; i++)
        {
            if (!double.TryParse(argumentsStrings[i], out arguments[i]))
            {
                throw new CalculatorArgumentException(argumentsStrings[i]);
            }
        }

        var result = calculator.Calculate(operationName, arguments);
        Console.WriteLine($"Result: {result}\n");
    }
    catch (CalculatorException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (Exception e)
    {
        Console.WriteLine($"Unexpected Exception. {e.Message}");
    }
}
