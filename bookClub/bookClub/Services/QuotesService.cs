using bookClub.Models;
using bookClub.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookClub.Services
{
    public class QuoteService
    {
        private UnitOfWork _uow;

        public QuoteService()
        {
            _uow = new UnitOfWork();
        }

        public Quote getById(int id)
        {
            return _uow.QuoteRepository.GetById(id);
        }

        public List<Quote> getAll()
        {
            List<Quote> a = _uow.QuoteRepository.GetAll().ToList();
            return a;
        }

        public void add(Quote a)
        {
            _uow.QuoteRepository.Insert(a);
        }

        public void updateQuote(int id, Quote rev)
        {
            Quote a = _uow.QuoteRepository.GetById(id);
            a.Text = rev.Text;
            a.Book = rev.Book;
            _uow.QuoteRepository.Update(a);
        }
        public void deleteQuote(int id)
        {
            Quote a = _uow.QuoteRepository.GetById(id);
            _uow.QuoteRepository.Delete(a);
        }
    }
}