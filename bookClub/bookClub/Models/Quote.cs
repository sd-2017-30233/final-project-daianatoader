using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookClub.Models
{
    public class Quote
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
    }
}