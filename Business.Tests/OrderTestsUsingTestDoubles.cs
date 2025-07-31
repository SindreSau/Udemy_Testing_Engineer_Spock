using Moq;

namespace Business.Tests;

public class StubOrderRepository : IOrderRepository
{
    public Order GetById(int id)
    {
        return new Order
        {
            Id = id,
            CustomerId = 1,
            Amount = 100.00m,
            Status = "Pending",
            CreatedDate = DateTime.Now
        };
    }

    public void Save(Order order)
    {
        // Simulate saving the order, no action needed for stub
    }

    public List<Order> GetByCustomerId(int customerId)
    {
        return new List<Order>
        {
            new()
            {
                Id = 1,
                CustomerId = customerId,
                Amount = 100.00m,
                Status = "Pending",
                CreatedDate = DateTime.Now
            },
            new()
            {
                Id = 2,
                CustomerId = customerId,
                Amount = 200.00m,
                Status = "Completed",
                CreatedDate = DateTime.Now.AddDays(-1)
            }
        };
    }
}

public class FakeOrderRepository : IOrderRepository
{
    private readonly List<Order> _orders = [];

    public Order GetById(int id)
    {
        return _orders.FirstOrDefault(o => o.Id == id) ??
               throw new KeyNotFoundException($"Order with ID {id} not found.");
    }

    public void Save(Order order)
    {
        _orders.Add(order);
    }

    public List<Order> GetByCustomerId(int customerId)
    {
        return _orders.Where(o => o.CustomerId == customerId).ToList();
    }
}

[TestFixture]
public class OrderTestsUsingTestDoubles
{
    // Stub: pre-programmed return values for method calls
    [Test]
    public void GetById_Should_ReturnTestOrder()
    {
        IOrderRepository orderRepository = new StubOrderRepository();
        var sut = new OrderService(orderRepository);
        const int anyId = 42;

        Assert.Multiple(() =>
        {
            Assert.That(sut.GetOrder(anyId), Is.Not.Null);
            Assert.That(sut.GetOrder(anyId).Id, Is.EqualTo(anyId));
            Assert.That(sut.GetOrder(anyId).CustomerId, Is.EqualTo(1));
            Assert.That(sut.GetOrder(anyId).Amount, Is.EqualTo(100.00m));
            Assert.That(sut.GetOrder(anyId).Status, Is.EqualTo("Pending"));
            Assert.That(sut.GetOrder(anyId).CreatedDate, Is.Not.EqualTo(DateTime.MinValue));
        });
    }

    // Mock: verify interactions with a mock object - i define expectations
    [Test]
    public void CreateOrder_Should_SaveOrder()
    {
        var mockRepository = new Mock<IOrderRepository>();
        var sut = new OrderService(mockRepository.Object);
        const int customerId = 1;
        const decimal amount = 150.00m;

        sut.CreateOrder(customerId, amount);

        mockRepository.Verify(repo => repo.Save(It.Is<Order>(o =>
            o.CustomerId == customerId &&
            o.Amount == amount &&
            o.Status == "Pending" &&
            o.CreatedDate != DateTime.MinValue
        )), Times.Once);
    }

    // Spy: a spy is a mock that records how it was used
    [Test]
    public void CreateOrderSpy_Should_RecordSaveCall()
    {
        var savedOrders = new List<Order>();
        var spyRepository = new Mock<IOrderRepository>();
        spyRepository.Setup(r => r.Save(It.IsAny<Order>()))
            .Callback<Order>(o => savedOrders.Add(o));
        var sut = new OrderService(spyRepository.Object);
        const int customerId = 2;
        const decimal amount = 50.00m;

        sut.CreateOrder(customerId, amount);

        Assert.That(savedOrders, Has.Count.EqualTo(1));
        var savedOrder = savedOrders[0];
        Assert.Multiple(() =>
        {
            Assert.That(savedOrder.CustomerId, Is.EqualTo(customerId));
            Assert.That(savedOrder.Amount, Is.EqualTo(amount));
            Assert.That(savedOrder.Status, Is.EqualTo("Pending"));
            Assert.That(savedOrder.CreatedDate, Is.Not.EqualTo(DateTime.MinValue));
        });
    }

    // Fake: a fake is a working implementation, but not suitable for production use
    [Test]
    public void GetCustomerTotal_Should_ReturnTotalAmountForCustomer()
    {
        IOrderRepository fakeRepository = new FakeOrderRepository();
        var sut = new OrderService(fakeRepository);
        const int customerId = 1;

        // Add some test data to the fake repository
        fakeRepository.Save(new Order
            { Id = 1, CustomerId = customerId, Amount = 100.00m, Status = "Pending", CreatedDate = DateTime.Now });
        fakeRepository.Save(new Order
        {
            Id = 2, CustomerId = customerId, Amount = 200.00m, Status = "Completed",
            CreatedDate = DateTime.Now.AddDays(-1)
        });

        var totalAmount = sut.GetCustomerTotal(customerId);
        Assert.Multiple(() =>
        {
            Assert.That(totalAmount, Is.EqualTo(300.00m));
            Assert.That(fakeRepository.GetByCustomerId(customerId), Has.Count.EqualTo(2));
        });
    }
}