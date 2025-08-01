using System.Diagnostics;

namespace Business.Tests;

[TestFixture]
public class FibonacciTests
{
    [TestCase(0, 0)]
    [TestCase(1, 1)]
    [TestCase(2, 1)]
    [TestCase(3, 2)]
    [TestCase(4, 3)]
    [TestCase(5, 5)]
    [TestCase(6, 8)]
    public void TestFibonacci(int i, int expected)
    {
        Assert.That(GetFibonacciFast(i), Is.EqualTo(expected));
    }

    [Test]
    public void TimeFibonacci()
    {
        int[] inputs = { 10, 20, 40 };
        foreach (var n in inputs)
        {
            var sw = Stopwatch.StartNew();
            _ = GetFibonacciFast(n);
            sw.Stop();
            Assert.That(sw.ElapsedMilliseconds, Is.LessThan(500),
                $"Fibonacci({n}) took too long: {sw.ElapsedMilliseconds} ms");
        }
    }

    private static int GetFibonacciSlow(int i)
    {
        return i switch
        {
            0 => 0,
            1 => 1,
            _ => GetFibonacciSlow(i - 1) + GetFibonacciSlow(i - 2)
        };
    }

    private static int GetFibonacciFast(int i)
    {
        if (i <= 1) return i;

        int a = 0, b = 1;
        for (var j = 2; j <= i; j++)
        {
            var temp = a + b;
            a = b;
            b = temp;
        }

        return b;
    }
}