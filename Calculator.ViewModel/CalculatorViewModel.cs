using Calculator.Exceptions;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using System.Text;
using System.Windows.Input;

namespace Calculator.ViewModel
{
    public partial class CalculatorViewModel : ReactiveObject
    {
        public CalculatorViewModel()
        {
            CalculateCommand = ReactiveCommand.Create(Calculate);
            AvailableOperations = GetAvailableOperations();
        }

        private readonly Calculator calculator = new();

        [Reactive]
        public partial string Operation { get; set; }

        [Reactive]
        public partial string Arguments { get; set; }

        [Reactive]
        public partial string Result { get; set; }

        public ICommand CalculateCommand { get; set; }

        public string AvailableOperations { get; set; }

        private void Calculate()
        {
            try
            {
                var operationName = GetOperationName();
                var arguments = GetArgumentsAsArrayOfDouble();

                var result = calculator.Calculate(operationName, arguments);
                Result = result.ToString();
            }
            catch (OperationNotFoundException e)
            {
                Result = $"Operation not found exception. {e.Message}";
            }
            catch (NotEnoughArgumentsException e)
            {
                Result = $"Not enough arguments exception. {e.Message}";
            }
            catch (ArgumentException e)
            {
                Result = $"Argument exception. {e.Message}";
            }
            catch (CalculatorException e)
            {
                Result = $"Calculator Exception. {e.Message}";
            }
            catch (Exception e)
            {
                Result = $"Unexpected Exception. {e.Message}";
            }
        }

        private string GetAvailableOperations()
        {
            var sb = new StringBuilder();

            foreach (var operation in calculator.GetAvailableOperations())
            {
                sb.AppendLine(operation);
            }

            return sb.ToString();
        }

        private string GetOperationName()
        {
            if (string.IsNullOrEmpty(Operation))
            {
                throw new OperationNotFoundException(Operation);
            }

            return Operation;
        }

        private double[] GetArgumentsAsArrayOfDouble()
        {
            if (string.IsNullOrEmpty(Arguments))
            {
                throw new NotEnoughArgumentsException("Empty arguments");
            }

            var argumentsStrings = Arguments.Split([' ', '\t'], StringSplitOptions.RemoveEmptyEntries);

            double[] arguments = new double[argumentsStrings.Length];
            for (int i = 0; i < argumentsStrings.Length; i++)
            {
                if (!double.TryParse(argumentsStrings[i], out arguments[i]))
                {
                    throw new ArgumentException($"Invalid argument: {argumentsStrings[i]}");
                }
            }

            return arguments;
        }
    }
}
