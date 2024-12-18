using System;
using System.Collections.Generic;

namespace Laboration2_bookstore.Model;

public partial class Customer
{
    public string CustomerId { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}
