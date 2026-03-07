using Calculator.Exceptions;

namespace Calculator.Tests
{
    public class CalculatorTests
    {
        public Calculator CalculatorModel { get; set; }

        [SetUp]
        public void Setup()
        {
            CalculatorModel = new Calculator();
        }

        [TestCase("+", new double[] { 1.1, 2.2 }, 3.3, TestName = "Addition Successful")]
        [TestCase("-", new double[] { 1.1, 2.2 }, -1.1, TestName = "Subtraction Successful")]
        [TestCase("*", new double[] { 1.1, 2.2 }, 2.42, TestName = "Multiplication Successful")]
        [TestCase("/", new double[] { 1.1, 2.2 }, 0.5, TestName = "Division Successful")]
        [TestCase("sin", new double[] { Math.PI }, 0, TestName = "Sin Successful")]
        [TestCase("cos", new double[] { Math.PI }, -1, TestName = "Cos Successful")]
        [TestCase("^", new double[] { 0, 0 }, 1, TestName = "Power Successful")]
        [TestCase("+", new double[] { 1.1, 2.2, 3.3, 4.4, 5.5 }, 16.5, TestName = "Addition MultipleArguments Successful")]
        [TestCase("*", new double[] { 1.1, 2.2, 3.3, 4.4, 5.5 }, 193.2612, TestName = "Multiplication MultipleArguments Successful")]
        [TestCase("-", new double[] { 1.1, 2.2, 3.3 }, -1.1, TestName = "Subtraction RedundantArgumentsIgnored Successful")]
        [TestCase("/", new double[] { 1.1, 2.2, 3.3 }, 0.5, TestName = "Division RedundantArgumentsIgnored Successful")]
        [TestCase("sin", new double[] { Math.PI, 1.1 }, 0, TestName = "Sin RedundantArgumentsIgnored Successful")]
        [TestCase("cos", new double[] { Math.PI, 1.1 }, -1, TestName = "Cos RedundantArgumentsIgnored Successful")]
        [TestCase("^", new double[] { 0, 0, 1.1 }, 1, TestName = "Power RedundantArgumentsIgnored Successful")]
        public void SuccessfulCalculatorOperationTest(string operationName, double[] arguments, double expectedResult)
        {
            var actualResult = CalculatorModel.Calculate(operationName, arguments);
            Assert.That(actualResult, Is.EqualTo(expectedResult).Within(CalculatorConstants.EPSILON), $"Unexpected calculation result. Expected: {expectedResult}, Actual: {actualResult}");
        }

        [TestCase("+", new double[] { }, TestName = "Addition NotEnoughArguments Failed")]
        [TestCase("-", new double[] { 0 }, TestName = "Subtraction NotEnoughArguments Failed")]
        [TestCase("*", new double[] { }, TestName = "Multiplication NotEnoughArguments Failed")]
        [TestCase("/", new double[] { 0 }, TestName = "Division NotEnoughArguments Failed")]
        [TestCase("sin", new double[] { }, TestName = "Sin NotEnoughArguments Failed")]
        [TestCase("cos", new double[] { }, TestName = "Cos NotEnoughArguments Failed")]
        [TestCase("^", new double[] { 0 }, TestName = "Power NotEnoughArguments Failed")]
        public void NotEnoughArgumentsForOperationTest(string operationName, double[] arguments)
        {
            Assert.Throws<NotEnoughArgumentsException>(() => CalculatorModel.Calculate(operationName, arguments), "Calculation did not throw an expected exception");
        }

        [TestCase("1", TestName = "First OperationNotFound Failed")]
        [TestCase("+-", TestName = "Multiple OperationNotFound Failed")]
        public void OperationNotFoundTest(string operationName)
        {
            Assert.Throws<OperationNotFoundException>(() => CalculatorModel.Calculate(operationName, [1.1, 2.2]), "Calculation did not throw an expected exception");
        }

        [TestCase("/", new double[] { 1, 0 }, TestName = "Division ByZero InfinityResult Failed")]
        [TestCase("^", new double[] { 0, -4 }, TestName = "Power ZeroToNegative InfinityResult Failed")]
        public void InfinityOperationResultTest(string operationName, double[] arguments)
        {
            Assert.Throws<InfinityException>(() => CalculatorModel.Calculate(operationName, arguments), "Calculation did not throw an expected exception");
        }

        [TestCase("/", new double[] { 0, 0 }, TestName = "Division ZeroByZero NotANumberResult Failed")]
        [TestCase("^", new double[] { -4, 1.23 }, TestName = "Power NegativeToNotInteger NotANumberResult Failed")]
        public void NotANumberOperationResultTest(string operationName, double[] arguments)
        {
            Assert.Throws<NotANumberException>(() => CalculatorModel.Calculate(operationName, arguments), "Calculation did not throw an expected exception");
        }
    }
}
