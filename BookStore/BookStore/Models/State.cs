using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class State
    {
        public State()
        {
            RentDetail = new HashSet<RentDetail>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<RentDetail> RentDetail { get; set; }
    }
}
