using System;
using System.Collections.Generic;

namespace Laboration2_bookstore.Model;

public partial class Inventory
{
    public string Isbn { get; set; } = null!;

    public int StoreId { get; set; }

    public int? Ammount { get; set; }

    public decimal? Price { get; set; }

    public virtual Book IsbnNavigation { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
