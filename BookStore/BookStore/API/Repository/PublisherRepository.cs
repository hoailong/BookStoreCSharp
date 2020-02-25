using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.API.Repository
{
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(BookStoreContext context) : base(context) { }
    }
}
