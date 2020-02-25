using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.API.Interfaces
{
    public interface IPayRepository : IRepository<Pay>
    {
        IEnumerable<Pay> GetPayByDate(DateTime from, DateTime to);
    }
}
