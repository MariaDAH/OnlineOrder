using OnlineOrder.Domain.DAOs;
using OnlineOrder.Domain.Entities;

namespace OnlineOrder.Domain.Repositories.CustomerRepository;

public class CustomerRepository: GenericRepository<Customer>, ICustomerRepository
{
    public CustomerRepository(ApplicationDbContext context) : base(context)
    {
            
    }
    
    public ApplicationDbContext OnlineOrderDao
    {
        get { return Context as ApplicationDbContext; }
    }
}