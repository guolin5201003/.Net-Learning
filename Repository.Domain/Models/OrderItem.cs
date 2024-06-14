using System;
using System.Collections.Generic;

namespace Repository.Domain.Models;

public partial class OrderItem
{
    public long Id { get; set; }

    public long OrderId { get; set; }

    public long ProductId { get; set; }

    public decimal Price { get; set; }

    public DateTime CreateDate { get; set; }

    public string? Description { get; set; }
}
