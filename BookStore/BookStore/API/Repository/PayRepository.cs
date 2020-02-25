using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.API.Repository
{
    public class PayRepository : Repository<Pay>, IPayRepository
    {
        public PayRepository(BookStoreContext context) : base(context) { }

        public IEnumerable<Pay> GetPayByDate(DateTime from, DateTime to)
        {
            return _context.Pay.Where(a => a.PayDate >= from && a.PayDate <= to);
        }
    }
}
