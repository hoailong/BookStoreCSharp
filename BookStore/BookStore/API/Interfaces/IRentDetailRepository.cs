using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.API.Interfaces
{
    public interface IRentDetailRepository : IRepository<RentDetail>
    {
        IEnumerable<RentDetail> GetByRentId(int rentId);
        IEnumerable<BookRent> GetBookRentting();
        IEnumerable<BookRent> GetTop5();
        void UpdatePayed(int bookId, int rentId);
    }
}
