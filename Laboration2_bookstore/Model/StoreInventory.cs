using System;
using System.Collections.Generic;

namespace Laboration2_bookstore.Model;

public partial class StoreInventory
{
    public int StoreId { get; set; }

    public string? StoreName { get; set; }

    public string? StoreAddress { get; set; }

    public string? BookIsbn { get; set; }

    public int? Quantity { get; set; }
}
