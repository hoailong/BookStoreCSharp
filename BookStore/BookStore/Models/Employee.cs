using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Account = new HashSet<Account>();
            Pay = new HashSet<Pay>();
            Rent = new HashSet<Rent>();
        }

        public int EmployeeId { get; set; }
        public string Fullname { get; set; }
        public string Birth { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double? Salary { get; set; }
        public int? ShiftId { get; set; }
        public bool? Status { get; set; }

        public virtual Shift Shift { get; set; }
        public virtual ICollection<Account> Account { get; set; }
        public virtual ICollection<Pay> Pay { get; set; }
        public virtual ICollection<Rent> Rent { get; set; }
    }
}
