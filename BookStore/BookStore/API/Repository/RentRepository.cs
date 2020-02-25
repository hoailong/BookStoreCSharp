using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.API.Repository
{
    public class RentRepository : Repository<Rent>, IRentRepository
    {
        public RentRepository(BookStoreContext context) : base(context) { }

        public IEnumerable<Rent> GetByCustomerId(int? customerId)
        {
            return _context.Rent.Where(a => a.CustomerId == customerId);
        }
    }
}
