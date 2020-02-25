using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Shift
    {
        public Shift()
        {
            Employee = new HashSet<Employee>();
        }

        public int ShiftId { get; set; }
        public string ShiftName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
