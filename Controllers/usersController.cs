using Admin_pro.Models;
using Admin_pro.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin_pro.Controllers
{
    public class usersController : Controller
    {
Manage_BooksEntities us = new Manage_BooksEntities();
        // GET: users
        public ActionResult Users()
        {
            var use = us.Authentifications.ToList();
  
            return View(use);
        }
      

        [HttpGet]
        public ActionResult Create(string  User_Name)
        {
            AuthentificationViewModel inf = new AuthentificationViewModel();
            if (User_Name != null)
            {

                var objet_modifier = us.Authentifications.Where(x => x.User_Name == User_Name).First();
                inf.User_Name = objet_modifier.User_Name;
                inf.Photouser = objet_modifier.Photouser;
                inf.Name = objet_modifier.Name;
                inf.Password_cle = objet_modifier.Password_cle;

                inf.Confirmpassword = objet_modifier.Confirmpassword;
                inf.prenom = objet_modifier.prenom;
              //  inf.Date = objet_modifier.Date;
                inf.Roles = objet_modifier.Roles;
                inf.Email = objet_modifier.Email;
                   

            }

            return View(inf);
        }

        // POST: Editeur/Create
        [HttpPost]
        public ActionResult Create(AuthentificationViewModel userr, HttpPostedFileBase photou_tilisateur)
        {
            if (userr.User_Name != null)
            {
                var objet_modifier = us.Authentifications.Where(x => x.User_Name == userr.User_Name).First();
                objet_modifier.User_Name = userr.User_Name;
                objet_modifier.Name = userr.Name;
                objet_modifier.Password_cle = userr.Password_cle;
                objet_modifier.prenom = userr.prenom;
                objet_modifier.Confirmpassword = userr.Confirmpassword;
                objet_modifier.Email = userr.Email;
           
                objet_modifier.Roles = userr.Roles;
                objet_modifier.Photouser = userr.Photouser;
              
            
            }
            else
            {
                var fileNameOuvrage = Path.GetFileName(photou_tilisateur.FileName);
                Random rand = new Random();
                var identifiant = rand.Next();
                fileNameOuvrage = fileNameOuvrage.Replace(fileNameOuvrage.Substring(0, fileNameOuvrage.IndexOf(".")), identifiant + "_ouvrage");
                var pathCv = Path.Combine(Server.MapPath("/PhotoUser"), fileNameOuvrage);
                photou_tilisateur.SaveAs(pathCv);








                us.Authentifications.Add(new Models.Authentification
                {
                    Name = userr.Name,
                    prenom= userr.prenom,
                    Password_cle = userr.Password_cle,
                    Confirmpassword = userr.Confirmpassword,
                  User_Name=userr.User_Name,
                    Email= userr.Email,
                    Roles = userr.Roles,


                    Photouser = "/img_ouvrage/" + fileNameOuvrage


                });
            }

            us.SaveChanges();
            return RedirectToAction("Users");
        }

        [HttpGet]
        public ActionResult Delete(string User_Name)
        {
            AuthentificationViewModel inf = new AuthentificationViewModel();
            if (User_Name != null)
            {

                var objet_modifier = us.Authentifications.Where(x => x.User_Name == User_Name).First();
                inf.User_Name = objet_modifier.User_Name;
            }
            return View(inf);
        }
        [HttpPost]
        public ActionResult Delete(string User_Name, bool confi)
        {

            if (User_Name != null)
            {

                var objet_modifier = us.Authentifications.Where(x => x.User_Name == User_Name).First();
                us.Authentifications.Remove(objet_modifier);
                us.SaveChanges();


            }

            return RedirectToAction("Users");
        }
       
    }
}