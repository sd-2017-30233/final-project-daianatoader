using bookClub.Models;
using bookClub.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookClub.Services
{
    public class BookService
    {
        private UnitOfWork _uow;

        public BookService()
        {
            _uow = new UnitOfWork();
        }

        public Book getById(int id)
        {
            return _uow.BookRepository.GetById(id);
        }

        public List<Book> getAll()
        {
            List<Book> a = _uow.BookRepository.GetAll().ToList();
            return a;
        }

        public void add(Book a)
        {
            _uow.BookRepository.Insert(a);
        }

        public void updateBook(int id, Book acc)
        {
            Book a = _uow.BookRepository.GetById(id);
            a.Name = acc.Name;
            a.Genre = acc.Genre;
            a.Author = acc.Author;
            _uow.BookRepository.Update(a);
        }
        public void deleteBook(int id)
        {
            Book a = _uow.BookRepository.GetById(id);
            _uow.BookRepository.Delete(a);
        }
    }
}