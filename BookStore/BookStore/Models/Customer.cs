using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Rent = new HashSet<Rent>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string Birth { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Rent> Rent { get; set; }
    }
}
