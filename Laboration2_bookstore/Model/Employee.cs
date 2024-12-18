using System;
using System.Collections.Generic;

namespace Laboration2_bookstore.Model;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? WorkplaceId { get; set; }

    public int? ManagerId { get; set; }

    public virtual Manager? Manager { get; set; }

    public virtual Store? Workplace { get; set; }
}
