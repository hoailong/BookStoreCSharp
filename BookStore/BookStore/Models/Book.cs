using System;
using System.Collections.Generic;

namespace BookStore.Models
{
    public partial class Book
    {
        public Book()
        {
            PayDetail = new HashSet<PayDetail>();
            RentDetail = new HashSet<RentDetail>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public int? Page { get; set; }
        public double? Price { get; set; }
        public double? RentPrice { get; set; }
        public int? Quantity { get; set; }
        public int? Total { get; set; }
        public string Image { get; set; }
        public int? TypeId { get; set; }
        public int? CategoryId { get; set; }
        public int? PublisherId { get; set; }
        public int? LangId { get; set; }
        public int? AuthorId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Language Lang { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Type Type { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<PayDetail> PayDetail { get; set; }
        public virtual ICollection<RentDetail> RentDetail { get; set; }
    }
}
