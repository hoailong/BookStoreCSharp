using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Rent
    {
        public Rent()
        {
            RentDetail = new HashSet<RentDetail>();
        }

        public int RentId { get; set; }
        public DateTime? RentDate { get; set; }
        public double? Deposit { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<RentDetail> RentDetail { get; set; }
    }
}
