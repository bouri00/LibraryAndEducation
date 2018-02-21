using Admin_pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin_pro.Controllers
{
    public class RegistreUserController : Controller
    {
        

        // GET: RegistreUser
        public ActionResult RegistreUser()
        {
            return View();
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult RegistreUser(Users US)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (MyDataBaseEntities dd = new MyDataBaseEntities())
        //        {
        //            dd.Users.Add();
        //            dd.SaveChanges();
        //            ModelState.Clear();
        //            ViewBag.Message = "Toute Champs Est bien Enregistrer   ";
        //        }
        //    }

        //    return View(US);
        //}
    }
}