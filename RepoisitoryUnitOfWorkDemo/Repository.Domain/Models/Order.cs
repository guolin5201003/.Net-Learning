using System;
using System.Collections.Generic;

namespace Repository.Domain.Models;

public partial class Order
{
    public long Id { get; set; }

    public long CustomerId { get; set; }

    public DateTime? CreateDate { get; set; }

    public string? Description { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
