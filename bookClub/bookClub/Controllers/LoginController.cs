using bookClub.Models;
using bookClub.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bookClub.Controllers
{
    public class LoginController : Controller
    {
        private AccountService _as = new AccountService();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account acc)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    var obj = _as.getAll().First(a => a.Username.Equals(acc.Username) && a.Password.Equals(acc.Password));
                    if (obj != null)
                    {
                        Session["UserID"] = obj.ID.ToString();
                        Session["UserName"] = obj.Username.ToString();
                        Session["UserType"] = obj.Type.ToString();
                        Session["Name"] = obj.Name.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(acc);
                }
            }
            return View();
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Username,Password")]Account account)
        {
            AccountService _as = new AccountService();
            if (ModelState.IsValid)
            {
                account.Type = 1;
                _as.add(account);
                return RedirectToAction("Index", "Home");
            }

            return View(account);
        }

    }

}