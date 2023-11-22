using System;
using System.Collections.Generic;

namespace Labb2._0_BlazorApp.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? Price { get; set; }

    public virtual Customer? Customer { get; set; }
}
