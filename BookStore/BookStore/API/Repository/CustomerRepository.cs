using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.API.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(BookStoreContext context) : base(context) { }

        public Customer getWithCustomerId(int customerId)
        {
            return _context.Customer.Where(a => a.CustomerId == customerId).FirstOrDefault(); ;
        }

        public Customer getWithCustomerPhone(string customerPhone)
        {
            return _context.Customer.Where(a => a.CustomerPhone == customerPhone).FirstOrDefault();
        }
    }
}
