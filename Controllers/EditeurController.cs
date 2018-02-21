using Admin_pro.Models;
using Admin_pro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin_pro.Controllers
{
    public class EditeurController : Controller
    {
        Manage_BooksEntities edit = new Manage_BooksEntities();
      

        // GET: Editeur
        public ActionResult Editeur()
        {
            var list = edit.Editeurs.ToList();
            return View(list);
        }




        [HttpGet]
        public ActionResult Create(int ? id_Editeur)
        {
            EditeurViewModel ed = new EditeurViewModel();
            if( id_Editeur != null)
            {

                var objet_modifier = edit.Editeurs.Where(x => x.id_Editeur == id_Editeur).First();
               ed.id_Editeur = (int)objet_modifier.id_Editeur;
                ed.nomE = objet_modifier.nomE;
                ed.prenomE = objet_modifier.prenomE;
                ed.nationalite = objet_modifier.nationalite;
                ed.Email = objet_modifier.Email;
                ed.ville = objet_modifier.ville;
            }
        
            return View(ed);
        }

        // POST: Editeur/Create
        [HttpPost]
        public ActionResult Create(EditeurViewModel aa1)
        {
            if (aa1.id_Editeur != 0)
            {
                var objet_modifier = edit.Editeurs.Where(x => x.id_Editeur == aa1.id_Editeur).First();
               
                objet_modifier.prenomE = aa1.prenomE;
                objet_modifier.nomE = aa1.nomE;
                objet_modifier.nationalite = aa1.nationalite;
                objet_modifier.ville = aa1.ville;
                objet_modifier.Email = aa1.Email;
            }
            else
            {
                edit.Editeurs.Add(new Models.Editeur
                {
                    nomE = aa1.nomE,
                    prenomE=aa1.prenomE,
                    ville=aa1.ville,
                    Email=aa1.Email,
                    nationalite=aa1.nationalite
                });
            }

           edit.SaveChanges();
            return RedirectToAction("Editeur");
        }


        [HttpGet]
        public ActionResult Delete(int? id_Editeur)
        {

            EditeurViewModel ed = new EditeurViewModel();
            if (id_Editeur != null)
            {

                var objet_modifier = edit.Editeurs.Where(x => x.id_Editeur == id_Editeur).First();
                ed.id_Editeur = objet_modifier.id_Editeur;


            }

            return View(ed);
        }
        [HttpPost]
        public ActionResult Delete(int? id_Editeur, bool conf)
        {

            if (id_Editeur != null)
            {

                var objet_modifier = edit.Editeurs.Where(x => x.id_Editeur == id_Editeur).First();
                edit.Editeurs.Remove(objet_modifier);
                edit.SaveChanges();


            }

            return RedirectToAction("Editeur");
        }

    }
}
