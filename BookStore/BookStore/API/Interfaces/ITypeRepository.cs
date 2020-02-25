using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Type = BookStore.Models.Type;

namespace BookStore.API.Interfaces
{
    public interface ITypeRepository : IRepository<Type>
    {
    }
}
