using System;
using System.Collections.Generic;

namespace Repository.Domain.Models;

public partial class Customer
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Gender { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }
}
