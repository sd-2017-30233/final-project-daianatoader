using bookClub.Models;
using bookClub.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookClub.Services
{
    public class AccountService
    {
        private UnitOfWork _uow;

        public AccountService()
        {
            _uow = new UnitOfWork();
        }

        public Account getById(int id)
        {
            return _uow.AccountRepository.GetById(id);
        }

        public List<Account> getAll()
        {
            List<Account> a = _uow.AccountRepository.GetAll().ToList();
            return a;
        }

        public void add(Account a)
        {
            _uow.AccountRepository.Insert(a);
        }
        public void updateBook(int id,Book b)
        {
            Account a = _uow.AccountRepository.GetById(id);
            a.Books.Add(b);
            _uow.AccountRepository.Update(a);
        }
        public void updateAccount(int id, Account acc)
        {
            Account a = _uow.AccountRepository.GetById(id);
            a.Name = acc.Name;
            a.Username = acc.Username;
            a.Password = acc.Password;
            a.Books = acc.Books;
            a.Type = acc.Type;
            _uow.AccountRepository.Update(a);
        }
        public void deleteAccount(int id)
        {
            Account a = _uow.AccountRepository.GetById(id);
            _uow.AccountRepository.Delete(a);
        }
    }
}