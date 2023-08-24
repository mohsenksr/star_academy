namespace FirstCode;

public interface ICalculator
{
    public double Add(double a, double b);
    public double Sub(double a, double b);
    public double Mul(double a, double b);
    public double Div(double a, double b);
    public double Average(List<double> numbers);
}