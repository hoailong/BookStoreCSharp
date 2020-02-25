using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.API.Repository
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(BookStoreContext context) : base(context) { }

        public IEnumerable<Account> GetUser(string username, string pass)
        {
            return _context.Account.Where(a => (a.Username == username || a.Phone == username) && a.Password == pass);
        }
    }
}
