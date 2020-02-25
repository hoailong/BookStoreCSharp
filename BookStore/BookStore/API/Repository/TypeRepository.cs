using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.API.Interfaces;
using BookStore.Models;
using Type = BookStore.Models.Type;

namespace BookStore.API.Repository
{
    public class TypeRepository : Repository<Type>, ITypeRepository
    {
        public TypeRepository(BookStoreContext context) : base(context) { }
    }
}
