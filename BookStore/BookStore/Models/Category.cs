using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Category
    {
        public Category()
        {
            Book = new HashSet<Book>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
