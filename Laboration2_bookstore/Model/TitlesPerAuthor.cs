using System;
using System.Collections.Generic;

namespace Laboration2_bookstore.Model;

public partial class TitlesPerAuthor
{
    public string? FullName { get; set; }

    public int? Age { get; set; }

    public int? TitleCount { get; set; }

    public double TotalBookValue { get; set; }
}
