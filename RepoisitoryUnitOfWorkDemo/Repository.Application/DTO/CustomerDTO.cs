using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Application
{
    public class CustomerDTO
    {
        public long Id { get; set; }

        public string? LastName { get; set; }
        public string? FirstName { get; set; }

        public bool Gender { get; set; }

        public DateTime? Birthday { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
        public virtual ICollection<OrderDTO> Orders { get; set; }
    }
}
