using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Application
{ 
    public class OrderItemDTO
    {
        public long Id { get; set; }

        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public decimal Price { get; set; }

        public DateTime CreateDate { get; set; }

        public string? Description { get; set; }
        public string? PriceString { get; set; }
    }
}
