using NUnit.Framework;

public class CalculatorTests
{
    [Test]
    public void Add_ShouldReturnSum()
    {
        var calculator = new Calculator();
        var result = calculator.Add(2, 3);
        Assert.AreEqual(5, result);
    }
}
