using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.API.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        IEnumerable<Account> GetUser(String username, String pass);
    }
}
