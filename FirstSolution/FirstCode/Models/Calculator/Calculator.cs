namespace FirstCode;

public class Calculator : ICalculator
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Sub(double a, double b)
    {
        return a - b;
    }
    
    public double Mul(double a, double b)
    {
        return a * b;
    }

    public double Div(double a, double b)
    {
        return a / b;
    }

    public double Average(List<double> numbers)
    {
        return Div(numbers.Sum(), numbers.Count());
    }
}