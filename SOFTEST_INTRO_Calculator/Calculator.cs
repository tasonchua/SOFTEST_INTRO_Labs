namespace SOFTEST_INTRO_Calculator;

public class Calculator
{
    public double CircleArea(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(radius));
        }

        return Math.PI * radius * radius;
    }
    public double Add(double a, double b)
    {
        if (IsBinaryDigits(a) && IsBinaryDigits(b))
        {
            string combined =
                ((long)a).ToString() +
                ((long)b).ToString();

            return Convert.ToInt64(combined, 2);
        }

        return a + b;
    }

    private static bool IsBinaryDigits(double value)
    {
        if (value < 0 || value != Math.Truncate(value))
        {
            return false;
        }

        string text = ((long)value).ToString();

        foreach (char c in text)
        {
            if (c != '0' && c != '1')
            {
                return false;
            }
        }

        return true;
    }

    public double Subtract(double a, double b) => a - b;

    public double Multiply(double a, double b) => a * b;

    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero.");
        }

        return a / b;
    }

    public double DoOperation(double a, double b, string op)
    {
        return op switch
        {
            "a" => Add(a, b),
            "s" => Subtract(a, b),
            "m" => Multiply(a, b),
            "d" => Divide(a, b),
            _ => throw new ArgumentException("Unknown operation.")
        };
    }
    public long Factorial(int n)
    {
        if (n < 0 || n > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(n));
        }

        long result = 1;

        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
    public double TriangleArea(double height, double width)
    {
        if (height < 0 || width < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        return 0.5 * height * width;
    }
    public long UnknownFunctionA(int n, int r)
    {
        if (n < 0 || n > 20 || r < 0 || r > n)
        {
            throw new ArgumentOutOfRangeException();
        }

        return Factorial(n) / Factorial(n - r);
    }

    public long UnknownFunctionB(int n, int r)
    {
        if (n < 0 || n > 20 || r < 0 || r > n)
        {
            throw new ArgumentOutOfRangeException();
        }

        return Factorial(n) /
               (Factorial(r) * Factorial(n - r));
    }

    public double CalculateMTBF(double operatingTime, int failures)
    {
        if (operatingTime <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(operatingTime));
        }

        if (failures <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(failures));
        }

        return operatingTime / failures;
    }

    public double CalculateAvailability(double mtbf, double mttr)
    {
        if (mtbf < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(mtbf));
        }

        if (mttr < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(mttr));
        }

        if (mtbf + mttr <= 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        return mtbf / (mtbf + mttr);
    }

public double CalculateCurrentFailureIntensity(
    double lambda0,
    double nu0,
    double tau)
{
    if (lambda0 <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(lambda0));
    }

    if (nu0 <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(nu0));
    }

    if (tau < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(tau));
    }

    return lambda0 * Math.Exp(
        -(lambda0 * tau) / nu0);
}

    public double CalculateExpectedCumulativeFailures(
        double lambda0,
        double nu0,
        double tau)
    {
        if (lambda0 <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lambda0));
        }

        if (nu0 <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(nu0));
        }

        if (tau < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(tau));
        }

        return nu0 * (
            1 - Math.Exp(-(lambda0 * tau) / nu0));
    }
public double GenMagicNum(
    int choice,
    string path,
    IFileReader fileReader)
{
    ArgumentNullException.ThrowIfNull(fileReader);

    if (choice < 0)
    {
        throw new ArgumentOutOfRangeException(nameof(choice));
    }

    string[] magicStrings = fileReader.Read(path);

    if (choice >= magicStrings.Length)
    {
        throw new ArgumentOutOfRangeException(nameof(choice));
    }

    double magicNumber =
        double.Parse(magicStrings[choice]);

    return 2 * Math.Abs(magicNumber);
}

}