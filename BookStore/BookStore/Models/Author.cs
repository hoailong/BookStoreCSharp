using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Birth { get; set; }
        public bool? Gender { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Book> Book { get; set; }

    }
}
