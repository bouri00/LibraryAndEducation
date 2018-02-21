using Admin_pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin_pro.Controllers
{
    public class ListeFormationController : Controller
    {
        Manage_BooksEntities bd_librairie = new Manage_BooksEntities();
        // GET: ListeFormation
        public ActionResult ListeFormation()
        {
          
            return View();

        }
    }
}