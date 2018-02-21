using Admin_pro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Admin_pro.ViewModels;
using System.IO;
using System.Data.Entity.Validation;


namespace Admin_pro.Controllers
{
    public class CommanderController : Controller
    {
        Manage_BooksEntities com = new Manage_BooksEntities();
        // GET: Commander
        public ActionResult Acheter()
        {
            var comand = com.Commanders.ToList();

            return View(comand);
        }


        [HttpGet]
        public ActionResult Create(int? Idcom)
        {CommanderViewModel oo = new CommanderViewModel();
            if (Idcom != null)
            {

                var objet_modifier =com.Commanders.Where(x => x.Idcom == Idcom).First();
                oo.Idcom = (int)objet_modifier.Idcom;
                oo.Prix = (float)objet_modifier.Prix;
               
                oo.quantite = (int)objet_modifier.quantite;
                oo.Remise =(float) objet_modifier.remise;
                //omod.id_type =(int) objet_modifier.id_type;
                oo.Total =(float) objet_modifier.Total;
                oo.ville_livraison = objet_modifier.ville_livraison;
                oo.pays_livraison = objet_modifier.pays_livraison;
                oo.datecommande = (DateTime)objet_modifier.datecommande;
                oo.date_envoi = (DateTime)objet_modifier.date_envoi;
                oo.destinataire = objet_modifier.destinataire;
                oo.id_ouvrage = (int)objet_modifier.id_ouvrage;


            }

            return View(oo);
        }

        [HttpPost]

        public ActionResult Create(CommanderViewModel cv)
        {
            if (cv.Idcom != 0)
            {
                var objet_modifier =com.Commanders.Where(x => x.Idcom == cv.Idcom).First();
                objet_modifier.Idcom = (int)cv.Idcom;
                objet_modifier.quantite = (int)cv.quantite;
                objet_modifier.id_ouvrage = (int)cv.id_ouvrage;
                objet_modifier.destinataire = cv.destinataire;
                objet_modifier.date_envoi = (DateTime)cv.date_envoi;
                objet_modifier.datecommande = (DateTime)cv.datecommande;
                objet_modifier.ville_livraison = cv.ville_livraison;
                objet_modifier.remise = (float)cv.Remise;
                objet_modifier.pays_livraison = cv.pays_livraison;
                objet_modifier.Prix = (float)cv.Prix;
                objet_modifier.Total = (float)cv.Total;

            }
            else
            {

                com.Commanders.Add(new Models.Commander
                {
                    id_ouvrage = (int)cv.id_ouvrage,
                    Total = (float)cv.Total,
                    date_envoi=(DateTime) cv.date_envoi,
                    datecommande=(DateTime) cv.datecommande,
                    remise=(float)cv.Remise,
                    pays_livraison=cv.pays_livraison,
                    destinataire=cv.destinataire,
                    Prix=(float)cv.Prix,
                    ville_livraison=cv.ville_livraison,
                    quantite=(int)cv.quantite


                 

                });
            }


            com.SaveChanges();
            return RedirectToAction("Acheter");
        }


        [HttpGet]
        public ActionResult Delete(int? Idcom)
        {
            CommanderViewModel od = new CommanderViewModel();
            if (Idcom != null)
            {

                var objet_modifier = com.Commanders.Where(x => x.Idcom == Idcom).First();
                od.Idcom = objet_modifier.Idcom;
            }
            return View(od);
        }
        [HttpPost]
        public ActionResult Delete(int? Idcom, bool confi)
        {

            if (Idcom != null)
            {

                var objet_modifier = com.Commanders.Where(x => x.Idcom == Idcom).First();
                com.Commanders.Remove(objet_modifier);
                com.SaveChanges();


            }

            return RedirectToAction("Acheter");
        }

    }
}