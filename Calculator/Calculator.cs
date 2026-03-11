using Calculator.Exceptions;
using Calculator.Operations;
using System.Collections;

namespace Calculator
{
    public class Calculator : IEnumerable<KeyValuePair<string, IOperation>>
    {
        private readonly Dictionary<string, IOperation> operations = new()
        {
            {"+", new Operation(args => args.Sum(), argumentsCount: 1, multipleArgumentsAvailable: true)},
            {"-", new Operation(args => args[0] - args[1], argumentsCount: 2)},
            {"*", new Operation(args => args.Aggregate((x, y) => x * y), argumentsCount: 1, multipleArgumentsAvailable: true)},
            {"/", new Operation(args => args[0] / args[1], argumentsCount: 2)},
            {"sin", new Operation(args => Math.Sin(args[0]), argumentsCount: 1)},
            {"cos", new Operation(args => Math.Cos(args[0]), argumentsCount: 1)},
            {"^", new Operation(args => Math.Pow(args[0], args[1]), argumentsCount: 2)},
        };

        public double Calculate(string operationName, params double[] args)
        {
            if(operations.TryGetValue(operationName, out var operaion))
            {
                var result = operaion.Call(args);
                CheckForSpecificResult(result, operationName, args);

                return result;
            }

            throw new OperationNotFoundException(operationName);
        }

        private void CheckForSpecificResult(double result, string operationName, double[] args)
        {
            if (double.IsNaN(result))
            {
                throw new NotANumberException(operationName, string.Join(", ", args));
            }
            else if (double.IsInfinity(result))
            {
                throw new InfinityException(operationName, string.Join(", ", args));
            }
        }

        public IList<string> GetAvailableOperations()
        {
            return [.. operations.Keys];
        }

        public void Add(string key, IOperation value)
        {
            operations[key] = value;
        }

        public void Add(string key, Func<double[], double> func)
        {
            operations[key] = new Operation(func, argumentsCount: 1);
        }

        public void Add(string key, Func<double, double> func)
        {
            operations[key] = new Operation(args => func(args[0]), argumentsCount: 1);
        }

        public void Add(string key, Func<double, double, double> func)
        {
            operations[key] = new Operation(args => func(args[0], args[1]), argumentsCount: 2);
        }

        public void Add(string key, string alias)
        {
            if (operations.TryGetValue(alias, out var operation))
            {
                operations[key] = operation;
            }
            else
            {
                throw new OperationNotFoundException(alias);
            }
        }

        public IEnumerator<KeyValuePair<string, IOperation>> GetEnumerator() => operations.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
