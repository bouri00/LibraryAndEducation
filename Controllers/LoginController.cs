using Admin_pro.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Admin_pro.Controllers
{
    public class LoginController : Controller
    {
        Manage_BooksEntities log = new Manage_BooksEntities();
        // GET: Login
        public ActionResult mapage()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                RedirectToAction("Login2");
            }

            return View();
        }
        public ActionResult Login2()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login2(Authentification lg)
        {
            if (ModelState.IsValid)
            {
                using (Manage_BooksEntities conex = new Manage_BooksEntities())
                {
                    var mk = conex.Authentifications.Where(a => a.User_Name.Equals(lg.User_Name) && a.Password_cle.Equals(lg.Password_cle)).FirstOrDefault();
                    if (mk != null)
                    {
                        Session["UserId"] = mk.User_Name.ToString();
              

                        return RedirectToAction("mapage");

                    }
                   
                }
            }
            return View(lg);
        }




        public ActionResult Logintest()
        {
            return View();
        }
        public ActionResult Authentification()
        {
            return View();
        }





    }
}