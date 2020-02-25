using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Pay
    {
        public int PayId { get; set; }
        public DateTime? PayDate { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public double? TotalMoney { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual PayDetail PayDetail { get; set; }
    }
}
