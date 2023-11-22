using System;
using System.Collections.Generic;

namespace Labb2._0_BlazorApp.Models;

public partial class Store
{
    public int StoreId { get; set; }

    public string? StoreNamn { get; set; }

    public string? Storedress { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
