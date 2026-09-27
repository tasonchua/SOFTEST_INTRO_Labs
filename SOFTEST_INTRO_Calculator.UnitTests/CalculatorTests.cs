using SOFTEST_INTRO_Calculator;
using NUnit.Framework;

namespace SOFTEST_INTRO_Calculator.UnitTests;

public class CalculatorTests
{
    private Calculator _calculator = null!;

    [SetUp]
    public void SetUp()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        // Arrange: the calculator is created in SetUp.

        // Act
        double result = _calculator.Add(10, 20);

        // Assert
        Assert.That(result, Is.EqualTo(30));
    }

    [Test]
    public void Subtract_TwoPositiveNumbers_ReturnsDifference()
    {
        double result = _calculator.Subtract(10, 4);

        Assert.That(result, Is.EqualTo(6));
    }

    [Test]
    public void Multiply_TwoPositiveNumbers_ReturnsProduct()
    {
        double result = _calculator.Multiply(5, 4);

        Assert.That(result, Is.EqualTo(20));
    }
    [TestCase(10, 4, 6)]
    [TestCase(0, 5, -5)]
    [TestCase(-3, -7, 4)]
    public void Subtract_RepresentativeInputs_ReturnsDifference(
        double a, double b, double expected)
    {
        double result = _calculator.Subtract(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }
    [TestCase(5, 4, 20)]
    [TestCase(0, 8, 0)]
    [TestCase(-3, 4, -12)]
    public void Multiply_RepresentativeInputs_ReturnsProduct(
        double a, double b, double expected)
    {
        double result = _calculator.Multiply(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }
    [TestCase(0, 0, 0)]
    [TestCase(0, 5, 5)]
    [TestCase(-3, 8, 5)]
    [TestCase(0.1, 0.2, 0.3)]
    public void Add_RepresentativeInputs_ReturnsSum(
        double a, double b, double expected)
    {
        double result = _calculator.Add(a, b);

        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }
    [TestCase(1, 2, 0.5)]
    [TestCase(0, 15, 0)]
    [TestCase(15, -3, -5)]
    public void Divide_ValidInputs_ReturnsQuotient(
        double a, double b, double expected)
    {
        double result = _calculator.Divide(a, b);

        Assert.That(result, Is.EqualTo(expected));
    }
    [TestCase(15, 0)]
    [TestCase(0, 0)]
    public void Divide_ZeroDivisor_ThrowsArgumentException(
        double a, double b)
    {
        Assert.That(
            () => _calculator.Divide(a, b),
            Throws.TypeOf<ArgumentException>());
    }
    [Test]
    public void Factorial_Zero_ReturnsOne()
    {
        long result = _calculator.Factorial(0);

        Assert.That(result, Is.EqualTo(1L));
    }
    [TestCase(1, 1L)]
    [TestCase(5, 120L)]
    [TestCase(20, 2432902008176640000L)]
    public void Factorial_ValidInput_ReturnsFactorial(
        int n, long expected)
    {
        long result = _calculator.Factorial(n);

        Assert.That(result, Is.EqualTo(expected));
    }
    [TestCase(-1)]
    [TestCase(21)]
    public void Factorial_OutOfRange_ThrowsArgumentOutOfRangeException(int n)
    {
        Assert.That(
            () => _calculator.Factorial(n),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
    [Test]
    public void TriangleArea_PositiveDimensions_ReturnsArea()
    {
        double result = _calculator.TriangleArea(3, 4);

        Assert.That(result, Is.EqualTo(6));
    }
    [TestCase(0, 4, 0)]
    [TestCase(3, 0, 0)]
    public void TriangleArea_ZeroDimension_ReturnsZero(
        double height, double width, double expected)
    {
        double result = _calculator.TriangleArea(height, width);

        Assert.That(result, Is.EqualTo(expected));
    }
    [TestCase(-3, 4)]
    [TestCase(3, -4)]
    public void TriangleArea_NegativeDimension_ThrowsArgumentOutOfRangeException(
        double height, double width)
    {
        Assert.That(
            () => _calculator.TriangleArea(height, width),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
    [Test]
    public void CircleArea_RadiusOne_ReturnsPi()
    {
        double result = _calculator.CircleArea(1);

        Assert.That(result, Is.EqualTo(Math.PI).Within(1e-9));
    }
    [Test]
    public void CircleArea_ZeroRadius_ReturnsZero()
    {
        double result = _calculator.CircleArea(0);

        Assert.That(result, Is.EqualTo(0));
    }
    [Test]
    public void CircleArea_NegativeRadius_ThrowsArgumentOutOfRangeException()
    {
        Assert.That(
            () => _calculator.CircleArea(-1),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
    [TestCase(5, 5, 120L)]
    [TestCase(5, 4, 120L)]
    [TestCase(5, 3, 60L)]
    [TestCase(5, 0, 1L)]
    [TestCase(0, 0, 1L)]
    [TestCase(6, 2, 30L)]
    public void UnknownFunctionA_ValidInputs_ReturnsExpected(
        int n, int r, long expected)
    {
        long result = _calculator.UnknownFunctionA(n, r);

        Assert.That(result, Is.EqualTo(expected));
    }
    [TestCase(5, 5, 1L)]
    [TestCase(5, 4, 5L)]
    [TestCase(5, 3, 10L)]
    [TestCase(5, 0, 1L)]
    [TestCase(0, 0, 1L)]
    [TestCase(6, 2, 15L)]
    public void UnknownFunctionB_ValidInputs_ReturnsExpected(
        int n, int r, long expected)
    {
        long result = _calculator.UnknownFunctionB(n, r);

        Assert.That(result, Is.EqualTo(expected));
    }
    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    [TestCase(5, -1)]
    [TestCase(21, 1)]
    public void UnknownFunctionA_InvalidInputs_ThrowsArgumentOutOfRangeException(
        int n, int r)
    {
        Assert.That(
            () => _calculator.UnknownFunctionA(n, r),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    [TestCase(5, -1)]
    [TestCase(21, 1)]
    public void UnknownFunctionB_InvalidInputs_ThrowsArgumentOutOfRangeException(
        int n, int r)
    {
        Assert.That(
            () => _calculator.UnknownFunctionB(n, r),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
    [Test]
    public void CalculateMTBF_ValidInputs_ReturnsExpectedValue()
    {
        double result = _calculator.CalculateMTBF(1000, 10);

        Assert.That(result, Is.EqualTo(100).Within(1e-9));
    }

    [TestCase(0, 10)]
    [TestCase(-100, 10)]
    [TestCase(1000, 0)]
    [TestCase(1000, -5)]
    public void CalculateMTBF_InvalidInputs_ThrowsArgumentOutOfRangeException(
        double operatingTime,
        int failures)
    {
        Assert.That(
            () => _calculator.CalculateMTBF(operatingTime, failures),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
    [Test]
    public void CalculateAvailability_ValidInputs_ReturnsExpectedValue()
    {
        double result = _calculator.CalculateAvailability(90, 10);

        Assert.That(result, Is.EqualTo(0.9).Within(1e-9));
    }

    [TestCase(-1, 10)]
    [TestCase(90, -1)]
    [TestCase(0, 0)]
    public void CalculateAvailability_InvalidInputs_ThrowsArgumentOutOfRangeException(
        double mtbf,
        double mttr)
    {
        Assert.That(
            () => _calculator.CalculateAvailability(mtbf, mttr),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void CalculateCurrentFailureIntensity_ZeroTime_ReturnsInitialIntensity()
    {
        double result =
            _calculator.CalculateCurrentFailureIntensity(
                10, 100, 0);

        Assert.That(result, Is.EqualTo(10).Within(1e-9));
    }

    [Test]
    public void CalculateCurrentFailureIntensity_PositiveTime_ReturnsExpectedValue()
    {
        double result =
            _calculator.CalculateCurrentFailureIntensity(
                10, 100, 5);

        Assert.That(
            result,
            Is.EqualTo(6.065306597126334).Within(1e-9));
    }

    [Test]
    public void CalculateExpectedCumulativeFailures_ZeroTime_ReturnsZero()
    {
        double result =
            _calculator.CalculateExpectedCumulativeFailures(
                10, 100, 0);

        Assert.That(result, Is.EqualTo(0).Within(1e-9));
    }

    [Test]
    public void CalculateExpectedCumulativeFailures_PositiveTime_ReturnsExpectedValue()
    {
        double result =
            _calculator.CalculateExpectedCumulativeFailures(
                10, 100, 5);

        Assert.That(
            result,
            Is.EqualTo(39.346934028736655).Within(1e-9));
    }

[TestCase(0, 100, 5)]
[TestCase(-1, 100, 5)]
[TestCase(10, 0, 5)]
[TestCase(10, -1, 5)]
[TestCase(10, 100, -1)]
public void CalculateCurrentFailureIntensity_InvalidInput_ThrowsArgumentOutOfRangeException(
    double lambda0,
    double nu0,
    double tau)
{
    Assert.That(
        () => _calculator.CalculateCurrentFailureIntensity(
            lambda0, nu0, tau),
        Throws.TypeOf<ArgumentOutOfRangeException>());
}

[TestCase(0, 100, 5)]
[TestCase(-1, 100, 5)]
[TestCase(10, 0, 5)]
[TestCase(10, -1, 5)]
[TestCase(10, 100, -1)]
public void CalculateExpectedCumulativeFailures_InvalidInput_ThrowsArgumentOutOfRangeException(
    double lambda0,
    double nu0,
    double tau)
{
    Assert.That(
        () => _calculator.CalculateExpectedCumulativeFailures(
            lambda0, nu0, tau),
        Throws.TypeOf<ArgumentOutOfRangeException>());
}

}