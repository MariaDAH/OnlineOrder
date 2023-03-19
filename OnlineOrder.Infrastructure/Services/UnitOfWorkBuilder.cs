using OnlineOrder.Domain.DAOs;
using OnlineOrder.Domain.Repositories.CustomerRepository;
using OnlineOrder.Domain.Repositories.OrderRepository;
using OnlineOrder.Domain.Repositories.ProductRepository;
using OnlineOrder.Infrastructure.Interfaces;

namespace OnlineOrder.Infrastructure.Services;

public class UnitOfWorkBuilder: IUnitOfWorkBuilder
{
    private readonly ApplicationDbContext _context;
    public IOrderRepository OrderRepository { get; private set; }
    public ICustomerRepository CustomerRepository { get; private set; }
    public IProductRepository ProductRepository { get; private set; }

    public UnitOfWorkBuilder(ApplicationDbContext context)
    {
        _context = context;

        OrderRepository = new OrderRepository(_context);

        CustomerRepository = new CustomerRepository(_context);

        ProductRepository = new ProductRepository(_context);

    }
    
    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync().ConfigureAwait(false);
    }


    public async Task<int> CompleteAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// No matter an exception has been raised or not, this method always will dispose the DbContext 
    /// </summary>
    /// <returns></returns>
    public ValueTask DisposeAsync()
    {
        return _context.DisposeAsync();
    }
    
}