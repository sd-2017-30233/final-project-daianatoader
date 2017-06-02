using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bookClub.Models;
using bookClub.Services;

namespace bookClub.Controllers
{
    public class BooksController : Controller
    {
        private BookClubContext db = new BookClubContext();
        private BookService _bs = new BookService();
        // GET: Books
        public ActionResult Index()
        {
            var books = _bs.getAll().AsQueryable().Include(b => b.Author);
            return View(books.ToList());
        }

        public ActionResult IndexFilter(string bookGenre, string searchString)
        {
           
            var books = _bs.getAll().ToList();
            
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Name.Contains(searchString) || s.Author.Name.Contains(searchString) || ((Genre)s.Genre).ToString().Contains(searchString)).ToList();
            }


            return View(books);
        }

        public ActionResult Favourites(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using(var context = new BookClubContext())
            {
                Book b = context.Books.Find(id);
                Account acc = context.Accounts.Find(Int32.Parse(Session["UserID"].ToString()));
                foreach(Book b1 in acc.Books.ToList())
                {
                    if (!(b1.Equals(b))){
                        acc.Books.Add(b);
                    }
                }
                
                context.Accounts.Attach(acc);
                context.SaveChanges();
            }
            Book book = _bs.getById((int)id);
            AccountService _as = new AccountService();
            //Account acc = _as.getById(Int32.Parse(Session["UserID"].ToString()));
           
            
           // acc.Books.Add(book);
           // _as.updateBook(Int32.Parse(Session["UserID"].ToString()),book);
        
            if (book == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "Books");
        }

        public ActionResult FavouritesFilter(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _bs.getById((int)id);
            /*  
              AccountService _as = new AccountService();
              Account acc = _as.getById(Int32.Parse(Session["UserID"].ToString()));
              acc.Books.Add(book);
              _as.updateAccount(acc.ID,acc);*/
            using (var context = new BookClubContext())
            {
                Book b = context.Books.Find(id);
                Account acc = context.Accounts.Find(Int32.Parse(Session["UserID"].ToString()));
                foreach (Book b1 in acc.Books)
                {
                    if (!(b1.Equals(b)))
                    {
                        acc.Books.Add(b);
                    }
                }

                context.Accounts.Attach(acc);
                context.SaveChanges();
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("IndexFilter", "Books");
           
        }

        public ActionResult ProfileUser()
        {


            AccountService _as = new AccountService();
            Account account = _as.getById(Int32.Parse(Session["UserID"].ToString()));
            var books = account.Books.ToList();
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _bs.getById((int)id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        // GET: Books/Create
        public ActionResult Create()
        {
            AuthorService _as = new AuthorService();
            ViewBag.AuthorID = new SelectList(_as.getAll(), "ID", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Genre,AuthorID")] Book book)
        {
            AuthorService _as = new AuthorService();
            if (ModelState.IsValid)
            {
                _bs.add(book);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(_as.getAll(), "ID", "Name", book.AuthorID);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            AuthorService _as = new AuthorService();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _bs.getById((int)id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorID = new SelectList(_as.getAll(), "ID", "Name", book.AuthorID);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Genre,AuthorID")] Book book)
        {
            AuthorService _as = new AuthorService();
            if (ModelState.IsValid)
            {
                _bs.updateBook(book.ID, book);
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(_as.getAll(), "ID", "Name", book.AuthorID);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = _bs.getById((int)id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _bs.deleteBook(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
