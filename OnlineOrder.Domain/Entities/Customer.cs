using System.ComponentModel.DataAnnotations;
using OnlineOrder.Domain.Helpers.Models;

namespace OnlineOrder.Domain.Entities;

public class Customer : IAggregateRoot
{
    [MaxLength(25, ErrorMessage="FirstName must be 25 characters or less")]
    public string? FirstName { get; set; }
    
    [MaxLength(50, ErrorMessage="FirstName must be 50 characters or less")]
    public string? LastName { get; set; }
}