using FirstCode;
using FluentAssertions;
using NSubstitute;

namespace FirstTest;

public class CalculatorTest
{
    private readonly Calculator _calculator;

    public CalculatorTest()
    {
        _calculator = new Calculator();
    }

    [Fact(DisplayName = "Simple equality test")]
    public void TestSum()
    {
        _calculator.Add(2.1, 3.5).Should().Be(5.6);
    }
}