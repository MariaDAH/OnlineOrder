using System.ComponentModel.DataAnnotations;

namespace OnlineOrder.Domain.Entities.Product;

public class Variant
{
    public long? Id { get; set; }
     
    [Required]
    public long? ProductId { get; set; }
    
    [MaxLength(150)]
    public string? Title { get; set; }
    
    [MaxLength(255)]
    public string? Description { get; set; }
    
    public double? Price { get; set; }
    
    public string? Sku { get; set; }
    
}