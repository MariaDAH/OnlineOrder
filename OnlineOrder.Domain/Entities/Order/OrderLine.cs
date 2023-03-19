using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace OnlineOrder.Domain.Entities.Order;

public class OrderLine
{
    public long? Id { get; set; }
    
    public string? Title { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    [Required] public decimal? Price { get; set; }

    [Range(0, 999)] public double Grams { get; set; }

    [Required] public int? Quantity { get; set; }

    [Required] public IEnumerable<TaxLine>? TaxLine { get; set; }

    [Required] public string Sku { get; set; }
}