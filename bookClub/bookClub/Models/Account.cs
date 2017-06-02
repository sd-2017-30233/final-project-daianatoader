using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookClub.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Type { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public Account()
        {
            Books = new HashSet<Book>();
            Reviews = new HashSet<Review>();
        }
    }
}