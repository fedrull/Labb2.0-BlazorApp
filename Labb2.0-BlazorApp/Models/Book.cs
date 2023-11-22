using System;
using System.Collections.Generic;

namespace Labb2._0_BlazorApp.Models;

public partial class Book
{
    public string Isbn13 { get; set; } = null!;

    public string? Title { get; set; }

    public string? Category { get; set; }

    public string? Languege { get; set; }

    public DateTime? ReleaseDate { get; set; }

    public int? PublisherId { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
