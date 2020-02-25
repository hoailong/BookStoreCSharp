using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Book = new HashSet<Book>();
        }

        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
