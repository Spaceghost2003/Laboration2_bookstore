using System;
using System.Collections.Generic;

namespace Laboration2_bookstore.Model;

public partial class Manager
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
