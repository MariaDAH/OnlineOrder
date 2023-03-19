using OnlineOrder.Domain.Entities.Order;
using OnlineOrder.Domain.Repositories.ProductRepository;
using OnlineOrder.Infrastructure.Interfaces;
using OnlineOrder.Infrastructure.Services;

namespace OnlineOrder.Application.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly UnitOfWorkBuilder _uow;
    private readonly IUserSession _userSession;

    public OrderService(UnitOfWorkBuilder uow, IUserSession userSession)
    {
        _uow = uow;
    }

    public async Task<IEnumerable<Order>> GetAllOrdersAsync(CancellationToken cancellationToken = default)
    {
        return await _uow.OrderRepository.GetAllAsync();
    }

    public async Task<Order?> GetOrderByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _uow.OrderRepository.GetByIdAsync(id);
    }

    public async Task CreateOrderAsync(Order order, CancellationToken cancellationToken = default)
    { 
        
        //Get from user session the login details like email address, first name and last name as it is a guest user.
        await _uow.OrderRepository.AddAsync(order);
    }

    public async Task<long?> UpdateOrderAsync(Order order, CancellationToken cancellationToken = default)
    {
        var result = await _uow.OrderRepository.UpdateAsync(order);
        
        return result.Id;
    }

    public async Task<long?> DeleteOrderAsync(long id, CancellationToken cancellationToken = default)
    {
        var order = await _uow.OrderRepository.GetByIdAsync(id);
        
        var result = await _uow.OrderRepository.RemoveAsync(order);
        
        return result.Id;
    }
}