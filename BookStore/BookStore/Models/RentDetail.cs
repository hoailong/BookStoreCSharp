using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class RentDetail
    {
        public int RentId { get; set; }
        public int BookId { get; set; }
        public double? RentPrice { get; set; }
        public int StateId { get; set; }
        public bool? Payed { get; set; }

        public virtual Book Book { get; set; }
        public virtual Rent Rent { get; set; }
        public virtual State State { get; set; }
    }
}
