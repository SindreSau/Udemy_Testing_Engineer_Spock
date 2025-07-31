namespace Business;

public interface IOrderRepository
{
    Order GetById(int id);
    void Save(Order order);
    List<Order> GetByCustomerId(int customerId);
}

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public decimal Amount { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class OrderService(IOrderRepository repository)
{
    private readonly IOrderRepository _repository = repository;

    public Order CreateOrder(int customerId, decimal amount)
    {
        var order = new Order
        {
            Id = new Random().Next(1000, 9999),
            CustomerId = customerId,
            Amount = amount,
            Status = "Pending",
            CreatedDate = DateTime.Now
        };

        _repository.Save(order);
        return order;
    }

    public Order GetOrder(int orderId)
    {
        return _repository.GetById(orderId);
    }

    public decimal GetCustomerTotal(int customerId)
    {
        var orders = _repository.GetByCustomerId(customerId);
        return orders.Sum(o => o.Amount);
    }

    public void CompleteOrder(int orderId)
    {
        var order = _repository.GetById(orderId);
        order.Status = "Completed";
        _repository.Save(order);
    }
}