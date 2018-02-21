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

    public class OuvrageController : Controller
    {
        Manage_BooksEntities liv = new Manage_BooksEntities();
       

        // GET: Ouvrage
        public ActionResult ouvrage()
        {
            var lt = liv.Ouvrages.ToList();

            return View(lt);

        }


        [HttpGet]
        public ActionResult Create(int? id_ouvrage)
        {
            OuvrageViewModel omod = new OuvrageViewModel();
            if (id_ouvrage != null)
            {

                var objet_modifier = liv.Ouvrages.Where(x => x.id_ouvrage == id_ouvrage).First();
                omod.id_Editeur = (int)objet_modifier.id_Editeur;
                omod.nb_pages = (int)objet_modifier.nb_pages;
                omod.titre = objet_modifier.titre;
                omod.Quantite =(int) objet_modifier.Quantite;
                omod.id_ouvrage = objet_modifier.id_ouvrage;
                //omod.id_type =(int) objet_modifier.id_type;
                omod.Type = objet_modifier.Type;
                //omod.id_Auteur =(int) objet_modifier.id_Auteur;

            }
            
            return View(omod);
        }

        [HttpPost]

        public ActionResult Create(OuvrageViewModel ouv, HttpPostedFileBase file_ouvrage)
        {
            if (ouv.id_ouvrage != 0)
            {
                var objet_modifier = liv.Ouvrages.Where(x => x.id_ouvrage == ouv.id_ouvrage).First();
                objet_modifier.titre = ouv.titre;
                objet_modifier.nb_pages = (int)ouv.nb_pages;
                objet_modifier.id_Editeur = (int)ouv.id_Editeur;
                objet_modifier.Quantite = (int)ouv.Quantite;
                objet_modifier.id_ouvrage = (int)ouv.id_ouvrage;
                //objet_modifier.id_Auteur = (int)ouv.id_Auteur;
                objet_modifier.Type = ouv.Type;
                objet_modifier.Photo = ouv.Photo;
            }
            else
            {
                var fileNameOuvrage = Path.GetFileName(file_ouvrage.FileName);
                Random rand = new Random();
                var identifiant = rand.Next();
                fileNameOuvrage = fileNameOuvrage.Replace(fileNameOuvrage.Substring(0, fileNameOuvrage.IndexOf(".")), identifiant + "_ouvrage");
                var pathCv = Path.Combine(Server.MapPath("/img_ouvrage"), fileNameOuvrage);
                file_ouvrage.SaveAs(pathCv);

                liv.Ouvrages.Add(new Models.Ouvrage
                {
                    id_ouvrage = (int)ouv.id_ouvrage,
                    titre = ouv.titre,
                    nb_pages = (int)ouv.nb_pages,
                    id_Editeur = (int)ouv.id_Editeur,
                    Quantite = (int)ouv.Quantite,

                    Type=ouv.Type,
                    Photo = "/img_ouvrage/" + fileNameOuvrage

                    //id_Auteur=ouv.id_Auteur


                });
            }

           
                liv.SaveChanges();
          return RedirectToAction("Ouvrage"); }


        [HttpGet]
        public ActionResult Delete(int? id_ouvrage)
        {
            OuvrageViewModel omod = new OuvrageViewModel();
            if (id_ouvrage != null)
            {

                var objet_modifier = liv.Ouvrages.Where(x => x.id_ouvrage == id_ouvrage).First();
                omod.id_ouvrage = objet_modifier.id_ouvrage;
            }
            return View(omod);
        }
        [HttpPost]
        public ActionResult Delete(int? id_ouvrage,bool confi)
        {
           
            if (id_ouvrage != null)
            {

                var objet_modifier = liv.Ouvrages.Where(x => x.id_ouvrage == id_ouvrage).First();
                liv.Ouvrages.Remove(objet_modifier);
                liv.SaveChanges();


            }

            return RedirectToAction("ouvrage");
        }


    }
}