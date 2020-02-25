using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class PayDetail
    {
        public int PayId { get; set; }
        public int RentId { get; set; }
        public int BookId { get; set; }
        public int? PenaltyId { get; set; }
        public double? IntoMoney { get; set; }

        public virtual Rent Rent { get; set; }
        public virtual Book Book { get; set; }
        public virtual Pay Pay { get; set; }
        public virtual Penalty Penalty { get; set; }
    }
}
