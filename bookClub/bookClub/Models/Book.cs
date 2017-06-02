using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookClub.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public Book()
        {
            Quotes = new HashSet<Quote>();
            Reviews = new HashSet<Review>();
        }
    }
}