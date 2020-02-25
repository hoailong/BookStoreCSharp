using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.API.Repository
{
    public class PayDetailRepository : Repository<PayDetail>, IPayDetailRepository
    {
        public PayDetailRepository(BookStoreContext context) : base(context) { }

        public IEnumerable<PayDetail> GetByPayId(int payId)
        {
            return _context.PayDetail.Where(a => a.PayId == payId);
        }
    }
}
