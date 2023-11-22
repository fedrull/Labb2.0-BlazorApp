using System;
using System.Collections.Generic;

namespace Labb2._0_BlazorApp.Models;

public partial class Inventory
{
    public int InventoryId { get; set; }

    public string Isbn { get; set; } = null!;

    public int? Stock { get; set; }

    public virtual Store InventoryNavigation { get; set; } = null!;

    public virtual Book IsbnNavigation { get; set; } = null!;
}
