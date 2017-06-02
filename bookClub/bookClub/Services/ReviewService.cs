using bookClub.Models;
using bookClub.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookClub.Services
{
    public class ReviewService
    {
        private UnitOfWork _uow;

        public ReviewService()
        {
            _uow = new UnitOfWork();
        }

        public Review getById(int id)
        {
            return _uow.ReviewRepository.GetById(id);
        }

        public List<Review> getAll()
        {
            List<Review> a = _uow.ReviewRepository.GetAll().ToList();
            return a;
        }

        public void add(Review a)
        {
            _uow.ReviewRepository.Insert(a);
        }

        public void updateReview(int id, Review rev)
        {
            Review a = _uow.ReviewRepository.GetById(id);
            a.Text = rev.Text;
            a.Book = rev.Book;
            a.Rating = rev.Rating;
            _uow.ReviewRepository.Update(a);
        }
        public void deleteReview(int id)
        {
            Review a = _uow.ReviewRepository.GetById(id);
            _uow.ReviewRepository.Delete(a);
        }
    }
}