using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.API.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer getWithCustomerPhone(string customerPhone);
        Customer getWithCustomerId(int customerId);
    }
}
