using System;
using System.Collections.Generic;

namespace Laboration2_bookstore.Model;

public partial class Order
{
    public string? Item { get; set; }

    public string? CustomerId { get; set; }

    public int? StoreId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Book? ItemNavigation { get; set; }

    public virtual Store? Store { get; set; }
}
