using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Type
    {
        public Type()
        {
            Book = new HashSet<Book>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
