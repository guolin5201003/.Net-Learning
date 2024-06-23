using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Application
{
    public class OrderDTO
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public DateTime? CreateDate { get; set; }

        public string? Description { get; set; }

        public decimal? TotalPrice { get; set; }
        public string TotalPriceStr { get; set; }

    }
}
