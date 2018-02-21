using Admin_pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin_pro.ViewModels;
namespace Admin_pro.Controllers
{
    public class ExemplaireController : Controller
    {
        Manage_BooksEntities Exe = new Manage_BooksEntities();

        public ActionResult Exemplaire()
        {
            var lis = Exe.Exemplaires.ToList();
            return View(lis);
        }


        [HttpGet]
        public ActionResult Create()
        {

            ExemplaireViewModel exm = new ExemplaireViewModel();
            return View();
        }

}
}
       