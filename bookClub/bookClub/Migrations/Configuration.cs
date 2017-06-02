using bookClub.Models;
using System;
using System.Data.Entity.Migrations;
using System.Text;

namespace bookClub.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BookClubContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookClubContext context)
        {
            var account = new Account { ID = 1, Name = "Toader Daiana", Username = "daiana", Password = "pass", Type = 0};
            var author = new Author { ID = 1, Name = "Mircea Eliade" };
            var books = new Book[] {
                new Book { ID = 1, Name = "Nunta in cer",Description="A book about love.", Genre = Genre.Fiction, AuthorID=1},
                new Book { ID = 2, Name = "Maitreyi",Description="A book about love.", Genre = Genre.Fiction, AuthorID=1}
            };
            var quotes = new Quote[] {
                new Quote { ID = 1, Text = "Nimic nu dureaza in suflet. Pana si cea mai verificata incredere poate fi anulata de un singur gest", BookID = 2 },
                new Quote { ID = 2, Text = "Bucurestiul, indeosebi, are cele mai toxice amurguri, in toate anotimpurile.", BookID = 1}
            };

            
            var reviews = new Review[] {
                new Review { ID = 1, Rating = 9, Text="Buna", BookID = 2, AccountID = 1},
                new Review { ID = 2, Rating = 10, Text="Foarte buna", BookID = 1, AccountID = 1}
            };

            foreach (var b in books)
                account.Books.Add(b);

            books[0].Quotes.Add(quotes[1]);
            books[1].Quotes.Add(quotes[0]);

            books[0].Reviews.Add(reviews[1]);
            books[1].Reviews.Add(reviews[0]);

            context.Authors.AddOrUpdate(author);
            context.Books.AddOrUpdate(books);
            context.Reviews.AddOrUpdate(reviews);
            context.Quotes.AddOrUpdate(quotes);
            context.Accounts.AddOrUpdate(account);
        }
    }
}
