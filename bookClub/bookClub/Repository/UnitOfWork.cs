using bookClub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookClub.Repository
{
    public class UnitOfWork
    {
        private BookClubContext context = new BookClubContext();
        private Repository<Account> accountRepository;
        private Repository<Book> bookRepository;
        private Repository<Author> authorRepository;
        private Repository<Quote> quoteRepository;
        private Repository<Review> reviewRepository;

        public IRepository<Account> AccountRepository
        {
            get
            {

                if (this.accountRepository == null)
                {
                    this.accountRepository = new Repository<Account>(context);
                }
                return accountRepository;
            }
        }


        public IRepository<Book> BookRepository
        {
            get
            {

                if (this.bookRepository == null)
                {
                    this.bookRepository = new Repository<Book>(context);
                }
                return bookRepository;
            }
        }

        public IRepository<Author> AuthorRepository
        {
            get
            {

                if (this.authorRepository == null)
                {
                    this.authorRepository = new Repository<Author>(context);
                }
                return authorRepository;
            }
        }

        public IRepository<Quote> QuoteRepository
        {
            get
            {

                if (this.quoteRepository == null)
                {
                    this.quoteRepository = new Repository<Quote>(context);
                }
                return quoteRepository;
            }
        }

        public IRepository<Review> ReviewRepository
        {
            get
            {

                if (this.reviewRepository == null)
                {
                    this.reviewRepository = new Repository<Review>(context);
                }
                return reviewRepository;
            }
        }

    }
}