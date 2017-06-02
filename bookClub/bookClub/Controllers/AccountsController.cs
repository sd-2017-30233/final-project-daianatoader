using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bookClub.Models;
using bookClub.Repository;
using bookClub.Services;

namespace bookClub.Controllers
{
    public class AccountsController : Controller
    {
        private BookClubContext db = new BookClubContext();
        private UnitOfWork _uow = new UnitOfWork();

        // GET: Accounts
        public ActionResult Index()
        {

            AccountService _as = new AccountService();
            return View(_as.getAll());
            
        }
        public ActionResult LogOff()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
  
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccountService _as = new AccountService();
            Account account = _as.getById((int)id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }




        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Username,Password,Type")] Account account)
        {
            AccountService _as = new AccountService();
            if (ModelState.IsValid)
            {
                _as.add(account);
                return RedirectToAction("Index");
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            AccountService _as = new AccountService();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = _as.getById((int)id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Username,Password,Type")] Account account)
        {
            AccountService _as = new AccountService();
            if (ModelState.IsValid)
            {
                _as.updateAccount(account.ID, account);
                return RedirectToAction("Index");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            AccountService _as = new AccountService();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = _as.getById((int)id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountService _as = new AccountService();
            _as.deleteAccount((int)id);
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
