using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
    private readonly CalculatorContext _context;
    private readonly BasicReliabilityContext _reliability;

    public UsingCalculatorBasicReliabilitySteps(
        CalculatorContext context,
        BasicReliabilityContext reliability)
    {
        _context = context;
        _reliability = reliability;
    }

    [Given("the Basic Musa values are {double}, {double} and {double} hours")]
    public void GivenTheBasicMusaValuesAre(
        double lambda0,
        double nu0,
        double tau)
    {
        _reliability.Lambda0 = lambda0;
        _reliability.Nu0 = nu0;
        _reliability.Tau = tau;
    }

    [When("I calculate the current failure intensity")]
    public void WhenICalculateTheCurrentFailureIntensity()
    {
        _context.Result = null;
        _context.Error = null;

        try
        {
            _context.Result =
                _context.Calculator.CalculateCurrentFailureIntensity(
                    _reliability.Lambda0,
                    _reliability.Nu0,
                    _reliability.Tau);
        }
        catch (ArgumentOutOfRangeException error)
        {
            _context.Error = error;
        }
    }

    [When("I calculate the expected cumulative failures")]
    public void WhenICalculateTheExpectedCumulativeFailures()
    {
        _context.Result = null;
        _context.Error = null;

        try
        {
            _context.Result =
                _context.Calculator.CalculateExpectedCumulativeFailures(
                    _reliability.Lambda0,
                    _reliability.Nu0,
                    _reliability.Tau);
        }
        catch (ArgumentOutOfRangeException error)
        {
            _context.Error = error;
        }
    }
}