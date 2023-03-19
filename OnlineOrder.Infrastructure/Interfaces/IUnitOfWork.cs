namespace OnlineOrder.Infrastructure.Interfaces;

public interface IUnitOfWork
{
    Task Login(CancellationToken cancellationToken = default);
}