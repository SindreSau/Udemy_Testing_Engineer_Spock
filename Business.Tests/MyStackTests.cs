namespace Business.Tests;

[TestFixture]
public class MyStackTests
{
    [SetUp]
    public void Setup()
    {
        _strings = new MyStack<string>();
        _people = new MyStack<Person>();
    }

    private MyStack<string> _strings;
    private MyStack<Person> _people;

    [Test]
    public void Push_GivenString_ShouldAddString()
    {
        _strings.Push("Hello");

        Assert.That(_strings.Count, Is.EqualTo(1));
        Assert.That(_strings.Peek(), Is.EqualTo("Hello"));
    }

    [Test]
    public void Push_GivenPerson_ShouldAddPerson()
    {
        var person = new Person("Sindre", 29);
        _people.Push(person);

        Assert.That(_people.Count, Is.EqualTo(1));
        Assert.That(_people.Peek(), Is.EqualTo(person));
    }

    [Test]
    public void Pop_GivenEmpty_ShouldThrowException()
    {
        Assert.That(_strings.IsEmpty, Is.True);
        Assert.Throws<InvalidOperationException>(() => _strings.Pop());
    }

    [Test]
    public void Peek_GivenEmpty_ShouldThrowException()
    {
        Assert.That(_strings.IsEmpty, Is.True);
        Assert.Throws<InvalidOperationException>(() => _strings.Peek());
    }

    [Test]
    public void Peek_ShouldReturnLatestAddedItem()
    {
        _strings.Push("Hello");
        _strings.Push("World");
        _strings.Push("!");

        Assert.That(_strings.Peek(), Is.EqualTo("!"));
    }

    [Test]
    public void Pop_ShouldRemoveLastAddedItem()
    {
        _strings.Push("Hello");
        _strings.Push("World");

        _strings.Pop();

        Assert.That(_strings.Count, Is.EqualTo(1));
        Assert.That(_strings.Peek(), Is.EqualTo("Hello"));
    }

    [Test]
    public void Stack_ShouldFollowLastInFirstOut()
    {
        _strings.Push("First");
        _strings.Push("Second");
        _strings.Push("Third");

        Assert.That(_strings.Pop(), Is.EqualTo("Third"));
        Assert.That(_strings.Pop(), Is.EqualTo("Second"));
        Assert.That(_strings.Pop(), Is.EqualTo("First"));
        Assert.That(_strings.IsEmpty, Is.True);
    }

    private class Person(string name, int age)
    {
        public int Age = age;
        public string Name = name;
    }
}