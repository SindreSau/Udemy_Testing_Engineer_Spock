namespace Business.Tests;

[TestFixture]
public class FizzBuzzTests
{
    [Test]
    [
        TestCase(0, "FizzBuzz"),
        TestCase(15, "FizzBuzz"),
        TestCase(3, "Fizz"),
        TestCase(6, "Fizz"),
        TestCase(5, "Buzz"),
        TestCase(10, "Buzz"),
        TestCase(2, "")
    ]
    public void FizzBuzzTest(int number, string expected)
    {
        Assert.That(
            expected,
            Is.EqualTo(FizzBuzz.Ask(number))
            );
    }
}