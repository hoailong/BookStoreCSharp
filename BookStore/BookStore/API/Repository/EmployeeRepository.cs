using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.API.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(BookStoreContext context) : base(context) { }

        public Employee GetById(int? employeeId)
        {
            return _context.Employee.Find(employeeId);
        }
    }
}
