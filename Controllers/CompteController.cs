using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin_pro.ViewModels;
using Admin_pro.Models;

namespace Admin_pro.Controllers
{
    public class CompteController : Controller
    {
        // GET: Compte
        public ActionResult Authentification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AuthentifierViewModel log)
        {
            AuthentifierModel lg = new AuthentifierModel();
            if(string.IsNullOrEmpty(log.Authentification.User_Name) || string.IsNullOrEmpty(log.Authentification.Password_cle) || lg.login(log.Authentification.User_Name,log.Authentification.Password_cle)==null)
            {
                ViewBag.erreurMessage = "Cette User Name OU bien Password est Incorrect !!!!";
             return View("Authentification");
            }
            return View("Succes");
        }
    }
}