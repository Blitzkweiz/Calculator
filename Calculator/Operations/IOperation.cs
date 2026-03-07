namespace Calculator.Operations
{
    public interface IOperation
    {
        double Call(params double[] args);
    }
}
