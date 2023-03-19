using System.ComponentModel.DataAnnotations;
using OnlineOrder.Domain.Helpers.Models;

namespace OnlineOrder.Domain.Entities.Product;

public class Product : IAggregateRoot
{
    [Required]
    public string? Title { get; set; }

    public string? Vendor { get; set; }
    
    public string? ProductType { get; set; }

    public Variant? ProductVariant { get; set; }
}