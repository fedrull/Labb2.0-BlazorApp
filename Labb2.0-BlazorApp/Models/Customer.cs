using System;
using System.Collections.Generic;

namespace Labb2._0_BlazorApp.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? StoreId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
