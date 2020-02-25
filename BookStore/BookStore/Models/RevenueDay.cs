using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class RevenueDay
    {
        public String CustomerName { get; set; }
        public DateTime? PayDate { get; set; }
        public float TotalMoney { get; set; }
        public String Fullname { get; set; }
    }
}
