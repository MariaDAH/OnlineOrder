using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using OnlineOrder.Domain.Helpers.Models;

namespace OnlineOrder.Domain.Entities.Product;

[Keyless]
public class Product : IAggregateRoot
{
    [Required]
    public long? ProductId { get; set; }
    
    [Required]
    public string? Title { get; set; }

    public string? Vendor { get; set; }
    
    public string? ProductType { get; set; }

    public Variant? ProductVariant { get; set; }
}