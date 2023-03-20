using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using OnlineOrder.Application.Services.OrderService;
using OnlineOrder.Domain.Entities.Order;
using OnlineOrder.Infrastructure.Interfaces;

namespace OnlineOrder.Application.Controllers;

/// <summary>
/// Orders API
/// </summary>
//Add back Authorize to apply built-in authorization schema
[ApiController, ApiVersion("1.0")]
[Route("v{version:apiVersion}")]
[Produces("application/json")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IOrderService _orderService;

    /// <summary>
    /// Basic operations on orders
    /// </summary>
    /// <param name="orderService"></param>
    /// <param name="logger"></param>
    public OrderController(IOrderService orderService, ILogger<OrderController> logger)
    {
        _orderService = orderService;
        _logger = logger;
    }

    /// <summary>
    /// Get list of orders
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("orders")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Order>))]
    public async Task<IActionResult> GetOrders(CancellationToken cancellationToken = default)
    {
        var orders = await _orderService.GetAllOrdersAsync(cancellationToken);
        
        return Ok(orders);
    }

    /// <summary>
    /// Get an specific order
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("order/{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Order))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById([FromRoute] long id,
        CancellationToken cancellationToken = default)
    {
        var order = await _orderService.GetOrderByIdAsync(id, cancellationToken);

        return (order == null) ? NotFound() : Ok(order);
    }

    /// <summary>
    /// Create a new resource order 
    /// </summary>
    /// <param name="order"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost("orders/order")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] Order order,
        CancellationToken cancellationToken = default)
    {
        if (!ModelState.IsValid)
        {
             return BadRequest(ModelState);
        }

        await _orderService.CreateOrderAsync(order, cancellationToken);
        
        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    /// <summary>
    /// Update an existing resource order
    /// </summary>
    /// <param name="id"></param>
    /// <param name="order"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id:long}/orders")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateOrder([FromRoute] long id,
        [FromBody] Order order,
        CancellationToken cancellationToken = default)
    {
         if (!ModelState.IsValid)
         { 
             return BadRequest(ModelState);
         }

         var updated = await _orderService.UpdateOrderAsync(order, cancellationToken);

         return (updated == null) ? NoContent() : NotFound();
    }

    /// <summary>
    /// Delete a resource order
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("orders/{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] long id,
        CancellationToken cancellationToken = default)
    {
        var deleted = await _orderService.DeleteOrderAsync(id, cancellationToken);

        return (deleted != null) ? Ok() : NotFound();
    }
}