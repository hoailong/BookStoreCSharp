using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.API.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookStoreContext context) : base(context) { }

        public void AddQuantity(int bookId)
        {
            var book = _context.Book.FirstOrDefault(a => a.BookId == bookId);
            int? quant = book.Quantity + 1;
            book.Quantity = quant;
            _context.SaveChanges();
        }

        public void SubQuantity(int bookId)
        {
            var book = _context.Book.FirstOrDefault(a => a.BookId == bookId);
            int? quant = book.Quantity - 1;
            book.Quantity = quant;
            _context.SaveChanges();
        }
    }
}
