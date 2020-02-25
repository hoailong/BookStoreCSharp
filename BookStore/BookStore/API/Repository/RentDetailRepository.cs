using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.API.Repository
{
    public class RentDetailRepository : Repository<RentDetail>, IRentDetailRepository
    {
        public RentDetailRepository(BookStoreContext context) : base(context) { }

        public IEnumerable<BookRent> GetBookRentting()
        {
            var query = _context.RentDetail
              .Where(p => p.Payed == false)
              .GroupBy(p => new { p.BookId })
              .Select(g => new BookRent { BookId = g.Key.BookId, Count = g.Count() });
            return query;
        }
        public IEnumerable<BookRent> GetTop5()
        {
            var query = _context.RentDetail
              .GroupBy(p => new { p.BookId })
              .Select(g => new BookRent { BookId = g.Key.BookId, Count = g.Count() })
              .Take(5);
            return query;
        }

        public IEnumerable<RentDetail> GetByRentId(int rentId)
        {
            return _context.RentDetail.Where(a => a.RentId == rentId);
        }

        public void UpdatePayed(int bookId, int rentId)
        {
            var rent = _context.RentDetail.FirstOrDefault(a => a.BookId == bookId && a.RentId == rentId);
            rent.Payed = true;
            _context.SaveChanges();
        }
    }
}
