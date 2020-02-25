using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;

namespace BookStore.API.Repository
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(BookStoreContext context) : base(context) { }
    }
}
