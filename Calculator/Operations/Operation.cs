using Calculator.Exceptions;

namespace Calculator.Operations
{
    public class Operation : IOperaion
    {
        private readonly Func<double[], double> function;
        private int argumentsCount;

        public Operation(Func<double[], double> function, int argumentsCount)
        {
            this.function = function;
            this.argumentsCount = argumentsCount;
        }

        public double Call(params double[] args)
        {
            if (argumentsCount == 0 || args.Length == argumentsCount)
            {
                return function(args);
            }

            throw new NotEnoughArgumentsException($"Expected {argumentsCount} arguments but {args.Length} received.");
        }
    }
}
