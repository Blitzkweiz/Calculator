using Calculator.Exceptions;

namespace Calculator.Operations
{
    public class Operation : IOperation
    {
        private readonly Func<double[], double> function;
        private int argumentsCount;
        private bool multipleArgumentsAvailable;

        public Operation(Func<double[], double> function, int argumentsCount, bool multipleArgumentsAvailable = false)
        {
            this.function = function;
            this.argumentsCount = argumentsCount;
            this.multipleArgumentsAvailable = multipleArgumentsAvailable;
        }

        public double Call(params double[] args)
        {
            if (args.Length == argumentsCount || (multipleArgumentsAvailable && argumentsCount < args.Length))
            {
                return function(args);
            }

            throw new NotEnoughArgumentsException(argumentsCount, args.Length);
        }
    }
}
