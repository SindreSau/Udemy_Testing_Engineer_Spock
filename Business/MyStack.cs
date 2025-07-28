namespace Business;

public class MyStack<T>
{
    private readonly List<T> _list = [];
    public int Count => _list.Count;
    public bool IsEmpty => Count == 0;

    public void Push(T item)
    {
        _list.Add(item);
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        var item = _list[Count - 1];
        _list.RemoveAt(Count - 1);
        return item;
    }

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Stack is empty.");

        return _list[Count - 1];
    }
}