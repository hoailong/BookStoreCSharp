using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Penalty
    {
        public Penalty()
        {
            PayDetail = new HashSet<PayDetail>();
        }

        public int PenaltyId { get; set; }
        public string PenaltyName { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<PayDetail> PayDetail { get; set; }
    }
}
