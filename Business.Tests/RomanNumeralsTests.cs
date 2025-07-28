namespace Business.Tests;

[TestFixture]
public class RomanNumeralsTests
{
    [Test]
    [
        TestCase("", 0),

        TestCase("I", 1),
        TestCase("V", 5),
        TestCase("X", 10),
        TestCase("L", 50),
        TestCase("C", 100),
        TestCase("D", 500),
        TestCase("M", 1000),

        TestCase("III", 3),
        TestCase("VII", 7),
        TestCase("VI", 6),
        TestCase("IV", 4),

        TestCase("XLIV", 44),
        TestCase("XCIX", 99),
        TestCase("CDXLIV", 444),
        TestCase("CMXCIX", 999),
        TestCase("MMXXIII", 2023),
        TestCase("MMMDCCCLXXXVIII", 3888),
    ]
    public void Parse_GivenRomanNumeralString_ReturnsCorrectNumber(string numerals, int expected)
    {
        Assert.That(expected, Is.EqualTo(RomanNumerals.Parse(numerals)));
    }
}