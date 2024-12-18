using Laboration2_bookstore.Model;
using System;
using System.Collections.Generic;

namespace Laboration2_bookstore;

public partial class Author
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public DateOnly? Birthdate { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

}
