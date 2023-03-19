using OnlineOrder.Infrastructure.Interfaces;

namespace OnlineOrder.Application.HttpSession;

/// <summary>
/// 
/// </summary>
public class UnitOfWorkMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="next"></param>
    public UnitOfWorkMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="uow"></param>
    public async Task InvokeAsync(HttpContext context, IUnitOfWork uow)
    {
        await uow.Login(context.RequestAborted);
        await _next(context);
    }
}