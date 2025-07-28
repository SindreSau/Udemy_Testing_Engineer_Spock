namespace Business.Tests;

[TestFixture]
public class Asserts
{
    // Is is typically used for asserting that a condition is true.
    [Test]
    public void AssertIs()
    {
        Assert.That(true, Is.True);
        Assert.That(false, Is.False);
        Assert.That(1, Is.EqualTo(1));
        Assert.That("Hello", Is.EqualTo("Hello"));
        Assert.That(1, Is.Not.EqualTo(2));
    }

    // Does is typically used with strings or collections to assert that they contain certain elements or match certain patterns.
    [Test]
    public void AssertDoes()
    {
        Assert.That("Hello World", Does.Contain("World"));
        Assert.That(new[] { 1, 2, 3 }, Does.Contain(2));
        Assert.That("Hello", Does.StartWith("Hel"));
        Assert.That("Hello", Does.EndWith("lo"));
        Assert.That(new[] { 1, 2, 3 }, Does.Not.Contain(4));
    }

    // Has is typically used to assert that an object has certain properties or characteristics.
    [Test]
    public void AssertHas()
    {
        var person = new { Name = "John", Age = 30 };
        Assert.That(person, Has.Property("Name").EqualTo("John"));
        Assert.That(person, Has.Property("Age").GreaterThan(20));
        Assert.That(new[] { 1, 2, 3 }, Has.Length.EqualTo(3));
        Assert.That(new[] { 1, 2, 3 }, Has.Some.EqualTo(2));
    }

    // Or and And are used to combine multiple assertions.
    [Test]
    public void AssertOrAnd()
    {
        Assert.That(1, Is.EqualTo(1).Or.EqualTo(2));
        Assert.That("Hello", Is.EqualTo("Hello").And.Not.Empty);
        Assert.That(new[] { 1, 2, 3 }, Has.Length.EqualTo(3).And.Contain(2));
        Assert.That(true, Is.True.Or.False);
    }

    // Floating point numbers can be asserted with a tolerance as they can be imprecise due to how they are represented in memory.
    [Test]
    public void AssertFloatingPoint()
    {
        Assert.That(0.1 + 0.2, Is.EqualTo(0.3).Within(0.0001));
        Assert.That(Math.PI, Is.EqualTo(3.14).Within(0.01));
        Assert.That(Math.E, Is.GreaterThan(2.7).And.LessThan(2.8));

        // Or using AreEqual with a tolerance
        Assert.AreEqual(0.1 + 0.2, 0.3, 0.0001);
    }
}