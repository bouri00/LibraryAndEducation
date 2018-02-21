using Admin_pro.Models;
using Admin_pro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin_pro.Controllers
{
    public class EtudiantController : Controller
    {
        Manage_BooksEntities bdt = new Manage_BooksEntities();
      

        // GET: Etudiant
        public ActionResult Etudiant()
        {
            var list = bdt.Etudiants.ToList();
            return View(list);
        }

        public ActionResult Create(int? num_etudiant)
        {
            EtudiantViewModel etd = new EtudiantViewModel();
            if (num_etudiant != null)
            {

                var objet_modifier = bdt.Etudiants.Where(x => x.num_etudiant == num_etudiant).First();
                etd.num_etudiant = (int)objet_modifier.num_etudiant;
                etd.nom = objet_modifier.nom;
                etd.prenom = objet_modifier.prenom;
                etd.ville = objet_modifier.ville;
                etd.adresse = objet_modifier.adresse;
                etd.code_postal = objet_modifier.code_postal;
                etd.date_naissance = (DateTime)objet_modifier.date_naissance;
                etd.Pays = objet_modifier.Pays;
            }
            return View(etd);
        }
        [HttpPost]
        public ActionResult Create(EtudiantViewModel mo)
        {

            if (mo.num_etudiant != 0)
            {

                var objet_modifier = bdt.Etudiants.Where(x => x.num_etudiant == mo.num_etudiant).First();
                objet_modifier.num_etudiant = mo.num_etudiant;
                objet_modifier.nom = mo.nom;
                objet_modifier.prenom = mo.prenom;
                objet_modifier.ville = mo.ville;
                objet_modifier.adresse = mo.adresse;
                objet_modifier.code_postal = mo.code_postal;
                objet_modifier.date_naissance = mo.date_naissance;
                objet_modifier.Pays = mo.Pays;
            }

            else
            {

                bdt.Etudiants.Add(new Models.Etudiant
                {
                    num_etudiant = mo.num_etudiant,
                    nom = mo.nom,
                    prenom = mo.prenom,
                    adresse = mo.adresse,
                    ville = mo.ville,
                    telephone = mo.telephone,
                    date_naissance = mo.date_naissance,
                    code_postal = mo.code_postal,
                    Pays=mo.Pays

                });
            }
            bdt.SaveChanges();
            return RedirectToAction("Etudiant");
        }
        [HttpGet]
        public ActionResult Delete(int? num_etudiant)
        {


            EtudiantViewModel om = new EtudiantViewModel();
            if (num_etudiant != null)
            {

                var objet_modifier = bdt.Etudiants.Where(x => x.num_etudiant == num_etudiant).First();
                om.num_etudiant= objet_modifier.num_etudiant;


            }

            return View(om);
        }
        [HttpPost]
        public ActionResult Delete(int? num_etudiant, bool confi)
        {

            if (num_etudiant != null)
            {

                var objet_modifier = bdt.Etudiants.Where(x => x.num_etudiant == num_etudiant).First();
                bdt.Etudiants.Remove(objet_modifier);
                bdt.SaveChanges();


            }

            return RedirectToAction("Etudiant");
        }






    }
}