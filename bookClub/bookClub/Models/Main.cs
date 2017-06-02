using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookClub.Models
{
    public class Main
    {
        public static void main(String[] args)
        {
            Console.WriteLine("daaaaaaaaaaa");
            BookClubContext b = new BookClubContext();
            var list = b.Accounts.ToList();
            list.ForEach(Console.WriteLine);
        }
    }
}