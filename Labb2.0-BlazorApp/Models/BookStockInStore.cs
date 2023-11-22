using System;
using System.Collections.Generic;

namespace Labb2._0_BlazorApp.Models;

public partial class BookStockInStore
{
    public string Isbn13 { get; set; } = null!;

    public string? Title { get; set; }

    public string? Category { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int InventoryId { get; set; }

    public int? Stock { get; set; }

    public int StoreId { get; set; }
}
