using System;
using System.Collections.Generic;

namespace Laboration2_bookstore.Model;

public partial class Book
{
    public string Isbn13 { get; set; } = null!;

    public string? Title { get; set; }

    public double? Price { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public int? AuthorId { get; set; }

    public virtual Author? Author { get; set; }

}
