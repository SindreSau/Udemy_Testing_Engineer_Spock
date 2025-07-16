namespace Business.Tests;

[TestFixture]
public class SerialPortParserTests
{
    [Test]
    public void ParsePort_COM1_Returns1()
    {
        int result = SerialPortParser.ParsePort("COM1");
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    [Category("Exception")]
    public void ParsePort_InvalidFormat_ThrowsInvalidFormatException()
    {
        TestDelegate action = () => SerialPortParser.ParsePort("1");
        Assert.Throws<FormatException>(action);
    }
}