using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.API.Repository
{
    public class ReportRepository : Repository<RevenueDay>, IReportRepository
    {
        public ReportRepository(BookStoreContext context) : base(context) { }

        public IEnumerable<RevenueDay> GetRevenueDay()
        {
            //var query = _context.RevenueDay.FromSql("EXEC GetRevenueDay '2019-09-09'");            //var query = _context.RevenueDay.FromSql("EXEC GetRevenueDay '2019-09-09'");
            return null;
        }
    }
}
