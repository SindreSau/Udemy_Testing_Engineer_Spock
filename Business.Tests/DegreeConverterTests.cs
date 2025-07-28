namespace Business.Tests;

[TestFixture]
public class DegreeConverterTests
{
    [Theory]
    [
        TestCase(0, 32),
        TestCase(100, 212),
        TestCase(-40, -40),
        TestCase(37.5, 99.5)
    ]
    public void ToFahrenheit_GivenCelsius_ReturnsCorrectFahrenheit(double celsius, double expected)
    {
        var asFahrenheit = DegreeConverter.ToFahrenHeit(celsius);
        Assert.That(expected, Is.EqualTo(asFahrenheit));
    }

    [Theory]
    [
        TestCase(32, 0),
        TestCase(212, 100),
        TestCase(-40, -40),
        TestCase(99.5, 37.5)
    ]
    public void ToCelsius_GivenFahrenheit_ReturnsCorrectCelsius(double fahrenheit, double expected)
    {
        var asCelsius = DegreeConverter.ToCelsius(fahrenheit);
        Assert.That(expected, Is.EqualTo(asCelsius));
    }
}