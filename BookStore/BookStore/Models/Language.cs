using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Language
    {
        public Language()
        {
            Book = new HashSet<Book>();
        }

        public int LangId { get; set; }
        public string LangName { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
