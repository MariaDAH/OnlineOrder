using System.ComponentModel.DataAnnotations;

namespace OnlineOrder.Domain.Entities.Order;

public class TaxLine
{
    public long? Id { get; set; }
    
    [Required] public double? Price { get; set; }

    [Required] public double? Rate { get; set; }

    public string? Title { get; set; }
}