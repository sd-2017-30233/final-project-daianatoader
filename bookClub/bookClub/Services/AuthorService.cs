using bookClub.Models;
using bookClub.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookClub.Services
{
    public class AuthorService
    {
        private UnitOfWork _uow;

        public AuthorService()
        {
            _uow = new UnitOfWork();
        }

        public Author getById(int id)
        {
            return _uow.AuthorRepository.GetById(id);
        }

        public List<Author> getAll()
        {
            List<Author> a = _uow.AuthorRepository.GetAll().ToList();
            return a;
        }

        public void add(Author a)
        {
            _uow.AuthorRepository.Insert(a);
        }

        public void updateAuthor(int id, Author acc)
        {
            Author a = _uow.AuthorRepository.GetById(id);
            a.Name = acc.Name;
            _uow.AuthorRepository.Update(a);
        }
        public void deleteAuthor(int id)
        {
            Author a = _uow.AuthorRepository.GetById(id);
            _uow.AuthorRepository.Delete(a);
        }
    }
}