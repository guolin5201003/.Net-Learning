using System;
using System.Collections.Generic;

namespace Repository.Domain.Models;

public partial class Product
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }
}
