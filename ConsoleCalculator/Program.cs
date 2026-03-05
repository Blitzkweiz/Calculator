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
            throw new OperationNotFoundException(operationName);
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
                throw new ArgumentException($"Invalid argument: {argumentsStrings[i]}");
            }
        }

        var result = calculator.Calculate(operationName, arguments);
        Console.WriteLine($"Result: {result}\n");
    }
    catch (OperationNotFoundException e)
    {
        Console.WriteLine($"Operation not found exception. {e.Message}");
    }
    catch (NotEnoughArgumentsException e)
    {
        Console.WriteLine($"Not enough arguments exception. {e.Message}");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine($"Argument exception. {e.Message}");
    }
    catch (CalculatorException e)
    {
        Console.WriteLine($"Calculator Exception. {e.Message}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"Unexpected Exception. {e.Message}");
    }
}
